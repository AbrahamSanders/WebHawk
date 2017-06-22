using System.Windows.Forms;
using UBoat.Utils.Threading;
using UBoat.WebHawk.Controller.Model.Notification;

namespace UBoat.WebHawk.Controller.Notification
{
    internal class PopupNotify : Notify<PopupNotification>
    {
        private Control m_UIContext;

        public PopupNotify(PopupNotification notification, Control UIContext)
            : base(notification)
        {
            m_UIContext = UIContext;
        }

        public override void Send(string subject, string message)
        {
            if (m_UIContext != null)
            {
                ThreadingUtils.InvokeControlAction(m_UIContext, ctl =>
                {
                    frmPopup frm = new frmPopup(subject, message);
                    frm.Show();
                });
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Unable to show popup notification as no UIContext was provided.");
            }
        }
    }
}
