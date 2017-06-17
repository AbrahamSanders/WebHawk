using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.Utils.Validation;
using UBoat.WebHawk.Controller.Model.Automation;
using UBoat.WebHawk.Controller.Model.Scheduling;
using UBoat.WebHawk.UI.Scheduler;

namespace UBoat.WebHawk.UI
{
    public partial class frmScheduledTaskProperties : Form, IValidatable
    {
        private ScheduledTask m_ScheduledTask;
        private Schedule m_Schedule;
        private Scheduler.Scheduler m_Scheduler;
        private bool m_IsNewTask;

        public frmScheduledTaskProperties()
        {
            InitializeComponent();
        }

        public frmScheduledTaskProperties(ScheduledTask scheduledTask, bool isNewTask) 
            : this()
        {
            m_ScheduledTask = scheduledTask;
            m_IsNewTask = isNewTask;

            if (m_IsNewTask)
            {
                m_Schedule = new OneTimeSchedule();

                this.Text = "New Scheduled Task";
                btnSave.Text = "Create";
                groupBox1.Text = "Create New Scheduled Task";
            }
            else
            {
                m_Schedule = scheduledTask.RunSchedule;

                this.Text = "Scheduled Task Properties";
                btnSave.Text = "Save";
                groupBox1.Text = "Edit Scheduled Task";
            }
        }

        public ValidationResult PerformValidation()
        {
            ValidationResult result = new ValidationResult(true);

            if (String.IsNullOrWhiteSpace(txtTaskName.Text))
            {
                result.Append(ValidationResult.WithFailure("Please enter a name for this scheduled task."));
            }
            else if ((m_IsNewTask || txtTaskName.Text.ToLower() != m_ScheduledTask.TaskName.ToLower()) 
                && !WebHawkAppContext.SchedulingController.ValidateNewScheduledTaskName(txtTaskName.Text))
            {
                result.Append(ValidationResult.WithFailure(String.Format("A scheduled task with the name \"{0}\" already exists. Please assign a unique name to this task.", txtTaskName.Text)));
            }

            if (cbTaskSequence.SelectedIndex < 0)
            {
                result.Append(ValidationResult.WithFailure("Please select a Sequence."));
            }

            if (cbTaskExpires.Checked && dtpTaskStartTime.Value > dtpTaskEndTime.Value)
            {
                result.Append(ValidationResult.WithFailure("Task start time must not be later than its expire time."));
            }

            if (result.IsValid && cbTaskEnabled.Checked)
            {
                result.Append(ValidationResult.WithWarning(
                    String.Format("The Sequence \"{0}\" will run {1}.",
                        cbTaskSequence.Text,
                        m_Schedule.BuildDescription())));
            }

            return result;
        }

        private void frmScheduledTaskProperties_Load(object sender, EventArgs e)
        {
            txtTaskName.Text = m_ScheduledTask.TaskName;
            cbTaskSequence.DataSource = WebHawkAppContext.AutomationController.GetAllSequences();
            cbTaskSequence.DisplayMember = "Name";
            if (m_ScheduledTask.TaskSequence != null)
            {
                cbTaskSequence.Text = m_ScheduledTask.TaskSequence.Name;
            }
            if (m_Schedule.StartTimeUtc.ToLocalTime() >= dtpTaskStartTime.MinDate && m_Schedule.StartTimeUtc.ToLocalTime() <= dtpTaskStartTime.MaxDate)
            {
                dtpTaskStartTime.Value = m_Schedule.StartTimeUtc.ToLocalTime();
            }
            else
            {
                dtpTaskStartTime.Value = DateTime.Now;
            }

            if (m_Schedule is OneTimeSchedule)
            {
                rbOneTime.Checked = true;
            }
            if (m_Schedule is HourlySchedule)
            {
                rbHourly.Checked = true;
            }
            if (m_Schedule is DailySchedule)
            {
                rbDaily.Checked = true;
            }
            if (m_Schedule is WeeklySchedule)
            {
                rbWeekly.Checked = true;
            }
            if (m_Schedule is MonthlySchedule)
            {
                rbMonthly.Checked = true;
            }

            cbLimitTaskRunTime.Checked = m_ScheduledTask.RunDurationLimit.HasValue;
            ipMaxDuration.Enabled = m_ScheduledTask.RunDurationLimit.HasValue;
            if (m_ScheduledTask.RunDurationLimit.HasValue)
            {
                ipMaxDuration.SetValue(m_ScheduledTask.RunDurationLimit.Value);
            }

            cbTaskExpires.Checked = m_Schedule.EndTimeUtc.HasValue;
            dtpTaskEndTime.Enabled = m_Schedule.EndTimeUtc.HasValue;
            
            if (m_Schedule.EndTimeUtc.HasValue && 
                m_Schedule.EndTimeUtc.Value.ToLocalTime() >= dtpTaskEndTime.MinDate 
                && m_Schedule.EndTimeUtc.Value.ToLocalTime() <= dtpTaskEndTime.MaxDate)
            {
                dtpTaskEndTime.Value = m_Schedule.EndTimeUtc.Value.ToLocalTime();
            }
            else
            {
                dtpTaskEndTime.Value = DateTime.Now;
            }

            cbTaskEnabled.Checked = m_ScheduledTask.Enabled;

            if (m_Schedule.MissedScheduleMode == MissedScheduleMode.RunAtNextScheduledTime)
            {
                rbMissedScheduleModeNextScheduledTime.Checked = true;
            }
            else
            {
                rbMissedScheduleModeRunImmediately.Checked = true;
            }
        }

