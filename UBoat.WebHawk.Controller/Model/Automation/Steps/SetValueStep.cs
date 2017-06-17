using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UBoat.WebHawk.Controller.Model.Automation.Steps
{
    [Serializable]
    public class SetValueStep : ElementValueStep
    {
        public string Value { get; set; }
        public bool TrimVariableValueWhitespace { get; set; }

        protected override string get_DisplayNameImpl()
        {
            return "Set Element Value"; 
        }
    }
}
