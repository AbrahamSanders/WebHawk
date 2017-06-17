using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using UBoat.Utils;
using UBoat.Utils.Threading;
using UBoat.Utils.DOM;
using UBoat.WebHawk.Controller.Model.Data;
using UBoat.WebHawk.Controller.Model.Automation;
using UBoat.WebHawk.Controller.Model.Automation.Steps;
using UBoat.WebHawk.Controller.Model.Automation.Iterations;
using UBoat.WebHawk.Controller.Automation.Iterators;
using UBoat.WebHawk.Controller.Data;

namespace UBoat.WebHawk.Controller.Automation.StepExecutors
{
    internal class GroupStepExecutor : StepExecutor<GroupStep>
    {
        protected override void zExecuteStep()
        {
            if (!zCreateIterator(m_Step.Iteration))
            {
                zCompleteGroupStep(null);
            }
        }

        private bool zCreateIterator(Iteration iteration)
        {
            if (iteration is FixedIteration)
            {
                zCreateFixedIterator((FixedIteration)iteration);
                return true;
            }
            if (iteration is ElementSetIteration)
            {
                zCreateElementSetIterator((ElementSetIteration)iteration);
                return true;
            }
            if (iteration is DataSetIteration)
            {
                zCreateDataSetIterator((DataSetIteration)iteration);
                return true;
            }
            return false;
        }

        #region FixedIteration

        private void zCreateFixedIterator(FixedIteration iteration)
        {
            FixedIterator iterator = new FixedIterator(iteration);
            zCompleteGroupStep(iterator);
        }

        #endregion

        #region ElementSetIteration

        private void zCreateElementSetIterator(ElementSetIteration iteration)
        {
            ListStateVariable listStateVariable = null;
            if (iteration.IsSetIteration)
            {
                listStateVariable = (ListStateVariable)CurrentScope.DataScope.GetStateVariable(iteration.ObjectSetListName);
                if (listStateVariable == null)
                {
                    listStateVariable = new ListStateVariable(DataUtils.GetUnscopedVariableName(iteration.ObjectSetListName), iteration.PersistenceMode, new List<IStateVariable>());
                    CurrentScope.DataScope.SetStateVariable(iteration.ObjectSetListName, listStateVariable);
                }
                listStateVariable.IncludeInXML = iteration.IncludeInXML;
            }
            ElementSetIterator iterator = new ElementSetIterator(iteration, listStateVariable);

            ElementIdentifier containerIdentifier = zGetElementSetContainer(iteration);
            ThreadingUtils.InvokeControlAction(m_Context.BrowserHelper.Browser, ctl =>
            {
                if (iteration.ElementType == Model.Automation.ElementType.Static)
                {
                    List<HtmlElement> containerElements = m_Context.BrowserHelper.FindElements(containerIdentifier, CurrentScope.ElementSetIteratorItem);
                    iterator.SetElements(containerElements);
                    zCompleteGroupStep(iterator);
                }
                else
                {
                    m_Context.BrowserHelper.PollElements(containerIdentifier, CurrentScope.ElementSetIteratorItem, iteration.PollingTimeout.Value, containerElements =>
                    {
                        iterator.SetElements(containerElements);
                        zCompleteGroupStep(iterator);
                    });
                }
            });
        }

        private ElementIdentifier zGetElementSetContainer(ElementSetIteration iteration)
        {
            ElementIdentifier containerIdentifier = null;
            if (CurrentScope.ElementSetContainerIdentifier != null)
            {
                containerIdentifier = iteration.ElementSetContainer.RelativeTo(CurrentScope.ElementSetContainerIdentifier);
            }
            else
            {
                containerIdentifier = iteration.ElementSetContainer;
            }
            return containerIdentifier;
        }

        #endregion

        #region DataSetIteration

        private void zCreateDataSetIterator(DataSetIteration iteration)
        {
            DataSetIterator iterator = new DataSetIterator(iteration);
            ListStateVariable listStateVariable = (ListStateVariable)CurrentScope.DataScope.GetStateVariable(iteration.ObjectSetListName);
            iterator.SetDataSet(listStateVariable.Value.OfType<ObjectStateVariable>());
            zCompleteGroupStep(iterator);
        }

        #endregion

        protected void zCompleteGroupStep(IIterator iterator)
        {
            if (m_Step.Steps.Count > 0)
            {
                m_Context.ExecutionStack.SetNewBranch(m_Step.Steps, iterator);
            }
            else if (iterator is ElementSetIterator)
            {
                ((ElementSetIterator)iterator).RemoveCurrentObjectStateVariable();
            }
            zCompleteStep(StepResult.Success);
        }
    }
}
