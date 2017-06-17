using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UBoat.WebHawk.Controller.Model.Automation.Steps
{
    [Serializable]
    public class ClickStep : ElementStep
    {
        public ClickType ClickType { get; set; }

        protected override string get_DisplayNameImpl()
        {
            return "Click Element"; 
        }
    }

    [Serializable]
    public enum ClickType
    {
        Left,
        Right
    }
}
