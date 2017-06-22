using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UBoat.WebHawk.Controller.Notification
{
    internal abstract class Notify<T> : INotify where T : UBoat.WebHawk.Controller.Model.Notification.Notification
    {
        public T Notification { get; set; }

        protected Notify(T notification)
        {
            Notification = notification;
        }

        public abstract void Send(string subject, string message);
    }
}