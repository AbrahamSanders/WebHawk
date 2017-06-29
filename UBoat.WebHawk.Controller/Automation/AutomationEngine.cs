using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using UBoat.Utils;
using UBoat.Utils.Threading;
using UBoat.Utils.DOM;
using UBoat.WebHawk.Controller.Automation.StepExecutors;
using UBoat.WebHawk.Controller.Model.Automation;
using UBoat.WebHawk.Controller.Model.Automation.Steps;
using UBoat.WebHawk.Controller.Conditional;
using UBoat.WebHawk.Controller.Data;


namespace UBoat.WebHawk.Controller.Automation
{
    public class AutomationEngine : IDisposable
    {
        private bool m_Disposed;
        private ExecutionContext m_Context;
        private StepExecutorProvider m_StepExecutorProvider;
        private List<Step> m_Sequence;
        private bool m_Executing;
        private int m_ExecutionScope;
        private bool m_ResetRequired;
        private Thread m_ExecutionThread;
        private ExecutionState m_ExecutionState;

        public DataContext DataContext
        {
            get
            {
                return m_Context.DataContext;
            }
        }

        public List<Step> Sequence
        {
            get
            {
                return m_Sequence;
            }
        }

        public int CurrentPosition
        {
            get
            {
                return m_Context.ExecutionStack.CurrentPosition + 1;
            }
        }

        public Step CurrentStep
        {
            get
            {
                return m_Context.ExecutionStack.CurrentStep;
            }
        }

        public AutomationEngine(WebBrowser browser)
        {
            m_StepExecutorProvider = new StepExecutorProvider();
            m_Context = new ExecutionContext(new WebBrowserHelper(browser));
        }

        public void StopExecution()
        {
            if (m_ExecutionState != ExecutionState.Fail)
            {
                m_ExecutionState = ExecutionState.ManualStop;
            }
        }

        public void SetSequence(List<Step> sequence)
        {
            m_Context.ExecutionStack.SetSequence(sequence);
            m_Context.DataContext.Clear();
            m_Sequence = sequence;
            m_ResetRequired = false;
        }

        public void ResetSequence()
        {
            m_Context.ExecutionStack.Reset();
            m_Context.DataContext.Clear();
            m_ResetRequired = false;
        }

        public void ExecuteSequence()
        {
            ExecuteSequence(Int32.MaxValue);
        }
        public void ExecuteSequence(int executionScope)
        {
            if (executionScope < 1)
            {
                throw new ArgumentException("executionScope must have a value of 1 or greater.");
            }
            if (m_Sequence == null)
            {
                throw new Exception("No sequence has been set. Call SetSequence to set a sequence before calling ExecuteSequence.");
            }
            if (m_Executing)
            {
                throw new InvalidOperationException("Another sequence is already being executed by this AutomationEngine instance.");
            }
            m_Executing = true;

            m_ExecutionState = ExecutionState.Success;
            m_ExecutionScope = executionScope;
            bool wasReset = false;
            if (m_ResetRequired || m_ExecutionScope <= CurrentPosition)
            {
                ResetSequence();
                wasReset = true;
            }

            zOnExecutionBegin(new ExecutionBeginEventArgs(wasReset));

            m_ExecutionThread = new Thread(zExecuteSequenceLoop);
            m_ExecutionThread.IsBackground = true;
            m_ExecutionThread.Start();
        }

        private void zExecuteSequenceLoop()
        {
            bool continueExecuting = true;
            if (CurrentPosition > 1)
            {
                continueExecuting = zNextStep();
            }

            while (continueExecuting)
            {
                zExecuteStep();
                continueExecuting = zNextStep();
            }
            zOnExecutionComplete(new ExecutionCompleteEventArgs(m_ExecutionState));
            m_Executing = false;
        }

