using System;
using System.Windows.Forms;
using UBoat.WebHawk.Controller.Model.Notification;

namespace UBoat.WebHawk.Controller.Notification
{
    internal static class NotifyFactory
    {
        public static INotify GetNotification(UBoat.WebHawk.Controller.Model.Notification.Notification notification, Control UIContext = null)
        {
            if (notification is EmailNotification)
            {
                return new EmailNotify((EmailNotification)notification);
            }
            if (notification is SMSNotification)
            {
                return new SMSNotify((SMSNotification)notification);
            }
            if (notification is PopupNotification)
            {
                return new PopupNotify((PopupNotification)notification, UIContext);
            }

            throw new NotSupportedException();
        }
    }
}
