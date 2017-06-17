using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UBoat.WebHawk.Controller.Model.Notification;

namespace UBoat.WebHawk.Controller.Model.Automation.Steps
{
    [Serializable]
    public class NotifyStep : Step
    {
        public List<Notification.Notification> Notifications { get; set; }
        public string Message { get; set; }
        public bool TrimVariableValueWhitespace { get; set; }
        
        public NotifyStep()
        {
            this.Notifications = new List<Notification.Notification>();
            this.TrimVariableValueWhitespace = true;
        }

        protected override string get_DisplayNameImpl()
        {
            return "Send Notification"; 
        }
    }
}
