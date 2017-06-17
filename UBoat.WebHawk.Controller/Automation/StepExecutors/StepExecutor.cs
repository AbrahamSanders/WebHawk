using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.Utils;
using UBoat.Utils.DOM;
using UBoat.WebHawk.Controller.Automation.Iterators;
using UBoat.WebHawk.Controller.Conditional;
using UBoat.WebHawk.Controller.Data;
using UBoat.WebHawk.Controller.Model.Automation.Steps;

namespace UBoat.WebHawk.Controller.Automation.StepExecutors
{
    internal abstract class StepExecutor<T> : IStepExecutor where T : Step
    {
        protected T m_Step;
        protected ExecutionContext m_Context;
        private AutoResetEvent m_StepWaitHandle;
        private StepResult m_Result;

        protected StepExecutorScope CurrentScope { get; private set; }

        protected StepExecutor()
        {
            m_StepWaitHandle = new AutoResetEvent(false);
        }

        public StepResult ExecuteStep()
        {
            if (m_Step == null)
            {
                throw new InvalidOperationException("A scope is not loaded. Call LoadScope to load the scope before executing.");
            }

            try
            {
                if (m_Context.ConditionalEngine.CheckCondition(m_Step.Condition, CurrentScope.DataScope))
                {
                    zExecuteStep();
                }
                else
                {
                    zCompleteStep(StepResult.Skipped);
                }

                if (!m_StepWaitHandle.WaitOne(30000)) //TODO: make this configurable.
                {
                    throw new TimeoutException("Step execution timed out.");
                }
            }
            catch (Exception ex)
            {
                //TODO: log/report/do something with this error.
                m_Result = StepResult.Failed;
            }
            finally
            {
                zUnloadScope();
            }
            
            return m_Result;
        }

        public void LoadScope(Step step, ExecutionContext context)
        {
            if (m_Step != null)
            {
                throw new InvalidOperationException("A scope is already loaded. Call ExecuteStep first to execute the step and unload the scope.");
            }
            m_Step = (T)step;
            m_Context = context;

            this.CurrentScope = StepExecutorScope.CreateCurrentStepExecutorScope(context);
        }

        private void zUnloadScope()
        {
            if (this.CurrentScope != null)
            {
                this.CurrentScope.Dispose();
                this.CurrentScope = null;
            }
            m_Step = null;
            m_Context = null;
        }

        protected abstract void zExecuteStep();

        protected void zCompleteStep(StepResult result)
        {
            if (result == StepResult.Failed && m_Step.FailureScope != StepFailureScope.Step && CurrentScope.ElementSetIterator != null)
            {
                CurrentScope.ElementSetIterator.RemoveCurrentObjectStateVariable();
            }

            m_Result = result;
            m_StepWaitHandle.Set();
        }
    }
}
