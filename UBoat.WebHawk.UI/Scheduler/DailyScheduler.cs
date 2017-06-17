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
    public partial class DailyScheduler : Scheduler
    {
        protected DailySchedule DailySchedule
        {
            get
            {
                return (DailySchedule)this.Schedule;
            }
        }

        public DailyScheduler()
        {
            InitializeComponent();
        }

        public DailyScheduler(Schedule schedule) 
            : this()
        {
            this.SetSchedule(schedule);
        }

        public override void SetSchedule(Schedule schedule)
        {
            base.SetSchedule(schedule);
            this.nudDailyRecurrence.Value = DailySchedule.DailyRecurrence;
            this.dailyRepeatableScheduler.SetSchedule(schedule);
        }

        public override void Save()
        {
            DailySchedule.DailyRecurrence = (int)this.nudDailyRecurrence.Value;
            this.dailyRepeatableScheduler.Save();
        }

        public override ValidationResult PerformValidation()
        {
            ValidationResult result = new ValidationResult(true);
            result.Append(this.dailyRepeatableScheduler.PerformValidation());
            return result;
        }
    }
}