        private void zExecuteStep()
        {
            zOnStepBegin(new StepEventArgs(CurrentStep));

            IStepExecutor stepExecutor = m_StepExecutorProvider.GetStepExecutor(CurrentStep);
            stepExecutor.LoadScope(CurrentStep, m_Context);

            StepResult result = stepExecutor.ExecuteStep();

            if (result == StepResult.Failed)
            {
                switch (CurrentStep.FailureScope)
                {
                    case StepFailureScope.Step:
                        //Do nothing
                        break;
                    case StepFailureScope.Iteration:
                        m_Context.ExecutionStack.SkipIteration();
                        break;
                    case StepFailureScope.Group:
                        m_Context.ExecutionStack.BreakBranch();
                        break;
                    case StepFailureScope.Sequence:
                        m_ExecutionState = ExecutionState.Fail;
                        break;
                }
            }

            zOnStepComplete(new StepCompleteEventArgs(CurrentStep, result));
        }

        private bool zNextStep()
        {
            bool canMoveNext = m_Context.ExecutionStack.PeekNext();
            if (m_ExecutionState != ExecutionState.Success || CurrentPosition >= m_ExecutionScope || !canMoveNext)
            {
                m_ResetRequired = !canMoveNext || m_ExecutionState == ExecutionState.Fail;
                return false;
            }
            else
            {
                m_Context.ExecutionStack.MoveNext();
                return true;
            }
        }

        public event EventHandler<ExecutionBeginEventArgs> ExecutionBegin;
        protected void zOnExecutionBegin(ExecutionBeginEventArgs e)
        {
            EventHandler<ExecutionBeginEventArgs> evnt = ExecutionBegin;
            if (evnt != null)
            {
                try
                {
                    evnt(this, e);
                }
                catch (Exception ex)
                {
                    //TODO: log exception
                }
            }
        }

        public event EventHandler<ExecutionCompleteEventArgs> ExecutionComplete;
        protected void zOnExecutionComplete(ExecutionCompleteEventArgs e)
        {
            EventHandler<ExecutionCompleteEventArgs> evnt = ExecutionComplete;
            if (evnt != null)
            {
                try
                {
                    evnt(this, e);
                }
                catch (Exception ex)
                {
                    //TODO: log exception
                }
            }
        }

        public event EventHandler<StepEventArgs> StepBegin;
        protected void zOnStepBegin(StepEventArgs e)
        {
            EventHandler<StepEventArgs> evnt = StepBegin;
            if (evnt != null)
            {
                try
                {
                    evnt(this, e);
                }
                catch (Exception ex)
                {
                    //TODO: log exception
                }
            }
        }

        public event EventHandler<StepCompleteEventArgs> StepComplete;
        protected void zOnStepComplete(StepCompleteEventArgs e)
        {
            EventHandler<StepCompleteEventArgs> evnt = StepComplete;
            if (evnt != null)
            {
                try
                {
                    evnt(this, e);
                }
                catch (Exception ex)
                {
                    //TODO: log exception
                }
            }
        }

        public void Dispose()
        {
            if (!m_Disposed)
            {
                if (m_ExecutionThread != null)
                {
                    if (m_ExecutionThread.ThreadState != ThreadState.Unstarted)
                    {
                        if (m_ExecutionThread.ThreadState != ThreadState.Stopped)
                        {
                            //Note: This abort is done because joining on the thread alone will not work since the thread marshalls to the UI thread for WebBrowser stuff -
                            //      if the UI thread blocks on the join, the marshalling will get stuck and cause a deadlock.
                            //      Therefore, if the class instance is being disposed and the thread is not done, to hell with the thread.
                            //      Normally, nothing should ever call Dispose WHILE a sequence is running except for application termination in which case the abort is acceptable.
                            m_ExecutionThread.Abort();
                        }
                        m_ExecutionThread.Join();
                    }
                    m_ExecutionThread = null;
                }
                if (m_StepExecutorProvider != null)
                {
                    m_StepExecutorProvider.Dispose();
                    m_StepExecutorProvider = null;
                }
                m_Context.DataContext.Clear();
                m_Context.ExecutionStack.Dispose();
                m_Sequence = null;

                m_Disposed = true;
            }
        }
    }
}
