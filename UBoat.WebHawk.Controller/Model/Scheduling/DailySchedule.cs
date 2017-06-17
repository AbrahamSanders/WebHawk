using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Model.Scheduling
{
    [Serializable]
    public class DailySchedule : DailyRepeatableSchedule
    {
        public int DailyRecurrence { get; set; }

        protected override void zBuildDescription(StringBuilder sb)
        {
            sb.AppendFormat("every {0} ", DailyRecurrence == 1 ? "day" : String.Format("{0} days", DailyRecurrence));
            base.zBuildDescription(sb);
        }
    }
}
