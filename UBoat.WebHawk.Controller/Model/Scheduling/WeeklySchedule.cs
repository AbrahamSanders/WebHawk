using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Model.Scheduling
{
    [Serializable]
    public class WeeklySchedule : DailyRepeatableSchedule
    {
        public List<DayOfWeek> WeeklyRecurrence { get; set; }

        public WeeklySchedule()
        {
            this.WeeklyRecurrence = new List<DayOfWeek>();
        }

        protected override void zBuildDescription(StringBuilder sb)
        {
            sb.Append("every ");
            DescriptionUtils.BuildDescriptiveList(WeeklyRecurrence, sb);
            sb.Append(" ");
            base.zBuildDescription(sb);
        }
    }
}
