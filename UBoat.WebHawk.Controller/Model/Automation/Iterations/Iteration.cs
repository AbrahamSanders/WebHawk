using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Model.Automation.Iterations
{
    [Serializable]
    public abstract class Iteration
    {
        public abstract bool IsSetIteration { get; }
    }
}
