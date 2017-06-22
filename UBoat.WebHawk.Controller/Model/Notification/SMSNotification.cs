using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Model.Notification
{
    [Serializable]
    public class SMSNotification : Notification
    {
        public string TextbeltAPIURL { get; set; }
        public string TextbeltAPIKey { get; set; }
        public List<string> Numbers { get; set; }

        public SMSNotification()
        {
            Numbers = new List<string>();
        }

        public override Notification Clone()
        {
            SMSNotification notification = (SMSNotification)base.Clone();
            notification.Numbers = new List<string>(Numbers);
            return notification;
        }

        public override string ToString()
        {
            return String.Format("SMS to {0}", string.Join(",", Numbers));
        }
    }
}
