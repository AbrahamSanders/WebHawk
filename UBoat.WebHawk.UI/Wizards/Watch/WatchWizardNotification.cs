using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.WebHawk.Controller.Model.Automation.Steps;
using UBoat.WebHawk.Controller.Model.Notification;
using UBoat.Utils.Controls;

namespace UBoat.WebHawk.UI.Wizards.Watch
{
    public partial class WatchWizardNotification : WizardPage
    {
        public WatchWizardNotification()
        {
            InitializeComponent();
        }

        protected override void InitPage()
        {
            //NotifyStep notifyStep = this.Task.TaskSequence.SequenceSteps.OfType<NotifyStep>().First();

            //if (notifyStep.Notifications.Count == 0)
            //{
            //    ipRunInterval.SetValue(TimeSpan.FromMinutes(30));
            //}
            //else
            //{
            //    ipRunInterval.SetValue(new IntervalValue()
            //    {
            //        //Unit = this.Task.RunIntervalUnit,
            //        //Value = this.Task.RunInterval
            //    });
            //}

            //foreach (Notification notification in notifyStep.Notifications)
            //{
            //    if (notification.NotificationType == NotificationType.Email)
            //    {
            //        cbSendEmail.Checked = true;
            //        txtEmailAddress.Text = notification.Address;
            //    }
            //    if (notification.NotificationType == NotificationType.SMS)
            //    {
            //        cbSendSMS.Checked = true;
            //        txtSMSNumber.Text = notification.Address;
            //    }
            //    if (notification.NotificationType == NotificationType.Popup)
            //    {
            //        cbPopupWindow.Checked = true;
            //    }
            //}
        }

        private void cbSendEmail_CheckedChanged(object sender, EventArgs e)
        {
            txtEmailAddress.Enabled = cbSendEmail.Checked;
            ValidateNext();
        }

        private void cbSendSMS_CheckedChanged(object sender, EventArgs e)
        {
            txtSMSNumber.Enabled = cbSendSMS.Checked;
            ValidateNext();
        }

        private void cbPopupWindow_CheckedChanged(object sender, EventArgs e)
        {
            ValidateNext();
        }

        private void txtEmailAddress_TextChanged(object sender, EventArgs e)
        {
            ValidateNext();
        }

        private void txtSMSNumber_TextChanged(object sender, EventArgs e)
        {
            ValidateNext();
        }

        protected override void ValidateNext()
        {
            if (cbSendEmail.Checked && !String.IsNullOrWhiteSpace(txtEmailAddress.Text))
            {
                zOnEnableNext(EventArgs.Empty);
                return;
            }
            if (cbSendSMS.Checked && !String.IsNullOrWhiteSpace(txtSMSNumber.Text))
            {
                zOnEnableNext(EventArgs.Empty);
                return;
            }
            if (cbPopupWindow.Checked)
            {
                zOnEnableNext(EventArgs.Empty);
                return;
            }
            zOnDisableNext(EventArgs.Empty);
        }

        public override void OnNext()
        {
            //this.Task.RunInterval = ipRunInterval.Value.Value;
            //this.Task.RunIntervalUnit = ipRunInterval.Value.Unit;

            //NotifyStep notifyStep = this.Task.TaskSequence.SequenceSteps.OfType<NotifyStep>().First();

            //notifyStep.Notifications.Clear();
            //if (cbSendEmail.Checked)
            //{
            //    notifyStep.Notifications.Add(new Notification()
            //    {
            //        NotificationType = NotificationType.Email,
            //        Address = txtEmailAddress.Text
            //    });
            //}
            //if (cbSendSMS.Checked)
            //{
            //    notifyStep.Notifications.Add(new Notification()
            //    {
            //        NotificationType = NotificationType.SMS,
            //        Address = txtSMSNumber.Text
            //    });
            //}
            //if (cbPopupWindow.Checked)
            //{
            //    notifyStep.Notifications.Add(new Notification()
            //    {
            //        NotificationType = NotificationType.Popup
            //    });
            //}
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(linkLabel1.Text);
            linkLabel1.LinkVisited = true;
            MessageBox.Show(String.Format("\"{0}\" copied to the clipboard.", linkLabel1.Text));
        }
    }
}
