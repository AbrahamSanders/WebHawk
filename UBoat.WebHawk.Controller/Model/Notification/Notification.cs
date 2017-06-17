using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Model.Notification
{
    [Serializable]
    public class Notification
    {
        public NotificationType NotificationType { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return String.Format("{0}: {1}", NotificationType, Address);
        }

        public Notification Clone()
        {
            return (Notification)this.MemberwiseClone();
        }
    }
}
