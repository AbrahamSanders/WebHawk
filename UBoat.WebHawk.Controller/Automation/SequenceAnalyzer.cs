using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Automation.Steps;
using UBoat.WebHawk.Controller.Model.Automation.Iterations;
using UBoat.WebHawk.Controller.Model.Data;
using UBoat.WebHawk.Controller.Data;
using UBoat.WebHawk.Controller.Model.Database;

namespace UBoat.WebHawk.Controller.Automation
{
    /// <summary>
    /// Provides methods for interrogating the structure of a sequence.
    /// </summary>
    internal class SequenceAnalyzer
    {
        #region Private members

        private const string DefaultCacheKeyScope = "AnonymousClass";

        /// <summary>
        /// This class represents the "scope" of a step. That is, the root of the sequence or an iteration.
        /// Group steps without iterations do not create new scope, thus why StepScope keeps track of the execution branch where either the sequence root or
        /// the last iteration was found.
        /// </summary>
        private class StepScope
        {
            public StepScope(string scopeName, string className, string cacheKey, ExecutionBranch rootBranch)
            {
                this.ScopeName = scopeName;
                this.ClassName = className;
                this.CacheKey = cacheKey;
                this.RootBranch = rootBranch;
                this.VariableList = new List<StateVariableInfo>();
            }

            /// <summary>
            /// The list of variables declared within this scope.
            /// </summary>
            public List<StateVariableInfo> VariableList { get; set; }
            /// <summary>
            /// The name of this scope. This must be unique within any given scope list (you can't have two nested scopes with the same name!)
            /// </summary>
            public string ScopeName { get; set; }
            /// <summary>
            /// The name of the class represented by the scope.
            /// This is used with iterations, where we are iterating over a ListStateVariable containing ObjectStateVariables of a specified class name.
            /// If the VariableList of the scope is stored in the ElementSetVariableListCache, the ClassName is used to qualify the variables.
            /// The ClassName is not required and if it is null, the SequenceAnalyzer will qualify cached variables as "AnonymousClass" variables - however if a new scope
            /// is created within this scope, it will attempt to infer the appropriate class for the list from which the new scope is created in order to provide the correct CacheKey to the new scope.
            /// </summary>
            public string ClassName { get; set; }
            /// <summary>
            /// //TODO: continue commenting here.
            /// </summary>
            public string CacheKey { get; set; }
            public ExecutionBranch RootBranch { get; set; }

            public StepScope Copy()
            {
                StepScope copy = new StepScope(ScopeName, ClassName, CacheKey, RootBranch);
                copy.VariableList.AddRange(VariableList);
                return copy;
            }
        }

        private ExecutionStack m_ExecutionStack;
        private Dictionary<string, StepScope> m_ScopeDictionary;
        private List<string> m_ScopeList;
        private StepScope m_CurrentScope;
        private Dictionary<string, List<StateVariableInfo>> m_ElementSetVariableListCache;

        #endregion

        #region Constructors

