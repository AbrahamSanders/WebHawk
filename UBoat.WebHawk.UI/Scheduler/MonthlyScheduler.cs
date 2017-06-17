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
    public partial class MonthlyScheduler : Scheduler
    {
        private struct OrdinalDay
        {
            public int DayValue;
            public string Description;

            public override string ToString()
            {
                return Description;
            }
        }

        protected MonthlySchedule MonthlySchedule
        {
            get
            {
                return (MonthlySchedule)this.Schedule;
            }
        }

        public MonthlyScheduler()
        {
            InitializeComponent();

            foreach (Month month in Enum.GetValues(typeof(Month)))
            {
                ccbMonths.Items.Add(month);
            }
            foreach (OrdinalDay ordinalDay in zGetOrdinalDays())
            {
                ccbOrdinalDays.Items.Add(ordinalDay);
            }
            foreach (WeekdayPosition weekdayPosition in Enum.GetValues(typeof(WeekdayPosition)))
            {
                ccbWeekdayPositions.Items.Add(weekdayPosition);
            }
            foreach (DayOfWeek weekday in Enum.GetValues(typeof(DayOfWeek)))
            {
                ccbWeekdays.Items.Add(weekday);
            }
        }

        public MonthlyScheduler(Schedule schedule) 
            : this()
        {
            this.SetSchedule(schedule);
        }

        public override void SetSchedule(Schedule schedule)
        {
            base.SetSchedule(schedule);

            for (int x = 1; x < ccbMonths.Items.Count; x++)
            {
                if (MonthlySchedule.MonthlyRecurrence.Contains((Month)ccbMonths.Items[x]))
                {
                    ccbMonths.SetItemChecked(x, true);
                }
            }

            if (MonthlySchedule.MonthlyRecurrenceType == MonthlyRecurrenceType.OrdinalDays)
            {
                rbOrdinalDays.Checked = true;
                for (int x = 1; x < ccbOrdinalDays.Items.Count; x++)
                {
                    if (MonthlySchedule.OrdinalDays.Contains(((OrdinalDay)ccbOrdinalDays.Items[x]).DayValue))
                    {
                        ccbOrdinalDays.SetItemChecked(x, true);
                    }
                }
            }
            else
            {
                rbWeekdays.Checked = true;
                for (int x = 1; x < ccbWeekdayPositions.Items.Count; x++)
                {
                    if (MonthlySchedule.WeekdayPositions.Contains((WeekdayPosition)ccbWeekdayPositions.Items[x]))
                    {
                        ccbWeekdayPositions.SetItemChecked(x, true);
                    }
                }
                for (int x = 1; x < ccbWeekdays.Items.Count; x++)
                {
                    if (MonthlySchedule.Weekdays.Contains((DayOfWeek)ccbWeekdays.Items[x]))
                    {
                        ccbWeekdays.SetItemChecked(x, true);
                    }
                }
            }

            this.dailyRepeatableScheduler.SetSchedule(schedule);
        }

        public override void Save()
        {
            MonthlySchedule.MonthlyRecurrence.Clear();
            MonthlySchedule.MonthlyRecurrence.AddRange(ccbMonths.CheckedItems.OfType<Month>());

            MonthlySchedule.MonthlyRecurrenceType = rbOrdinalDays.Checked 
                ? MonthlyRecurrenceType.OrdinalDays 
                : MonthlyRecurrenceType.Weekdays;

            MonthlySchedule.OrdinalDays.Clear();
            if (MonthlySchedule.MonthlyRecurrenceType == MonthlyRecurrenceType.OrdinalDays)
            {
                MonthlySchedule.OrdinalDays.AddRange(ccbOrdinalDays.CheckedItems
                    .OfType<OrdinalDay>()
                    .Select(od => od.DayValue));
            }

            MonthlySchedule.WeekdayPositions.Clear();
            MonthlySchedule.Weekdays.Clear();
            if (MonthlySchedule.MonthlyRecurrenceType == MonthlyRecurrenceType.Weekdays)
            {
                MonthlySchedule.WeekdayPositions.AddRange(ccbWeekdayPositions.CheckedItems.OfType<WeekdayPosition>());
                MonthlySchedule.Weekdays.AddRange(ccbWeekdays.CheckedItems.OfType<DayOfWeek>());
            }

            this.dailyRepeatableScheduler.Save();
        }

        public override ValidationResult PerformValidation()
        {
            ValidationResult result = new ValidationResult(true);
            if (MonthlySchedule.MonthlyRecurrence.Count == 0)
            {
                result.Append(ValidationResult.WithFailure("Please select at least one month."));
            }
            if (MonthlySchedule.MonthlyRecurrenceType == MonthlyRecurrenceType.OrdinalDays 
                && MonthlySchedule.OrdinalDays.Count == 0)
            {
                result.Append(ValidationResult.WithFailure("Please select at least one day of the month."));
            }
            if (MonthlySchedule.MonthlyRecurrenceType == MonthlyRecurrenceType.Weekdays
                && (MonthlySchedule.WeekdayPositions.Count == 0 || MonthlySchedule.Weekdays.Count == 0))
            {
                result.Append(ValidationResult.WithFailure("Please select at least one day of the week and week of the month."));
            }
            result.Append(this.dailyRepeatableScheduler.PerformValidation());
            return result;
        }

        private void rbOrdinalDays_CheckedChanged(object sender, EventArgs e)
        {
            zUpdateMonthlyRecurrenceMode();
        }

        private void rbWeekdays_CheckedChanged(object sender, EventArgs e)
        {
            zUpdateMonthlyRecurrenceMode();
        }

        private void zUpdateMonthlyRecurrenceMode()
        {
            if (rbOrdinalDays.Checked)
            {
                ccbOrdinalDays.Enabled = true;
                ccbWeekdayPositions.Enabled = false;
                ccbWeekdays.Enabled = false;
            }
            else
            {
                ccbOrdinalDays.Enabled = false;
                ccbWeekdayPositions.Enabled = true;
                ccbWeekdays.Enabled = true;
            }
        }

        private List<OrdinalDay> zGetOrdinalDays()
        {
            List<OrdinalDay> ordinalDays = new List<OrdinalDay>();
            for (int x = 0; x < 31; x++)
            {
                string dayStr = (x + 1).ToString();
                ordinalDays.Add(new OrdinalDay()
                {
                    DayValue = x,
                    Description = String.Format("{0}{1}", dayStr,
                        dayStr.EndsWith("1") && !dayStr.EndsWith("11") ? "st" :
                        dayStr.EndsWith("2") && !dayStr.EndsWith("12") ? "nd" :
                        dayStr.EndsWith("3") && !dayStr.EndsWith("13") ? "rd" : "th")
                });
            }
            ordinalDays.Add(new OrdinalDay()
            {
                DayValue = -1,
                Description = "Last day"
            });
            return ordinalDays;
        }
    }
}
