using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Model.Notification
{
    [Serializable]
    public enum NotificationType
    {
        Email,
        SMS,
        Popup
    }
}
