using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.WebHawk.Controller.Model.Scheduling;

namespace UBoat.WebHawk.UI.Wizards
{
    public class WizardPage : UserControl
    {
        public ScheduledTask Task { get; set; }
        public bool IsUpdateMode { get; set; }

        public void OnShow(bool initPage)
        {
            if (initPage)
            {
                InitPage();
            }
            ValidateNext();
        }

        protected virtual void InitPage()
        {

        }

        protected virtual void ValidateNext()
        {
            
        }

        public virtual void OnNext()
        {

        }

        public event EventHandler EnableNext;
        protected void zOnEnableNext(EventArgs e)
        {
            EventHandler evnt = EnableNext;
            if (evnt != null)
            {
                evnt(this, e);
            }
        }

        public event EventHandler DisableNext;
        protected void zOnDisableNext(EventArgs e)
        {
            EventHandler evnt = DisableNext;
            if (evnt != null)
            {
                evnt(this, e);
            }
        }
    }
}
