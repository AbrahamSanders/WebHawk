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

namespace UBoat.WebHawk.UI
{
    public partial class frmCloneSequence : Form, IValidatable
    {
        public string OriginalName
        {
            get
            {
                return txtOriginalName.Text;
            }
            private set
            {
                txtOriginalName.Text = value;
            }
        }

        public string NewName
        {
            get
            {
                return txtNewName.Text;
            }
            private set
            {
                txtNewName.Text = value;
            }
        }

        public frmCloneSequence()
        {
            InitializeComponent();
        }

        public frmCloneSequence(string originalName)
            : this()
        {
            this.OriginalName = originalName;
            this.NewName = String.Format("{0} - Copy", originalName);
        }

        public ValidationResult PerformValidation()
        {
            ValidationResult result = new ValidationResult(true);

            if (String.IsNullOrWhiteSpace(this.NewName))
            {
                result.Append(ValidationResult.WithFailure("Please enter a name for this sequence."));
            }
            else if (!WebHawkAppContext.AutomationController.ValidateNewSequenceName(this.NewName))
            {
                result.Append(ValidationResult.WithFailure(String.Format("The name \"{0}\" is already in use. Please choose another name.", this.NewName)));
            }

            return result;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Validator.ValidateWithPrompt("Clone Sequence", this))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
