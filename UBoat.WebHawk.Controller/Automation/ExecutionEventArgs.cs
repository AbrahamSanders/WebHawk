using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using UBoat.WebHawk.Controller.Model.Automation.Steps;
using UBoat.WebHawk.Controller.Model.Automation;

namespace UBoat.WebHawk.Controller.Automation
{
    public class ExecutionBeginEventArgs : EventArgs
    {
        public bool WasReset { get; private set; }

        public ExecutionBeginEventArgs(bool wasReset)
        {
            this.WasReset = wasReset;
        }
    }
    public class ExecutionCompleteEventArgs : EventArgs
    {
        public ExecutionState RunResult { get; private set; }

        public ExecutionCompleteEventArgs(ExecutionState runResult)
        {
            this.RunResult = runResult;
        }
    }
}
