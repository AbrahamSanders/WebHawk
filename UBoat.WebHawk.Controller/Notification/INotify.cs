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
        void Notify(Control UIContext, string address, string message);
    }
}
