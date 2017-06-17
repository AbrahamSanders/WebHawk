using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Model.Scheduling
{
    [Serializable]
    public abstract class Schedule
    {
        public DateTime StartTimeUtc { get; set; }
        public DateTime? EndTimeUtc { get; set; }
        public MissedScheduleMode MissedScheduleMode { get; set; }

        protected Schedule()
        {
            this.MissedScheduleMode = MissedScheduleMode.RunAtNextScheduledTime;
        }

        public string BuildDescription()
        {
            StringBuilder sb = new StringBuilder();
            zBuildDescription(sb);
            sb.AppendFormat(" effective {0}", StartTimeUtc.ToLocalTime());
            if (EndTimeUtc.HasValue)
            {
                sb.AppendFormat(" until {0}", EndTimeUtc.Value.ToLocalTime());
            }
            return sb.ToString();
        }

        protected abstract void zBuildDescription(StringBuilder sb);

        protected string zCompileCronWeekdays(List<DayOfWeek> weekdays)
        {
            StringBuilder sb = new StringBuilder();
            for (int x = 0; x < weekdays.Count; x++)
            {
                if (x > 0)
                {
                    sb.Append(",");
                }
                sb.Append(weekdays[x] + 1);
            }
            return sb.ToString();
        }
    }
}
