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
    public partial class DailyRepeatableScheduler : Scheduler
    {
        protected DailyRepeatableSchedule DailyRepeatableSchedule
        {
            get
            {
                return (DailyRepeatableSchedule)this.Schedule;
            }
        }

        public DailyRepeatableScheduler()
        {
            InitializeComponent();
        }

        public override void SetSchedule(Schedule schedule)
        {
            base.SetSchedule(schedule);

            this.cbRepeatsDailyOnInterval.Checked = DailyRepeatableSchedule.RepeatsDailyOnInterval;
            dailyRepetitionPanel.Enabled = cbRepeatsDailyOnInterval.Checked;

            this.ipDailyRepetitionInterval.SetValue(DailyRepeatableSchedule.DailyRepetitionInterval);
            if (DailyRepeatableSchedule.DailyRepetitionStartTimeUtc.ToLocalTime() >= this.dtpDailyRepetitionStartTime.MinDate 
                && DailyRepeatableSchedule.DailyRepetitionStartTimeUtc.ToLocalTime() <= this.dtpDailyRepetitionStartTime.MaxDate)
            {
                this.dtpDailyRepetitionStartTime.Value = DailyRepeatableSchedule.DailyRepetitionStartTimeUtc.ToLocalTime();
            }
            else
            {
                this.dtpDailyRepetitionStartTime.Value = DateTime.Now;
            }

            if (DailyRepeatableSchedule.DailyRepetitionEndTimeUtc.ToLocalTime() >= this.dtpDailyRepetitionEndTime.MinDate
                && DailyRepeatableSchedule.DailyRepetitionEndTimeUtc.ToLocalTime() <= this.dtpDailyRepetitionEndTime.MaxDate)
            {
                this.dtpDailyRepetitionEndTime.Value = DailyRepeatableSchedule.DailyRepetitionEndTimeUtc.ToLocalTime();
            }
            else
            {
                this.dtpDailyRepetitionEndTime.Value = DateTime.Now;
            }
        }

        public override void Save()
        {
            DailyRepeatableSchedule.RepeatsDailyOnInterval = cbRepeatsDailyOnInterval.Checked;
            DailyRepeatableSchedule.DailyRepetitionInterval = ipDailyRepetitionInterval.Value.Value;
            DailyRepeatableSchedule.DailyRepetitionStartTimeUtc = dtpDailyRepetitionStartTime.Value.ToUniversalTime();
            DailyRepeatableSchedule.DailyRepetitionEndTimeUtc = dtpDailyRepetitionEndTime.Value.ToUniversalTime();
        }

        public override ValidationResult PerformValidation()
        {
            ValidationResult result = new ValidationResult(true);
            if (dtpDailyRepetitionStartTime.Value > dtpDailyRepetitionEndTime.Value)
            {
                result.Append(ValidationResult.WithFailure("Daily repetition start time must not be later than daily repetition end time."));
            }
            return result;
        }

        private void cbRepeatsDailyOnInterval_CheckedChanged(object sender, EventArgs e)
        {
            dailyRepetitionPanel.Enabled = cbRepeatsDailyOnInterval.Checked;
        }
    }
}
