using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.WebHawk.Controller.Model.Notification;
using UBoat.Utils.Validation;

namespace UBoat.WebHawk.UI.StepEditors.NotificationEditors
{
    public partial class EmailNotificationEditor : EmailNotificationEditorBase
    {
        public override string Title
        {
            get
            {
                return "Email Notification";
            }
        }

        public EmailNotificationEditor()
        {
            InitializeComponent();
        }

        public EmailNotificationEditor(StepEditContext context, EmailNotification notification)
            : this()
        {
            this.SetContext(context, notification);
        }

        public override void SetContext(StepEditContext context, EmailNotification notification)
        {
            base.SetContext(context, notification);

            cbSmtpPresets.DataSource = Enum.GetValues(typeof(SMTPPresets));

            if (notification.SmtpHost != null && notification.SmtpHost.ToLower() == "smtp.gmail.com" &&
                notification.SmtpPort == 587 &&
                notification.UseSSL)
            {
                cbSmtpPresets.SelectedItem = SMTPPresets.Gmail;
            }
            else
            {
                cbSmtpPresets.SelectedItem = SMTPPresets.Custom;
            }

            txtSmtpHost.Text = notification.SmtpHost;
            nudSmtpPort.Value = notification.SmtpPort;
            cbSmtpSSL.Checked = notification.UseSSL;
            txtSmtpUsername.Text = notification.SmtpUsername;
            txtSmtpPassword.Text = notification.SmtpPassword;

            txtFromAddress.Text = notification.FromAddress;
            txtFromAddressDisplayName.Text = notification.FromAddressDisplayName;
            txtToAddresses.Text = String.Join("; ", notification.ToAddresses);
        }

        public override ValidationResult PerformValidation()
        {
            ValidationResult result = base.PerformValidation();
            return result;
        }

        public override void Save()
        {
            base.Save();

            this.Target.SmtpHost = txtSmtpHost.Text.Trim();
            this.Target.SmtpPort = Convert.ToInt32(nudSmtpPort.Value);
            this.Target.UseSSL = cbSmtpSSL.Checked;
            this.Target.SmtpUsername = txtSmtpUsername.Text.Trim();
            this.Target.SmtpPassword = txtSmtpPassword.Text.Trim();

            this.Target.FromAddress = txtFromAddress.Text.Trim();
            this.Target.FromAddressDisplayName = !String.IsNullOrWhiteSpace(txtFromAddressDisplayName.Text) 
                ? txtFromAddressDisplayName.Text.Trim() 
                : null;
            this.Target.ToAddresses = txtToAddresses.Text.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Trim())
                .ToList();
        }

        private void cbSmtpPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            SMTPPresets preset = (SMTPPresets)cbSmtpPresets.SelectedItem;
            switch (preset)
            {
                case SMTPPresets.Gmail:
                    txtSmtpHost.Text = "smtp.gmail.com";
                    nudSmtpPort.Value = 587;
                    cbSmtpSSL.Checked = true;
                    break;
                default:
                    break;
            }
        }
    }

    public enum SMTPPresets
    {
        Gmail,
        Custom
    }

    /// <summary>
    /// BULLSHIT intermediate base class becuase the winforms designer can't load anything whos immediate base class is generic... FUCK!
    /// Just pretend this isn't here and go on with your day.
    /// http://stackoverflow.com/questions/13345551/why-do-base-windows-forms-form-class-with-generic-types-stop-the-designer-loadin
    /// </summary>
    public class EmailNotificationEditorBase : StepEditor<EmailNotification>
    {
    }
}
