using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UBoat.WebHawk.Controller.Model.Scheduling;

namespace UBoat.WebHawk.Controller.Scheduling
{
    public class TaskEventArgs : EventArgs
    {
        public long ScheduledTaskId { get; set; }

        public TaskEventArgs(long scheduledTaskId)
        {
            this.ScheduledTaskId = scheduledTaskId;
        }
    }
}
