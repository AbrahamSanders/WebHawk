using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Model.Automation.Steps
{
    [Serializable]
    public abstract class ElementValueStep : ElementStep
    {
        public ElementValueMode Mode { get; set; }
        public string AttributeName { get; set; }
    }

    [Serializable]
    public enum ElementValueMode
    {
        Attribute,
        InnerText
    }
}
