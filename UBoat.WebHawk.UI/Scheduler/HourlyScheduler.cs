using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.WebHawk.Controller.Model.Scheduling;
using UBoat.Utils.Validation;

namespace UBoat.WebHawk.UI.Scheduler
{
    public partial class HourlyScheduler : Scheduler
    {
        protected HourlySchedule HourlySchedule
        {
            get
            {
                return (HourlySchedule)this.Schedule;
            }
        }

        public HourlyScheduler()
        {
            InitializeComponent();
        }

        public HourlyScheduler(Schedule schedule) 
            : this()
        {
            this.SetSchedule(schedule);
        }

        public override void SetSchedule(Schedule schedule)
        {
            base.SetSchedule(schedule);

            this.ipHourlyRecurrence.SetValue(HourlySchedule.HourlyRecurrence);
        }

        public override void Save()
        {
            HourlySchedule.HourlyRecurrence = this.ipHourlyRecurrence.Value.Value;
        }

        public override ValidationResult PerformValidation()
        {
            ValidationResult result = new ValidationResult(true);
            return result;
        }
    }
}
