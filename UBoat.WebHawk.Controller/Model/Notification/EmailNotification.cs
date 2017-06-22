using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Model.Notification
{
    [Serializable]
    public class EmailNotification : Notification
    {
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public bool UseSSL { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
        public string FromAddress { get; set; }
        public string FromAddressDisplayName { get; set; }
        public List<string> ToAddresses { get; set; }

        public EmailNotification()
        {
            ToAddresses = new List<string>();
        }

        public override Notification Clone()
        {
            EmailNotification notification = (EmailNotification)base.Clone();
            notification.ToAddresses = new List<string>(ToAddresses);
            return notification;
        }

        public override string ToString()
        {
            return String.Format("Email from {0} to {1}", FromAddress, string.Join(",", ToAddresses));
        }
    }
}
