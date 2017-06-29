using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Model.Automation.Iterations
{
    [Serializable]
    public class ConditionalIteration : Iteration
    {
        public bool SkipInitialConditionCheck { get; set; }

        public override bool IsSetIteration
        {
            get
            {
                return false;
            }
        }
    }
}
