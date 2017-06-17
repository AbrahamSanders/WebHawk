using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Model.Scheduling
{
    [Serializable]
    public enum ScheduledTaskStatus
    {
        Success = 1,
        Cancelled = 2,
        Failed = 3,
        Running = 4
    }
}
