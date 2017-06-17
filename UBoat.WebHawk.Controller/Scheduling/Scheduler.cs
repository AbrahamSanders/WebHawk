using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Quartz;
using UBoat.Utils.Threading;
using UBoat.WebHawk.Controller.Model.Scheduling;
using Common.Logging;
using Quartz.Impl;
using Quartz.Impl.Matchers;

namespace UBoat.WebHawk.Controller.Scheduling
{
    public class Scheduler : IDisposable
    {
        private SchedulingController m_Controller;
        private ILog m_Logger;
        private IScheduler m_QuartzScheduler;
        private ThreadSynchronizer m_ThreadSynchronizer;
        private bool m_Disposed;

        public Scheduler(string connectionString, ThreadSynchronizer sync)
        {
            m_Controller = new SchedulingController(connectionString);
            m_ThreadSynchronizer = sync;
            m_Logger = LogManager.GetCurrentClassLogger();
            ISchedulerFactory factory = new StdSchedulerFactory();
            m_QuartzScheduler = factory.GetScheduler();
        }

        public void Start()
        {
            if (m_Disposed)
            {
                throw new InvalidOperationException("Scheduler is disposed.");
            }
            if (!m_QuartzScheduler.IsStarted)
            {
                zScheduleAllSavedTasks();
                m_QuartzScheduler.Start();
            }
        }

        public void Stop()
        {
            if (!m_Disposed && m_QuartzScheduler.IsStarted)
            {
                m_QuartzScheduler.Standby();
            }
        }

        public void ScheduleTask(ScheduledTask task)
        {
            if (task.ScheduledTaskId == default(long))
            {
                throw new ArgumentException("Scheduling a task requires the task to be saved to the database and have a ScheduledTaskId assigned.");
            }

            JobKey jobKey = JobKey.Create(task.TaskName, JobKey.DefaultGroup);
            IJobDetail job;
            if (!m_QuartzScheduler.CheckExists(jobKey))
            {
                JobDataMap jobDataMap = new JobDataMap();
                jobDataMap.Add("connectionString", m_Controller.ConnectionString);
                jobDataMap.Add("threadSynchronizer", m_ThreadSynchronizer);
                jobDataMap.Add("scheduledTaskId", task.ScheduledTaskId);

                job = JobBuilder.Create<ExecuteSequenceJob>()
                    .WithIdentity(jobKey)
                    .SetJobData(jobDataMap)
                    .StoreDurably()
                    .Build();
                m_QuartzScheduler.AddJob(job, false);

                ExecuteSequenceJobListener jobListener = new ExecuteSequenceJobListener(task.TaskName);
                jobListener.TaskStart += jobListener_TaskStart;
                jobListener.TaskComplete += jobListener_TaskComplete;
                m_QuartzScheduler.ListenerManager.AddJobListener(jobListener, KeyMatcher<JobKey>.KeyEquals(jobKey));
            }
            else
            {
                job = m_QuartzScheduler.GetJobDetail(jobKey);
                m_QuartzScheduler.UnscheduleJobs(m_QuartzScheduler.GetTriggersOfJob(jobKey)
                    .Select(t => t.Key)
                    .ToList());
            }

            if (task.Enabled)
            {
                task.NextScheduledRunTimeUtc = DateTime.MaxValue;
                foreach (TriggerBuilder triggerBuilder in TriggerBuilderFactory.CreateForSchedule(task.TaskName, task.RunSchedule))
                {
                    ITrigger trigger = triggerBuilder
                        .ForJob(job)
                        .Build();
                    DateTimeOffset nextScheduledRunTimeUtc = m_QuartzScheduler.ScheduleJob(trigger);
                    if (nextScheduledRunTimeUtc.DateTime < task.NextScheduledRunTimeUtc.Value)
                    {
                        task.NextScheduledRunTimeUtc = nextScheduledRunTimeUtc.DateTime;
                    }
                }
            }
            else
            {
                task.NextScheduledRunTimeUtc = null;
            }

            m_Controller.SetScheduledTaskNextScheduledRunTime(task.ScheduledTaskId, task.NextScheduledRunTimeUtc);
        }

        public void RunTask(ScheduledTask task)
        {
            if (!task.Enabled)
            {
                throw new ArgumentException(String.Format("ScheduledTaskId {0} cannot be run while it is disabled.", task.ScheduledTaskId));
            }
            if (task.IsDeleted)
            {
                throw new ArgumentException(String.Format("ScheduledTaskId {0} cannot be run while it is deleted.", task.ScheduledTaskId));
            }
            if (task.ScheduledTaskId == default(long))
            {
                throw new ArgumentException("Running a task requires the task to be saved to the database and have a ScheduledTaskId assigned.");
            }
            
            JobKey jobKey = JobKey.Create(task.TaskName, JobKey.DefaultGroup);
            m_QuartzScheduler.TriggerJob(jobKey);
        }

        public void RemoveTask(ScheduledTask task)
        {
            IJobListener jobListener = m_QuartzScheduler.ListenerManager.GetJobListener(task.TaskName);
            if (jobListener != null)
            {
                //Following should always be true, but checking anyway in case the use of jobs is expanded
                if (jobListener is ExecuteSequenceJobListener)
                {
                    ExecuteSequenceJobListener executeSequenceJobListener = (ExecuteSequenceJobListener)jobListener;
                    executeSequenceJobListener.TaskStart -= jobListener_TaskStart;
                    executeSequenceJobListener.TaskComplete -= jobListener_TaskComplete;
                }
                m_QuartzScheduler.ListenerManager.RemoveJobListener(task.TaskName);
            }

            JobKey jobKey = JobKey.Create(task.TaskName, JobKey.DefaultGroup);
            if (m_QuartzScheduler.CheckExists(jobKey))
            {
                m_QuartzScheduler.DeleteJob(jobKey);
            }
        }

        public void Dispose()
        {
            if (!m_Disposed)
            {
                m_QuartzScheduler.Clear();
                m_QuartzScheduler.Shutdown(false);
                m_QuartzScheduler = null;
                m_Logger = null;
                m_ThreadSynchronizer = null;
                m_Controller = null;
                m_Disposed = true;
            }
        }

        void jobListener_TaskStart(object sender, TaskEventArgs e)
        {
            zOnTaskStart(e);
        }

        void jobListener_TaskComplete(object sender, TaskEventArgs e)
        {
            zOnTaskComplete(e);
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

        private void zScheduleAllSavedTasks()
        {
            List<ScheduledTask> scheduledTasks = m_Controller.GetAllScheduledTasks();
            foreach (ScheduledTask scheduledTask in scheduledTasks)
            {
                if (scheduledTask.Enabled)
                {
                    this.ScheduleTask(scheduledTask);
                }
            }
        }
    }
}
