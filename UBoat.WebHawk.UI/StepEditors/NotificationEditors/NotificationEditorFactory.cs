using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Notification;

namespace UBoat.WebHawk.UI.StepEditors.NotificationEditors
{
    public static class NotificationEditorFactory
    {
        public static StepEditor GetNotificationEditor(StepEditContext context, Notification notification)
        {
            if (notification is EmailNotification)
            {
                return new EmailNotificationEditor(context, (EmailNotification)notification);
            }
            if (notification is SMSNotification)
            {
                return new SMSNotificationEditor(context, (SMSNotification)notification);
            }
            if (notification is PopupNotification)
            {
                return new PopupNotificationEditor(context, (PopupNotification)notification);
            }

            throw new NotSupportedException();
        }
    }
}
