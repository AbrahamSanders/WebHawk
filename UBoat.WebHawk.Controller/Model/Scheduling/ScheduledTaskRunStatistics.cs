using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Model.Scheduling
{
    public class ScheduledTaskRunStatistics
    {
        public DateTime? StartTimeUtc { get; set; }
        public DateTime? EndTimeUtc { get; set; }
        public ScheduledTaskStatus? Status { get; set; }
        public string Error { get; set; }
    }
}
