using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.Utils;
using UBoat.Utils.DataAccess;
using UBoat.WebHawk.Controller.Data;
using UBoat.WebHawk.Controller.Model.Automation.Steps;
using UBoat.WebHawk.Controller.Model.Data;
using UBoat.WebHawk.Controller.Model.Database;

namespace UBoat.WebHawk.Controller.Automation.StepExecutors
{
    internal class DatabaseStepExecutor : StepExecutor<DatabaseStep>
    {
        protected override void zExecuteStep()
        {
            string command = DataUtils.ApplyStateVariablesToString(m_Step.Command, CurrentScope.DataScope, m_Step.TrimVariableValueWhitespace);
            
            using (IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(m_Step.ConnectionType, m_Step.ConnectionString))
            {
                DataAccessResult result;
                if (m_Step.ResultMapping is ScalarResultMapping)
                {
                    DataAccessResult<object> scalarResult = dataAccess.ExecuteScalar(m_Step.CommandType, command, paramBuilder => zCreateInputParameters(paramBuilder));
                    zReadScalarResult(scalarResult.Value);
                    result = scalarResult;
                }
                else if (m_Step.ResultMapping is TableResultMapping)
                {
                    result = dataAccess.ExecuteQueryReader(m_Step.CommandType, command,
                                paramBuilder => zCreateInputParameters(paramBuilder),
                                reader => zReadTableResult(reader));
                }
                else
                {
                    result = dataAccess.ExecuteNonQuery(m_Step.CommandType, command, paramBuilder => zCreateInputParameters(paramBuilder));
                }
                zReadOutputParameters(result.OutputParameters);
            }

            zCompleteStep(StepResult.Success);
        }

        private List<DbParameter> zCreateInputParameters(ParameterBuilder paramBuilder)
        {
            List<DbParameter> parameterList = new List<DbParameter>();
            foreach (InputParameterMap parameterMap in m_Step.InputParameterMapping)
            {
                string parameterValue = DataUtils.ApplyStateVariablesToString(parameterMap.ParameterValue, CurrentScope.DataScope, parameterMap.TrimVariableValueWhitespace);
                parameterList.Add(paramBuilder.CreateParameter(parameterMap.ParameterName, parameterValue));
            }
            return parameterList;
        }

        private void zReadScalarResult(object scalarResult)
        {
            ScalarResultMapping scalarResultMapping = (ScalarResultMapping)m_Step.ResultMapping;
            CurrentScope.DataScope.SetStateVariable(scalarResultMapping.StateVariable,
                        new StateVariable<string>(DataUtils.GetUnscopedVariableName(scalarResultMapping.StateVariable),
                            DataType.String,
                            scalarResultMapping.XMLFieldOutputMode,
                            scalarResultMapping.PersistenceMode,
                            Convert.ToString(scalarResult)));
        }

        private void zReadTableResult(DataReaderHelper reader)
        {
            TableResultMapping tableResultMapping = (TableResultMapping)m_Step.ResultMapping;

            ListStateVariable listStateVariable = null;
            if (tableResultMapping.ObjectSetListName != null && tableResultMapping.ObjectSetClassName != null)
            {
                //TODO: there is similar logic in GroupStepExecutor.zCreateElementSetIterator - refactor into common method on DataScope.
                listStateVariable = (ListStateVariable)CurrentScope.DataScope.GetStateVariable(tableResultMapping.ObjectSetListName);
                if (listStateVariable == null)
                {
                    listStateVariable = new ListStateVariable(DataUtils.GetUnscopedVariableName(tableResultMapping.ObjectSetListName), tableResultMapping.PersistenceMode, new List<IStateVariable>());
                    CurrentScope.DataScope.SetStateVariable(tableResultMapping.ObjectSetListName, listStateVariable);
                }
                listStateVariable.IncludeInXML = tableResultMapping.IncludeInXML;
            }

            int resultCount = 1;
            while (reader.Read())
            {
                ObjectStateVariable objectStateVariable = null;
                if (listStateVariable != null)
                {
                    string listItemName = String.Format("{0}{1}", tableResultMapping.ObjectSetClassName, resultCount);
                    objectStateVariable = new ObjectStateVariable(listItemName, tableResultMapping.ObjectSetClassName, tableResultMapping.PersistenceMode, new Dictionary<string, IStateVariable>());
                    listStateVariable.Value.Add(objectStateVariable);
                }

                foreach (TableResultMap tableMap in tableResultMapping.TableMapping)
                {
                    //TODO: for now all data is being converted to string. Once we are doing something with the variable type system,
                    //      type the variables appropriately when reading them in.
                    object value = reader.GetNullableValue(tableMap.ColumnName);
                    IStateVariable stateVariable = new StateVariable<string>(DataUtils.GetUnscopedVariableName(tableMap.StateVariable),
                            DataType.String,
                            tableMap.XMLFieldOutputMode,
                            tableMap.PersistenceMode,
                            Convert.ToString(value));
                    if (objectStateVariable != null && stateVariable.Name == tableMap.StateVariable)
                    {
                        //stateVariable.Name == tableMap.StateVariable checks that tableMap.StateVariable has no explicit scope.
                        //If it has an explicit scope, stateVariable has to be set through CurrentScope.DataScope in the else block.
                        objectStateVariable.Value.Add(tableMap.StateVariable, stateVariable);
                    }
                    else
                    {
                        CurrentScope.DataScope.SetStateVariable(tableMap.StateVariable, stateVariable);
                    }
                }

                resultCount++;
            }
        }

        private void zReadOutputParameters(IEnumerable<DbParameter> outputParameters)
        {
            foreach (DbParameter parameter in outputParameters)
            {
                OutputParameterMap parameterMap;
                if (parameter.Direction == ParameterDirection.ReturnValue)
                {
                    parameterMap = m_Step.OutputParameterMapping.FirstOrDefault(opm => opm.ParameterType == OutputParameterType.Return);
                }
                else
                {
                    parameterMap = m_Step.OutputParameterMapping.FirstOrDefault(opm => opm.ParameterName == parameter.ParameterName);
                }
                if (parameterMap != null)
                {
                    CurrentScope.DataScope.SetStateVariable(parameterMap.StateVariable,
                        new StateVariable<string>(DataUtils.GetUnscopedVariableName(parameterMap.StateVariable),
                            DataType.String,
                            parameterMap.XMLFieldOutputMode,
                            parameterMap.PersistenceMode,
                            Convert.ToString(parameter.Value)));
                }
            }
        }
    }
}
