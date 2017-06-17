using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Model.Scheduling
{
    [Serializable]
    public abstract class DailyRepeatableSchedule : Schedule
    {
        public bool RepeatsDailyOnInterval { get; set; }
        public DateTime DailyRepetitionStartTimeUtc { get; set; }
        public DateTime DailyRepetitionEndTimeUtc { get; set; }
        public TimeSpan DailyRepetitionInterval { get; set; }

        protected override void zBuildDescription(StringBuilder sb)
        {
            if (RepeatsDailyOnInterval)
            {
                sb.AppendFormat("repeating {0} between {1} and {2}",
                    DescriptionUtils.GetIntervalDescription(DailyRepetitionInterval),
                    DailyRepetitionStartTimeUtc.ToLocalTime().ToLongTimeString(),
                    DailyRepetitionEndTimeUtc.ToLocalTime().ToLongTimeString());
            }
            else
            {
                sb.AppendFormat("at {0}", StartTimeUtc.ToLocalTime().ToLongTimeString());
            }
        }
    }
}
