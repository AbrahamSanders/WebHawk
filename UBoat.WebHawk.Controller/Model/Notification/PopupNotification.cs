using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Model.Notification
{
    [Serializable]
    public class PopupNotification : Notification
    {
        public override string ToString()
        {
            return "Popup";
        }
    }
}
