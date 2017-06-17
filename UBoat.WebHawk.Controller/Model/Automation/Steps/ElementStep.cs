using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UBoat.Utils.DOM;

namespace UBoat.WebHawk.Controller.Model.Automation.Steps
{
    [Serializable]
    public abstract class ElementStep : Step
    {
        public ElementIdentifier Element { get; set; }
        public ElementType ElementType { get; set; }
        public TimeSpan? PollingTimeout { get; set; }

        protected ElementStep()
        {
            this.ElementType = Automation.ElementType.Static;
            this.PollingTimeout = TimeSpan.FromSeconds(5);
        }
    }
}
