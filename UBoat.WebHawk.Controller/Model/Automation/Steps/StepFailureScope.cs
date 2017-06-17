using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Model.Automation.Steps
{
    [Serializable]
    public enum StepFailureScope
    {
        Step,
        Iteration,
        Group,
        Sequence
    }
}
