using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.Utils.DOM;
using UBoat.WebHawk.Controller.Automation.Iterators;
using UBoat.WebHawk.Controller.Data;

namespace UBoat.WebHawk.Controller.Automation.StepExecutors
{
    internal class StepExecutorScope : IDisposable
    {
        #region Static Initializer

        public static StepExecutorScope CreateCurrentStepExecutorScope(ExecutionContext executionContext)
        {
            StepExecutorScope scope = new StepExecutorScope();
            scope.DataScope = new DataScope();
            scope.DataScope.Add(DataScope.RootScopeName, executionContext.DataContext.StateVariables);

            List<IIterator> activeIterators = executionContext.ExecutionStack.GetActiveIterators();
            for (int x = 0; x < activeIterators.Count; x++)
            {
                IIterator activeIterator = activeIterators[x];
                if (activeIterator is IObjectSetIterator)
                {
                    IObjectSetIterator objectSetIterator = (IObjectSetIterator)activeIterator;
                    bool isCurrentBranchIterator = x == (activeIterators.Count - 1);

                    if (isCurrentBranchIterator && objectSetIterator is ElementSetIterator)
                    {
                        scope.ElementSetIterator = (ElementSetIterator)objectSetIterator;
                    }
                    if (objectSetIterator.CurrentObjectStateVariable != null)
                    {
                        scope.DataScope.Add(objectSetIterator.ObjectSetIteration.ObjectSetScopeName, objectSetIterator.CurrentObjectStateVariable.Value);
                    }
                }
            }
            return scope;
        }

        #endregion

        public DataScope DataScope { get; set; }
        public ElementSetIterator ElementSetIterator { get; set; }

        public HtmlElement ElementSetIteratorItem
        {
            get
            {
                return this.ElementSetIterator != null ? this.ElementSetIterator.CurrentItem : null;
            }
        }

        public ElementIdentifier ElementSetContainerIdentifier
        {
            get
            {
                return this.ElementSetIterator != null ? this.ElementSetIterator.Iteration.ElementSetContainer : null;
            }
        }

        public void Dispose()
        {
            this.ElementSetIterator = null;
            if (this.DataScope != null)
            {
                this.DataScope.Dispose();
                this.DataScope = null;
            }
        }
    }
}
