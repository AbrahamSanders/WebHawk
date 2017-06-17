using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Model.Scheduling
{
    [Serializable]
    public class HourlySchedule : Schedule
    {
        public TimeSpan HourlyRecurrence { get; set; }

        protected override void zBuildDescription(StringBuilder sb)
        {
            sb.Append(DescriptionUtils.GetIntervalDescription(HourlyRecurrence));
        }
    }
}
