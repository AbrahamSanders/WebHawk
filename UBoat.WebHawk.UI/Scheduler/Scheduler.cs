using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.Utils.Validation;
using UBoat.WebHawk.Controller.Model.Scheduling;

namespace UBoat.WebHawk.UI.Scheduler
{
    public class Scheduler : UserControl, IValidatable
    {
        public Schedule Schedule { get; set; }

        public virtual void SetSchedule(Schedule schedule)
        {
            this.Schedule = schedule;
        }

        public virtual void Save()
        {
        }

        public virtual ValidationResult PerformValidation()
        {
            throw new NotImplementedException();
        }
    }
}
