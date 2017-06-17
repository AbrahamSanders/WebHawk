using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Model.Automation
{
    [Serializable]
    public enum ExecutionState
    {
        Success = 1,
        ManualStop = 2,
        Fail = 3
    }
}
