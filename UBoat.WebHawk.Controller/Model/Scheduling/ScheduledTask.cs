using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UBoat.WebHawk.Controller.Model.Automation;

namespace UBoat.WebHawk.Controller.Model.Scheduling
{
    [Serializable]
    public class ScheduledTask
    {
        public long ScheduledTaskId { get; set; }
        public string TaskName { get; set; }
        public Schedule RunSchedule { get; set; }
        public Sequence TaskSequence { get; set; }
        public TimeSpan? RunDurationLimit { get; set; }
        public bool Enabled { get; set; }
        public bool IsDeleted { get; set; }

        public ScheduledTaskRunStatistics LastRunStatistics { get; set; }
        public DateTime? NextScheduledRunTimeUtc { get; set; }

        public ScheduledTask()
            : this(null)
        {
        }

        public ScheduledTask(ScheduledTaskRunStatistics lastRunStatistics)
        {
            this.LastRunStatistics = lastRunStatistics ?? new ScheduledTaskRunStatistics();
        }
    }
}
