using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Model.Notification
{
    [Serializable]
    public abstract class Notification
    {
        public virtual Notification Clone()
        {
            return (Notification)this.MemberwiseClone();
        }
    }
}
