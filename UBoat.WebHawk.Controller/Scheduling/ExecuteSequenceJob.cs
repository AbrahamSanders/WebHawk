using Common.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UBoat.Utils;
using UBoat.Utils.Common;
using UBoat.Utils.Threading;
using UBoat.WebHawk.Controller.Automation;
using UBoat.WebHawk.Controller.Data;
using UBoat.WebHawk.Controller.Model.Automation;
using UBoat.WebHawk.Controller.Model.Scheduling;

namespace UBoat.WebHawk.Controller.Scheduling
{
    [DisallowConcurrentExecution]
    internal class ExecuteSequenceJob : IJob
    {
        private ILog m_Logger;
        private AutoResetEvent m_ExecutionWaitHandle;
        private ExecutionCompleteEventArgs m_ExecutionCompleteEventArgs;
        private JobKey m_JobKey;

        public ExecuteSequenceJob()
        {
            m_Logger = LogManager.GetCurrentClassLogger();
        }

        public void Execute(IJobExecutionContext context)
        {
            ThreadSynchronizer threadSynchronizer = null;
            frmAutomation frmAutomation = null;
            try
            {
                m_JobKey = context.JobDetail.Key;
                m_Logger.InfoFormat("ExecuteSequenceJob {0} executing at {1}.", m_JobKey, DateTime.Now.ToString("r"));

                string connectionString = (string)context.MergedJobDataMap["connectionString"];
                AutomationController automationController = new AutomationController(connectionString);
                SchedulingController schedulingController = new SchedulingController(connectionString);

                long scheduledTaskId = (long)context.MergedJobDataMap["scheduledTaskId"];
                ScheduledTask scheduledTask = schedulingController.GetScheduledTask(scheduledTaskId, DeletedInclusion.All);
                SequenceDetail sequenceDetail = automationController.GetSequenceDetail(scheduledTask.TaskSequence.SequenceId);

                threadSynchronizer = (ThreadSynchronizer)context.MergedJobDataMap["threadSynchronizer"];
                threadSynchronizer.RunOnSynchronizedThread(() => frmAutomation = new frmAutomation(), true);
                
                using (AutomationEngine automationEngine = new AutomationEngine(frmAutomation.Browser))
                {
                    automationEngine.SetSequence(sequenceDetail.SequenceSteps);
                    Dictionary<string, IStateVariable> persistedData = automationController.GetSequencePersistedData(sequenceDetail.Sequence.SequenceId);
                    automationEngine.DataContext.LoadPersistedVariables(persistedData);

                    automationEngine.ExecutionComplete += automationEngine_ExecutionComplete;
                    using (m_ExecutionWaitHandle = new AutoResetEvent(false))
                    {
                        automationEngine.ExecuteSequence();

                        if (!m_ExecutionWaitHandle.WaitOne(scheduledTask.RunDurationLimit.HasValue
                            ? scheduledTask.RunDurationLimit.Value
                            : TimeSpan.FromMilliseconds(-1)))
                        {
                            throw new TimeoutException(
                                String.Format("Scheduled sequence execution timed out because it reached the specified Run Duration Limit of {0}.",
                                scheduledTask.RunDurationLimit));
                        }
                    }
                    automationEngine.ExecutionComplete -= automationEngine_ExecutionComplete;

                    persistedData = automationEngine.DataContext.GetPersistedVariables();
                    automationController.SetSequencePersistedData(sequenceDetail.Sequence.SequenceId, persistedData);
                }

                ExecuteSequenceJobResult result = new ExecuteSequenceJobResult(
                        zGetScheduledTaskStatusFromExecutionState(m_ExecutionCompleteEventArgs.RunResult),
                        ""); //TODO: get error from ExecutionCompleteEventArgs
                context.Result = result;
            }
            catch (Exception ex)
            {
                JobExecutionException jobEx = new JobExecutionException(ex, false);
                throw jobEx;
            }
            finally
            {
                //Clean up
                try
                {
                    if (frmAutomation != null)
                    {
                        threadSynchronizer.RunOnSynchronizedThread(() => frmAutomation.Dispose(), true);
                    }
                }
                catch (Exception ex)
                {
                    if (m_Logger != null)
                    {
                        m_Logger.ErrorFormat("Cleanup failed for ExecuteSequenceJob {0}: {1}", m_JobKey, ex.Message);
                    }
                }

                //Dereference global variables
                m_Logger = null;
                m_JobKey = null;
                m_ExecutionCompleteEventArgs = null;
                m_ExecutionWaitHandle = null;
            }
        }

        void automationEngine_ExecutionComplete(object sender, ExecutionCompleteEventArgs e)
        {
            m_ExecutionCompleteEventArgs = e;
            m_ExecutionWaitHandle.Set();
        }

        private ScheduledTaskStatus zGetScheduledTaskStatusFromExecutionState(ExecutionState executionState)
        {
            switch (executionState)
            {
                case ExecutionState.ManualStop:
                    return ScheduledTaskStatus.Cancelled;
                case ExecutionState.Fail:
                    return ScheduledTaskStatus.Failed;
                default:
                    return ScheduledTaskStatus.Success;
            }
        }
    }
}