        private void rbOneTime_CheckedChanged(object sender, EventArgs e)
        {
            zUpdateScheduler();
        }

        private void rbHourly_CheckedChanged(object sender, EventArgs e)
        {
            zUpdateScheduler();
        }

        private void rbDaily_CheckedChanged(object sender, EventArgs e)
        {
            zUpdateScheduler();
        }

        private void rbWeekly_CheckedChanged(object sender, EventArgs e)
        {
            zUpdateScheduler();
        }

        private void rbMonthly_CheckedChanged(object sender, EventArgs e)
        {
            zUpdateScheduler();
        }

        private void zUpdateScheduler()
        {
            if (rbOneTime.Checked && !(m_Schedule is OneTimeSchedule))
            {
                m_Schedule = new OneTimeSchedule();
            }
            if (rbHourly.Checked && !(m_Schedule is HourlySchedule))
            {
                m_Schedule = new HourlySchedule()
                {
                    HourlyRecurrence = TimeSpan.FromHours(1)
                };
            }
            if (rbDaily.Checked && !(m_Schedule is DailySchedule))
            {
                m_Schedule = new DailySchedule()
                {
                    DailyRecurrence = 1,
                    DailyRepetitionInterval = TimeSpan.FromHours(1)
                };
            }
            if (rbWeekly.Checked && !(m_Schedule is WeeklySchedule))
            {
                m_Schedule = new WeeklySchedule()
                {
                    DailyRepetitionInterval = TimeSpan.FromHours(1)
                };
            }
            if (rbMonthly.Checked && !(m_Schedule is MonthlySchedule))
            {
                m_Schedule = new MonthlySchedule()
                {
                    MonthlyRecurrenceType = MonthlyRecurrenceType.OrdinalDays,
                    DailyRepetitionInterval = TimeSpan.FromHours(1)
                };
            }

            zClearScheduler();
            if (!(m_Schedule is OneTimeSchedule))
            {
                m_Scheduler = SchedulerFactory.GetScheduler(m_Schedule);
                m_Scheduler.Dock = DockStyle.Fill;
                gbScheduler.Controls.Add(m_Scheduler);
            }
        }

        private void cbLimitTaskRunTime_CheckedChanged(object sender, EventArgs e)
        {
            ipMaxDuration.Enabled = cbLimitTaskRunTime.Checked;
        }

        private void cbTaskExpires_CheckedChanged(object sender, EventArgs e)
        {
            dtpTaskEndTime.Enabled = cbTaskExpires.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            m_Schedule.StartTimeUtc = dtpTaskStartTime.Value.ToUniversalTime();
            m_Schedule.EndTimeUtc = cbTaskExpires.Checked ? dtpTaskEndTime.Value.ToUniversalTime() : new DateTime?();
            m_Schedule.MissedScheduleMode = rbMissedScheduleModeNextScheduledTime.Checked 
                ? MissedScheduleMode.RunAtNextScheduledTime 
                : MissedScheduleMode.RunImmediately;
            if (m_Scheduler != null)
            {
                m_Scheduler.Save();
            }

            if (Validator.ValidateWithPrompt("Save Scheduled Task", this, m_Scheduler))
            {
                m_ScheduledTask.TaskName = txtTaskName.Text;
                m_ScheduledTask.TaskSequence = (Sequence)cbTaskSequence.SelectedItem;
                m_ScheduledTask.RunSchedule = m_Schedule;
                m_ScheduledTask.RunDurationLimit = cbLimitTaskRunTime.Checked ? ipMaxDuration.Value.Value : new TimeSpan?();
                m_ScheduledTask.Enabled = cbTaskEnabled.Checked;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmScheduledTaskProperties_FormClosing(object sender, FormClosingEventArgs e)
        {
            zClearScheduler();
        }

        private void zClearScheduler()
        {
            if (m_Scheduler != null)
            {
                m_Scheduler.Dispose();
                gbScheduler.Controls.Clear();
                m_Scheduler = null;
            }
        }
    }
}
