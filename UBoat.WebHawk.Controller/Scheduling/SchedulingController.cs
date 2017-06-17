using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Persistence;
using UBoat.WebHawk.Controller.Model.Scheduling;
using UBoat.WebHawk.Controller.Common;
using UBoat.Utils.Common;

namespace UBoat.WebHawk.Controller.Scheduling
{
    public class SchedulingController : ControllerBase
    {
        public SchedulingController(string connectionString)
            : base(connectionString)
        {
        }

        public void SaveScheduledTask(ScheduledTask scheduledTask)
        {
            using (WebHawkDataProvider data = new WebHawkDataProvider(ConnectionString))
            {
                data.SaveScheduledTask(scheduledTask);
            }
        }

        public void DeleteScheduledTask(ScheduledTask scheduledTask, bool softDelete = true)
        {
            using (WebHawkDataProvider data = new WebHawkDataProvider(ConnectionString))
            {
                if (softDelete)
                {
                    data.DeleteScheduledTask(scheduledTask.ScheduledTaskId);
                    scheduledTask.IsDeleted = true;
                }
                else
                {
                    data.HardDeleteScheduledTask(scheduledTask.ScheduledTaskId);
                }
            }
        }

        public List<ScheduledTask> GetAllScheduledTasks(DeletedInclusion deletedInclusion = DeletedInclusion.NotDeletedOnly)
        {
            using (WebHawkDataProvider data = new WebHawkDataProvider(ConnectionString))
            {
                return data.GetAllScheduledTasks(deletedInclusion);
            }
        }

        public ScheduledTask GetScheduledTask(long scheduledTaskId, DeletedInclusion deletedInclusion = DeletedInclusion.NotDeletedOnly)
        {
            using (WebHawkDataProvider data = new WebHawkDataProvider(ConnectionString))
            {
                return data.GetScheduledTask(scheduledTaskId, deletedInclusion);
            }
        }

        public bool ValidateNewScheduledTaskName(string name)
        {
            using (WebHawkDataProvider data = new WebHawkDataProvider(ConnectionString))
            {
                return !data.ScheduledTaskNameExists(name);
            }
        }

        public void SetScheduledTaskLastRunStatistics(long scheduledTaskId, ScheduledTaskRunStatistics lastRunStatistics)
        {
            using (WebHawkDataProvider data = new WebHawkDataProvider(ConnectionString))
            {
                data.SetScheduledTaskLastRunStatistics(scheduledTaskId, lastRunStatistics);
            }
        }

        public void SetScheduledTaskNextScheduledRunTime(long scheduledTaskId, DateTime? nextScheduledRunTimeUtc)
        {
            using (WebHawkDataProvider data = new WebHawkDataProvider(ConnectionString))
            {
                data.SetScheduledTaskNextScheduledRunTime(scheduledTaskId, nextScheduledRunTimeUtc);
            }
        }
    }
}
