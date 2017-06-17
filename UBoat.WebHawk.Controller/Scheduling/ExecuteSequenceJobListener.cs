using Quartz.Listener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Scheduling;

namespace UBoat.WebHawk.Controller.Scheduling
{
    internal class ExecuteSequenceJobListener : JobListenerSupport
    {
        private string m_Name;
        private bool m_IsJobRunning;

        public override string Name
        {
            get 
            {
                return m_Name;
            }
        }

        public bool IsJobRunning
        {
            get
            {
                return m_IsJobRunning;
            }
        }

        public ExecuteSequenceJobListener(string name)
        {
            m_Name = name;
        }

        public override void JobToBeExecuted(Quartz.IJobExecutionContext context)
        {
            base.JobToBeExecuted(context);

            m_IsJobRunning = true;

            long scheduledTaskId = (long)context.MergedJobDataMap["scheduledTaskId"];
            ScheduledTaskRunStatistics lastRunStatistics = new ScheduledTaskRunStatistics();
            lastRunStatistics.StartTimeUtc = context.FireTimeUtc.HasValue ? context.FireTimeUtc.Value.DateTime : new DateTime?();
            lastRunStatistics.EndTimeUtc = null;
            lastRunStatistics.Status = ScheduledTaskStatus.Running;
            lastRunStatistics.Error = null;
            
            DateTime? nextScheduledRunTimeUtc = context.NextFireTimeUtc.HasValue ? context.NextFireTimeUtc.Value.DateTime : new DateTime?();

            string connectionString = (string)context.MergedJobDataMap["connectionString"];
            SchedulingController controller = new SchedulingController(connectionString);
            controller.SetScheduledTaskLastRunStatistics(scheduledTaskId, lastRunStatistics);
            controller.SetScheduledTaskNextScheduledRunTime(scheduledTaskId, nextScheduledRunTimeUtc);

            zOnTaskStart(new TaskEventArgs(scheduledTaskId));
        }

        public override void JobWasExecuted(Quartz.IJobExecutionContext context, Quartz.JobExecutionException jobException)
        {
            base.JobWasExecuted(context, jobException);

            long scheduledTaskId = (long)context.MergedJobDataMap["scheduledTaskId"];
            ScheduledTaskRunStatistics lastRunStatistics = new ScheduledTaskRunStatistics();
            lastRunStatistics.StartTimeUtc = context.FireTimeUtc.HasValue ? context.FireTimeUtc.Value.DateTime : new DateTime?();
            lastRunStatistics.EndTimeUtc = context.FireTimeUtc.HasValue ? context.FireTimeUtc.Value.Add(context.JobRunTime).DateTime : new DateTime?();
            if (jobException != null)
            {
                lastRunStatistics.Status = ScheduledTaskStatus.Failed;
                lastRunStatistics.Error = jobException.Message;
            }
            else
            {
                ExecuteSequenceJobResult result = (ExecuteSequenceJobResult)context.Result;
                lastRunStatistics.Status = result.RunStatus;
                lastRunStatistics.Error = result.RunError;
            }

            string connectionString = (string)context.MergedJobDataMap["connectionString"];
            SchedulingController controller = new SchedulingController(connectionString);
            controller.SetScheduledTaskLastRunStatistics(scheduledTaskId, lastRunStatistics);

            zOnTaskComplete(new TaskEventArgs(scheduledTaskId));

            m_IsJobRunning = false;
        }

        public event EventHandler<TaskEventArgs> TaskStart;
        protected void zOnTaskStart(TaskEventArgs e)
        {
            EventHandler<TaskEventArgs> evnt = TaskStart;
            if (evnt != null)
            {
                evnt(this, e);
            }
        }

        public event EventHandler<TaskEventArgs> TaskComplete;
        protected void zOnTaskComplete(TaskEventArgs e)
        {
            EventHandler<TaskEventArgs> evnt = TaskComplete;
            if (evnt != null)
            {
                evnt(this, e);
            }
        }
    }
}