        public SequenceAnalyzer()
        {
            m_ScopeDictionary = new Dictionary<string, StepScope>();
            m_ScopeList = new List<string>();
            m_ElementSetVariableListCache = new Dictionary<string, List<StateVariableInfo>>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets a list of variables that are visible to a step.
        /// If a variable is persisted, it can be visible to the step even if it is declared after it in the sequence.
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        public List<StateVariableInfo> GetVariablesInStepScope(List<Step> sequence, Step step)
        {
            //First, perform a pass on the whole sequence.
            //This will populate the ElementSetVariableListCache so we have access to cache lists of persisted variables before they are declared.
            zFirstPassForPersistedElementSetCache(sequence);

            //Second pass to actually get the variable list
            List<StateVariableInfo> variableList = new List<StateVariableInfo>();
            List<string> scopeListAsOfTargetStep = null;
            Dictionary<string, StepScope> scopeDictionaryAsOfTargetStep = null;
            zAnalyzeSequence(sequence, currentStep =>
            {
                //If we have reached the target step, take a snapshot of the scopeList and scopeDictionary.
                //These snapshots are what will be used to compile the final list, but the sequence analysis will be
                //allowed to continue so that any persisted variables in lower scopes can be picked up.
                if (currentStep == step)
                {
                    scopeListAsOfTargetStep = m_ScopeList.ToList();
                    scopeDictionaryAsOfTargetStep = m_ScopeDictionary.ToDictionary(k => k.Key, v => v.Value.Copy());
                }

                //If we have reached or passed the target step, check if the current step is a persisted variable within the target step's scope visibility.
                //If so, add it to the appropriate scope. 
                if (scopeDictionaryAsOfTargetStep != null)
                {
                    zTryAddPersistedVariableToScope(currentStep, scopeDictionaryAsOfTargetStep);
                }
                return true;
            }, () =>
            {
                //Compile the final list
                variableList.AddRange(zCompileVariableList(scopeListAsOfTargetStep, scopeDictionaryAsOfTargetStep));
            });
            return variableList;
        }

        public List<string> GetListClassNamesInStepScope(List<Step> sequence, Step step, string objectSetListName)
        {
            //First, perform a pass on the whole sequence.
            //This will populate the ElementSetVariableListCache so we have access to cache lists of persisted variables before they are declared.
            zFirstPassForPersistedElementSetCache(sequence);

            //Second pass to actually get the class list
            List<string> classList = new List<string>();
            zAnalyzeSequence(sequence, currentStep =>
            {
                //If we have reached the target step, compile the class list and break out of the analysis.
                if (currentStep == step)
                {
                    zCompileClassList(classList, objectSetListName);
                    return false;
                }
                return true;
            }, null);
            return classList;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// This method executes the first pass to make sure all persisted ElementSet variable lists are known and cached.
        /// </summary>
        /// <param name="sequence"></param>
        private void zFirstPassForPersistedElementSetCache(List<Step> sequence)
        {
            Dictionary<string, List<StateVariableInfo>> persistedElementSetVariableListCache = null;
            zAnalyzeSequence(sequence, null, () =>
            {
                //When the analysis is done, make a copy of the ElementSetVariableListCache that only contains variables that are persisted.
                persistedElementSetVariableListCache = m_ElementSetVariableListCache
                    .Where(kvp => kvp.Value.Any(vi => vi.PersistenceMode == PersistenceMode.Persisted))
                    .ToDictionary(k => k.Key, v => v.Value
                        .Where(vi => vi.PersistenceMode == PersistenceMode.Persisted)
                        .ToList());
            });

            //After it is cleaned up from the first pass, set the global m_ElementSetVariableListCache to its persisted-only copy.
            m_ElementSetVariableListCache = persistedElementSetVariableListCache;
        }

        /// <summary>
        /// Main sequence analysis loop, or an "Analysis Pass". This method "passes" through the sequence step by step,
        /// keeps track of the sequence structurally (scope list, scope dictionary),
        /// and fires delegates for each step and for completion.
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="onStepScope"></param>
        /// <param name="onSequenceComplete"></param>
        private void zAnalyzeSequence(List<Step> sequence, Func<Step, bool> onStepScope, Action onSequenceComplete)
        {
            //Make sure this SequenceAnalyzer is not being used by another thread. It is not thread safe! All concurrent usage must be done on separate instances.
            if (m_ExecutionStack != null)
            {
                throw new InvalidOperationException("A zAnalyzeSequence call is already in progress. If you need to use this method concurrently, use a separate SequenceAnalyzer instance for each concurrent call.");
            }

            try
            {
                if (sequence.Count > 0)
                {
                    m_ExecutionStack = new ExecutionStack();
                    m_ExecutionStack.BranchEnded += m_ExecutionStack_BranchEnded;
                    m_ExecutionStack.SetSequence(sequence);

                    zSetCurrentScope(new StepScope(DataScope.RootScopeName, 
                        DataScope.RootScopeName, 
                        null, 
                        m_ExecutionStack.CurrentBranch));

                    do
                    {
                        if (onStepScope != null && !onStepScope(m_ExecutionStack.CurrentStep))
                        {
                            break;
                        }

                        if (m_ExecutionStack.CurrentStep is GetValueStep)
                        {
                            GetValueStep getValueStep = (GetValueStep)m_ExecutionStack.CurrentStep;
                            zAddVariableToScopeFromGetValueStep(getValueStep);
                        }

                        if (m_ExecutionStack.CurrentStep is DatabaseStep)
                        {
                            DatabaseStep databaseStep = (DatabaseStep)m_ExecutionStack.CurrentStep;
                            zAddVariablesToScopeFromDatabaseStep(databaseStep);
                        }

                        if (m_ExecutionStack.CurrentStep is GroupStep)
                        {
                            GroupStep groupStep = (GroupStep)m_ExecutionStack.CurrentStep;
                            if (groupStep.Steps.Count > 0)
                            {
                                m_ExecutionStack.SetNewBranch(groupStep.Steps);
                            }

                            if (groupStep.Iteration is ObjectSetIteration && groupStep.Iteration.IsSetIteration)
                            {
                                ObjectSetIteration objectSetIteration = (ObjectSetIteration)groupStep.Iteration;
                                
                                if (objectSetIteration is ElementSetIteration)
                                {
                                    ElementSetIteration elementSetIteration = (ElementSetIteration)objectSetIteration;
                                    zAddVariableToScopeFromElementSetIteration(elementSetIteration);
                                }

                                if (groupStep.Steps.Count > 0)
                                {
                                    string newScopeCacheKey = zGetCacheKey(m_CurrentScope.ScopeName, objectSetIteration.ObjectSetListName);
                                    StepScope newScope = new StepScope(objectSetIteration.ObjectSetScopeName,
                                        objectSetIteration.ObjectSetClassName,
                                        newScopeCacheKey,
                                        m_ExecutionStack.PendingBranch);

                                    if (objectSetIteration is DataSetIteration)
                                    {
                                        List<StateVariableInfo> cacheList;
                                        if (newScope.CacheKey != null && m_ElementSetVariableListCache.TryGetValue(newScope.CacheKey, out cacheList))
                                        {
                                            foreach (StateVariableInfo cachedVariable in cacheList)
                                            {
                                                if (newScope.ClassName == null || DataUtils.GetVariableNameScope(cachedVariable.StateVariableName) == newScope.ClassName)
                                                {
                                                    StateVariableInfo variableForNewScope = zRescopeVariable(cachedVariable, objectSetIteration.ObjectSetScopeName);
                                                    if (!newScope.VariableList.Contains(variableForNewScope))
                                                    {
                                                        newScope.VariableList.Add(variableForNewScope);
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    zSetCurrentScope(newScope);
                                }
                            }
                        }
                    } while (m_ExecutionStack.MoveNext());
                }

                if (onSequenceComplete != null)
                {
                    onSequenceComplete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                zCleanup();
            }
        }

        private void m_ExecutionStack_BranchEnded(object sender, BranchEndedEventArgs e)
        {
            if (m_CurrentScope.RootBranch == e.Branch)
            {
                zRemoveCurrentScope();
            }
        }

        private List<StateVariableInfo> zCompileVariableList(List<string> scopeList, Dictionary<string, StepScope> scopeDictionary)
        {
            List<StateVariableInfo> variableList = new List<StateVariableInfo>();
            if (scopeList != null && scopeDictionary != null)
            {
                foreach (string scopeName in scopeList)
                {
                    StepScope stepScope;
                    if (scopeDictionary.TryGetValue(scopeName, out stepScope))
                    {
                        foreach (StateVariableInfo variableInfo in stepScope.VariableList)
                        {
                            variableList.Add(variableInfo);
                        }
                    }
                }
            }
            return variableList;
        }

        private void zCompileClassList(List<string> classList, string objectSetListName)
        {
            string listCacheKey = zGetCacheKey(m_CurrentScope.ScopeName, objectSetListName);
            List<StateVariableInfo> cacheList;
            if (listCacheKey != null && m_ElementSetVariableListCache.TryGetValue(listCacheKey, out cacheList))
            {
                foreach (StateVariableInfo variableInfo in cacheList)
                {
                    string className = DataUtils.GetVariableNameScope(variableInfo.StateVariableName);
                    if (!classList.Contains(className))
                    {
                        classList.Add(className);
                    }
                }
            }
        }

        private void zAddVariableToScopeFromGetValueStep(GetValueStep getValueStep)
        {
            zAddVariableToScope(m_CurrentScope.ScopeName,
                new StateVariableInfo(getValueStep.StateVariable, DataType.String, getValueStep.PersistenceMode)); //TODO: get actual datatype
        }

        private void zAddVariablesToScopeFromDatabaseStep(DatabaseStep databaseStep)
        {
            foreach (OutputParameterMap parameterMap in databaseStep.OutputParameterMapping)
            {
                zAddVariableToScope(m_CurrentScope.ScopeName,
                    new StateVariableInfo(parameterMap.StateVariable, DataType.String, parameterMap.PersistenceMode)); //TODO: get actual datatype
            }
            if (databaseStep.ResultMapping is ScalarResultMapping)
            {
                ScalarResultMapping scalarResultMapping = (ScalarResultMapping)databaseStep.ResultMapping;
                zAddVariableToScope(m_CurrentScope.ScopeName,
                    new StateVariableInfo(scalarResultMapping.StateVariable, DataType.String, scalarResultMapping.PersistenceMode)); //TODO: get actual datatype
            }
            if (databaseStep.ResultMapping is TableResultMapping)
            {
                TableResultMapping tableResultMapping = (TableResultMapping)databaseStep.ResultMapping;
                StepScope tempScopeForTableResults = null;
                if (tableResultMapping.ObjectSetClassName != null && tableResultMapping.ObjectSetListName != null)
                {
                    zAddVariableToScope(m_CurrentScope.ScopeName,
                        new StateVariableInfo(tableResultMapping.ObjectSetListName, DataType.List, tableResultMapping.PersistenceMode));

                    string tempScopeCacheKey = zGetCacheKey(m_CurrentScope.ScopeName, tableResultMapping.ObjectSetListName);
                    tempScopeForTableResults = new StepScope(Guid.NewGuid().ToString(),
                        tableResultMapping.ObjectSetClassName,
                        tempScopeCacheKey,
                        null);
                    zSetCurrentScope(tempScopeForTableResults);
                }
                foreach (TableResultMap tableResultMap in tableResultMapping.TableMapping)
                {
                    zAddVariableToScope(m_CurrentScope.ScopeName,
                        new StateVariableInfo(tableResultMap.StateVariable, DataType.String, tableResultMapping.PersistenceMode)); //TODO: get actual datatype
                }
                if (tempScopeForTableResults != null)
                {
                    zRemoveCurrentScope();
                }
            }
        }

        private void zAddVariableToScopeFromElementSetIteration(ElementSetIteration elementSetIteration)
        {
            zAddVariableToScope(m_CurrentScope.ScopeName,
                new StateVariableInfo(elementSetIteration.ObjectSetListName, DataType.List, elementSetIteration.PersistenceMode));
        }

        /// <summary>
        /// Adds a variable to its scope's VariableList, and if the scope has a cache key then it adds it to the ElementSetVariableListCache too.
        /// </summary>
        /// <param name="currentScope"></param>
        /// <param name="variableInfo"></param>
        private void zAddVariableToScope(string currentScope, StateVariableInfo variableInfo)
        {
            //First, determine the scope-qualified variable name
            string scopeNamePart;
            string variableNamePart;
            DataUtils.ParseStateVariableName(currentScope, variableInfo.StateVariableName, out scopeNamePart, out variableNamePart);
            //Replace the variableInfo's variable name with the scope-qualified name
            variableInfo.StateVariableName = String.Format("{0}.{1}", scopeNamePart, variableNamePart);
            //Next, try to get the scope of the variable. Do nothing if it does not exist in the current Scope Dictionary.
            StepScope scope;
            if (m_ScopeDictionary.TryGetValue(scopeNamePart, out scope))
            {
                //Add the variable to the scope's VariableList if it is not already there
                if (!scope.VariableList.Contains(variableInfo))
                {
                    scope.VariableList.Add(variableInfo);
                }

                //Add to cache for this scope if CacheKey is set
                if (scope.CacheKey != null)
                {
                    List<StateVariableInfo> cacheList;
                    //Create the cache entry for this scope's cache key if it does not exist
                    if (!m_ElementSetVariableListCache.TryGetValue(scope.CacheKey, out cacheList))
                    {
                        cacheList = new List<StateVariableInfo>();
                        m_ElementSetVariableListCache.Add(scope.CacheKey, cacheList);
                    }

                    //If the scope specifies a class name, cache the variable scoped to that class. Otherwise cache it scoped to the default cache key scope, "AnonymousClass".
                    StateVariableInfo cacheListEntry = zRescopeVariable(variableInfo, scope.ClassName ?? DefaultCacheKeyScope);
                    //Add the class-qualified variable to the scope's cache entry if it is not already there.
                    if (!cacheList.Contains(cacheListEntry))
                    {
                        cacheList.Add(cacheListEntry);
                    }
                }
            }
        }

        /// <summary>
        /// Attempts to get a key for the ElementSetVariableListCache for a List variable that is being used to create a new scope.
        /// </summary>
        /// <param name="currentScope"></param>
        /// <param name="variableName"></param>
        /// <returns></returns>
        private string zGetCacheKey(string currentScope, string variableName)
        {
            //First, determine the scope-qualified variable name
            string scopeNamePart;
            string variableNamePart;
            DataUtils.ParseStateVariableName(currentScope, variableName, out scopeNamePart, out variableNamePart);
            //Next, try to get the scope of the variable. Return null if it does not exist in the current Scope Dictionary.
            StepScope scope;
            if (m_ScopeDictionary.TryGetValue(scopeNamePart, out scope))
            {
                string cacheKey = null;
                //Next, if the scope has a class specified, simply rescope the variable to that class and return.
                if (scope.ClassName != null)
                {
                    cacheKey = zRescopeVariableName(variableNamePart, scope.ClassName);
                }
                //If the scope does not have a class specified but it has a cache key which exists in the ElementSetVariableListCache, 
                //search the scope's cached variable list for a class-qualified instance of the variable.
                else if (scope.CacheKey != null && m_ElementSetVariableListCache.ContainsKey(scope.CacheKey))
                {
                    cacheKey = zResolveCacheKeyFromScopeCacheList(scope, variableNamePart);
                }
                //Finally if we cannot determine a class-qualified cache key, return a key qualified by the default cache key scope, "AnonymousClass".
                if (cacheKey == null)
                {
                    cacheKey = zRescopeVariableName(variableNamePart, DefaultCacheKeyScope);
                }
                return cacheKey;
            }
            return null;
        }

        private string zResolveCacheKeyFromScopeCacheList(StepScope scope, string variableNamePart)
        {
            List<StateVariableInfo> scopeCache = m_ElementSetVariableListCache[scope.CacheKey];
            foreach (StateVariableInfo scopeCacheVariable in scopeCache)
            {
                string tmpScopeNamePart, tmpVariableNamePart;
                DataUtils.ParseStateVariableName(scope.ScopeName, scopeCacheVariable.StateVariableName, out tmpScopeNamePart, out tmpVariableNamePart);
                if (tmpVariableNamePart == variableNamePart)
                {
                    return scopeCacheVariable.StateVariableName;
                }
            }
            return null;
        }

        private StateVariableInfo zRescopeVariable(StateVariableInfo variableInfo, string newScope)
        {
            return new StateVariableInfo(
                zRescopeVariableName(variableInfo.StateVariableName, newScope),
                variableInfo.DataType,
                variableInfo.PersistenceMode);
        }
        private string zRescopeVariableName(string variableName, string newScope)
        {
            return String.Format("{0}.{1}", newScope, DataUtils.GetUnscopedVariableName(variableName));
        }

        private void zCleanup()
        {
            m_ElementSetVariableListCache.Clear();

            while (m_CurrentScope != null)
            {
                zRemoveCurrentScope();
            }

            if (m_ExecutionStack != null)
            {
                m_ExecutionStack.Reset();
                m_ExecutionStack.BranchEnded -= m_ExecutionStack_BranchEnded;
                m_ExecutionStack = null;
            }
        }

        private void zSetCurrentScope(StepScope newScope)
        {
            m_CurrentScope = newScope;
            m_ScopeDictionary.Add(newScope.ScopeName, newScope);
            m_ScopeList.Add(newScope.ScopeName);
        }

        private void zRemoveCurrentScope()
        {
            m_ScopeList.Remove(m_CurrentScope.ScopeName);
            m_ScopeDictionary.Remove(m_CurrentScope.ScopeName);
            m_CurrentScope.VariableList.Clear();
            m_CurrentScope.RootBranch = null;

            m_CurrentScope = m_ScopeList.Count > 0 ? m_ScopeDictionary[m_ScopeList.Last()] : null;
        }

        private void zTryAddPersistedVariableToScope(Step step, Dictionary<string, StepScope> scopeDictionaryAsOfTargetStep)
        {
            //Check if step sets a persisted variable
            StateVariableInfo variableInfo = null;
            if (step is GetValueStep)
            {
                GetValueStep getValueStep = (GetValueStep)step;
                if (getValueStep.PersistenceMode == PersistenceMode.Persisted)
                {
                    variableInfo = new StateVariableInfo(getValueStep.StateVariable, DataType.String, getValueStep.PersistenceMode); //TODO: get actual datatype
                }
            }
            if (step is GroupStep)
            {
                GroupStep groupStep = (GroupStep)step;
                if (groupStep.Iteration is ElementSetIteration)
                {
                    ElementSetIteration elementSetIteration = (ElementSetIteration)groupStep.Iteration;
                    if (elementSetIteration.PersistenceMode == PersistenceMode.Persisted)
                    {
                        variableInfo = new StateVariableInfo(elementSetIteration.ObjectSetListName, DataType.List, elementSetIteration.PersistenceMode);
                    }
                }
            }

            if (variableInfo != null)
            {
                //If step sets a persisted variable, check if it is within the target step's scope visbility
                string scopeNamePart;
                string variableNamePart;
                DataUtils.ParseStateVariableName(m_CurrentScope.ScopeName, variableInfo.StateVariableName, out scopeNamePart, out variableNamePart);
                variableInfo.StateVariableName = String.Format("{0}.{1}", scopeNamePart, variableNamePart);
                StepScope scopeAsOfAnalyzer, scopeAsOfTargetStep;
                if (m_ScopeDictionary.TryGetValue(scopeNamePart, out scopeAsOfAnalyzer) && scopeDictionaryAsOfTargetStep.TryGetValue(scopeNamePart, out scopeAsOfTargetStep))
                {
                    if (scopeNamePart == DataScope.RootScopeName ||
                        (scopeAsOfTargetStep.CacheKey == scopeAsOfAnalyzer.CacheKey &&
                            (scopeAsOfTargetStep.ClassName == null || scopeAsOfTargetStep.ClassName == scopeAsOfAnalyzer.ClassName)))
                    {
                        //If step sets a persisted variable and it is within the target step's scope visbility, add it to the appropriate scope's variable list
                        if (!scopeAsOfTargetStep.VariableList.Contains(variableInfo))
                        {
                            scopeAsOfTargetStep.VariableList.Add(variableInfo);
                        }
                    }
                }
            }
        }

        #endregion
    }
}
