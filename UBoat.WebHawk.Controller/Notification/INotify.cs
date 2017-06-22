using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UBoat.WebHawk.Controller.Notification
{
    internal interface INotify
    {
        void Send(string subject, string message);
    }
}
