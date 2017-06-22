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
    public partial class SMSNotificationEditor : SMSNotificationEditorBase
    {
        public override string Title
        {
            get
            {
                return "SMS Notification";
            }
        }

        public SMSNotificationEditor()
        {
            InitializeComponent();
        }

        public SMSNotificationEditor(StepEditContext context, SMSNotification notification)
            : this()
        {
            this.SetContext(context, notification);
        }

        public override void SetContext(StepEditContext context, SMSNotification notification)
        {
            base.SetContext(context, notification);

            cbTextbeltPresets.DataSource = Enum.GetValues(typeof(TextbeltPresets));

            if (notification.TextbeltAPIURL != null && notification.TextbeltAPIURL.ToLower() == "http://textbelt.com/text")
            {
                cbTextbeltPresets.SelectedItem = TextbeltPresets.Paid;
            }
            else
            {
                cbTextbeltPresets.SelectedItem = TextbeltPresets.Custom;
            }

            txtTextbeltAPIURL.Text = notification.TextbeltAPIURL;
            txtTextbeltAPIKey.Text = notification.TextbeltAPIKey;

            txtNumbers.Text = String.Join("; ", notification.Numbers);
        }

        public override ValidationResult PerformValidation()
        {
            ValidationResult result = base.PerformValidation();
            return result;
        }

        public override void Save()
        {
            base.Save();

            this.Target.TextbeltAPIURL = txtTextbeltAPIURL.Text.Trim();
            this.Target.TextbeltAPIKey = !String.IsNullOrWhiteSpace(txtTextbeltAPIKey.Text) 
                ? txtTextbeltAPIKey.Text.Trim() 
                : null;

            this.Target.Numbers = txtNumbers.Text.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => n.Trim())
                .ToList();
        }

        private void cbTextbeltPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextbeltPresets preset = (TextbeltPresets)cbTextbeltPresets.SelectedItem;
            switch (preset)
            {
                case TextbeltPresets.Paid:
                    txtTextbeltAPIURL.Text = "http://textbelt.com/text";
                    break;
                default:
                    txtTextbeltAPIKey.Text = String.Empty;
                    break;
            }
        }
    }

    public enum TextbeltPresets
    {
        Paid,
        Custom
    }

    /// <summary>
    /// BULLSHIT intermediate base class becuase the winforms designer can't load anything whos immediate base class is generic... FUCK!
    /// Just pretend this isn't here and go on with your day.
    /// http://stackoverflow.com/questions/13345551/why-do-base-windows-forms-form-class-with-generic-types-stop-the-designer-loadin
    /// </summary>
    public class SMSNotificationEditorBase : StepEditor<SMSNotification>
    {
    }
}
