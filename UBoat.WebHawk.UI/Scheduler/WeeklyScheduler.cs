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
    public partial class WeeklyScheduler : Scheduler
    {
        protected WeeklySchedule WeeklySchedule
        {
            get
            {
                return (WeeklySchedule)this.Schedule;
            }
        }

        public WeeklyScheduler()
        {
            InitializeComponent();
        }

        public WeeklyScheduler(Schedule schedule) 
            : this()
        {
            this.SetSchedule(schedule);
        }

        public override void SetSchedule(Schedule schedule)
        {
            base.SetSchedule(schedule);
            
            foreach (DayOfWeek weekday in WeeklySchedule.WeeklyRecurrence)
            {
                switch (weekday)
                {
                    case DayOfWeek.Sunday:
                        cbSunday.Checked = true;
                        break;
                    case DayOfWeek.Monday:
                        cbMonday.Checked = true;
                        break;
                    case DayOfWeek.Tuesday:
                        cbTuesday.Checked = true;
                        break;
                    case DayOfWeek.Wednesday:
                        cbWednesday.Checked = true;
                        break;
                    case DayOfWeek.Thursday:
                        cbThursday.Checked = true;
                        break;
                    case DayOfWeek.Friday:
                        cbFriday.Checked = true;
                        break;
                    case DayOfWeek.Saturday:
                        cbSaturday.Checked = true;
                        break;
                }
            }

            this.dailyRepeatableScheduler.SetSchedule(schedule);
        }

        public override void Save()
        {
            WeeklySchedule.WeeklyRecurrence.Clear();
            if (cbSunday.Checked)
            {
                WeeklySchedule.WeeklyRecurrence.Add(DayOfWeek.Sunday);
            }
            if (cbMonday.Checked)
            {
                WeeklySchedule.WeeklyRecurrence.Add(DayOfWeek.Monday);
            }
            if (cbTuesday.Checked)
            {
                WeeklySchedule.WeeklyRecurrence.Add(DayOfWeek.Tuesday);
            }
            if (cbWednesday.Checked)
            {
                WeeklySchedule.WeeklyRecurrence.Add(DayOfWeek.Wednesday);
            }
            if (cbThursday.Checked)
            {
                WeeklySchedule.WeeklyRecurrence.Add(DayOfWeek.Thursday);
            }
            if (cbFriday.Checked)
            {
                WeeklySchedule.WeeklyRecurrence.Add(DayOfWeek.Friday);
            }
            if (cbSaturday.Checked)
            {
                WeeklySchedule.WeeklyRecurrence.Add(DayOfWeek.Saturday);
            }

            this.dailyRepeatableScheduler.Save();
        }

        public override ValidationResult PerformValidation()
        {
            ValidationResult result = new ValidationResult(true);
            if (WeeklySchedule.WeeklyRecurrence.Count == 0)
            {
                result.Append(ValidationResult.WithFailure("Please select at least one day of the week."));
            }
            result.Append(this.dailyRepeatableScheduler.PerformValidation());
            return result;
        }
    }
}
