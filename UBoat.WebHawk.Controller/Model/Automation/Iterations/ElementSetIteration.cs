using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.Utils.DOM;
using UBoat.WebHawk.Controller.Model.Data;

namespace UBoat.WebHawk.Controller.Model.Automation.Iterations
{
    [Serializable]
    public class ElementSetIteration : ObjectSetIteration
    {
        public ElementIdentifier ElementSetContainer { get; set; }
        public ElementType ElementType { get; set; }
        public TimeSpan? PollingTimeout { get; set; }
        public bool IncludeInXML { get; set; }
        public PersistenceMode PersistenceMode { get; set; }

        public ElementSetIteration()
        {
            this.ElementType = Automation.ElementType.Dynamic;
            this.PollingTimeout = TimeSpan.FromSeconds(5);
        }

        public override bool IsSetIteration
        {
            get 
            {
                return this.ObjectSetClassName != null && base.IsSetIteration;
            }
        }
    }
}
