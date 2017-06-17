using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.Utils.Threading;

namespace UBoat.WebHawk.Controller.Notification
{
    internal class PopupNotify : INotify
    {
        public void Notify(Control UIContext, string address, string message)
        {
            ThreadingUtils.InvokeControlAction(UIContext, ctl =>
            {
                frmPopup frm = new frmPopup(message);
                frm.Show();
            });
        }
    }
}
