using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Scheduling;

namespace UBoat.WebHawk.Controller.Scheduling
{
    public class ExecuteSequenceJobResult
    {
        public ScheduledTaskStatus RunStatus { get; set; }
        public string RunError { get; set; }

        public ExecuteSequenceJobResult(ScheduledTaskStatus runStatus, string runError = null)
        {
            this.RunStatus = runStatus;
            this.RunError = runError;
        }
    }
}
