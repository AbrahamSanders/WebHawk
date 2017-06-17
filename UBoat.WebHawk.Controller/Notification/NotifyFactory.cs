using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Notification;

namespace UBoat.WebHawk.Controller.Notification
{
    internal static class NotifyFactory
    {
        public static INotify GetNotification(NotificationType notificationType)
        {
            switch (notificationType)
            {
                case NotificationType.Email:
                    return new EmailNotify();
                case NotificationType.SMS:
                    return new SMSNotify();
                case NotificationType.Popup:
                    return new PopupNotify();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
