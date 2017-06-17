using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Model.Automation.Iterations
{
    [Serializable]
    public abstract class ObjectSetIteration : Iteration
    {
        public override bool IsSetIteration
        {
            get
            {
                return this.ObjectSetListName != null && this.ObjectSetScopeName != null;
            }
        }

        public string ObjectSetListName { get; set; }
        public string ObjectSetClassName { get; set; }
        public string ObjectSetScopeName { get; set; }
    }
}
