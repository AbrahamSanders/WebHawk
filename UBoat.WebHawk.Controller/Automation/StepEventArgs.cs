using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UBoat.WebHawk.Controller.Model.Automation.Steps;

namespace UBoat.WebHawk.Controller.Automation
{
    public class StepEventArgs : EventArgs
    {
        public Step Step { get; private set; }

        public StepEventArgs(Step step)
        {
            this.Step = step;
        }
    }
    public class StepCompleteEventArgs : StepEventArgs
    {
        public StepResult Result { get; private set; }

        public StepCompleteEventArgs(Step step, StepResult result)
            : base(step)
        {
            this.Result = result;
        }
    }

    public enum StepResult
    {
        Success,
        Skipped,
        Failed
    }
}
