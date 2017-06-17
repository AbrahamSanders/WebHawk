using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Model.Automation.Iterations
{
    [Serializable]
    public class FixedIteration : Iteration
    {
        public int Iterations { get; set; }

        public override bool IsSetIteration
        {
            get
            {
                return false;
            }
        }
    }
}
