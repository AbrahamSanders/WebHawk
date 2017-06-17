using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Model.Scheduling
{
    [Serializable]
    public class OneTimeSchedule : Schedule
    {
        protected override void zBuildDescription(StringBuilder sb)
        {
            sb.Append("one time");
        }
    }
}
