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
    public partial class PopupNotificationEditor : PopupNotificationEditorBase
    {
        public override string Title
        {
            get
            {
                return "Popup Notification";
            }
        }

        public PopupNotificationEditor()
        {
            InitializeComponent();
        }

        public PopupNotificationEditor(StepEditContext context, PopupNotification notification)
            : this()
        {
            this.SetContext(context, notification);
        }

        public override void SetContext(StepEditContext context, PopupNotification notification)
        {
            base.SetContext(context, notification);

            //Nothing to do here...
        }

        public override ValidationResult PerformValidation()
        {
            ValidationResult result = base.PerformValidation();
            return result;
        }

        public override void Save()
        {
            base.Save();

            //Nothing to do here...
        }
    }

    /// <summary>
    /// BULLSHIT intermediate base class becuase the winforms designer can't load anything whos immediate base class is generic... FUCK!
    /// Just pretend this isn't here and go on with your day.
    /// http://stackoverflow.com/questions/13345551/why-do-base-windows-forms-form-class-with-generic-types-stop-the-designer-loadin
    /// </summary>
    public class PopupNotificationEditorBase : StepEditor<PopupNotification>
    {
    }
}
