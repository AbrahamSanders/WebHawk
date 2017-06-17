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
using UBoat.WebHawk.Controller.Model.Automation.Steps;

namespace UBoat.WebHawk.UI
{
    public partial class frmSequenceProperties : Form, IValidatable
    {
        private SequenceDetail m_SequenceDetail;
        private bool m_IsNewSequence;

        public frmSequenceProperties()
        {
            InitializeComponent();
        }

        public frmSequenceProperties(SequenceDetail sequenceDetail, bool isNewSequence) 
            : this()
        {
            m_SequenceDetail = sequenceDetail;
            m_IsNewSequence = isNewSequence;

            if (m_IsNewSequence)
            {
                this.Text = "New Sequence";
                btnSave.Text = "Create";
                groupBox1.Text = "Create New Sequence";
            }
            else
            {
                this.Text = "Sequence Properties";
                btnSave.Text = "Save";
                groupBox1.Text = "Edit Sequence Properties";
            }
        }

        public ValidationResult PerformValidation()
        {
            ValidationResult result = new ValidationResult(true);

            if (String.IsNullOrWhiteSpace(txtSequenceName.Text))
            {
                result.Append(ValidationResult.WithFailure("Please enter a name for this sequence."));
            }
            else if ((m_IsNewSequence || txtSequenceName.Text.ToLower() != m_SequenceDetail.Sequence.Name.ToLower())
                && !WebHawkAppContext.AutomationController.ValidateNewSequenceName(txtSequenceName.Text))
            {
                result.Append(ValidationResult.WithFailure(String.Format("The name \"{0}\" is already in use. Please choose another name.", txtSequenceName.Text)));
            }

            if (!Uri.IsWellFormedUriString(txtStartingURL.Text, UriKind.Absolute))
            {
                result.Append(ValidationResult.WithFailure(String.Format("\"{0}\" is not a valid URL.", txtStartingURL.Text)));
            }

            return result;
        }

        private void frmNewSequence_Load(object sender, EventArgs e)
        {
            txtSequenceName.Text = m_SequenceDetail.Sequence.Name;
            cbSequenceType.DataSource = Enum.GetValues(typeof(SequenceType));
            cbSequenceType.SelectedItem = m_SequenceDetail.Sequence.SequenceType;

            NavigateStep initialNavigateStep = m_SequenceDetail.SequenceSteps.OfType<NavigateStep>().FirstOrDefault();
            if (initialNavigateStep != null)
            {
                txtStartingURL.Text = initialNavigateStep.URL;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validator.ValidateWithPrompt("Save Sequence Properties", this))
            {
                m_SequenceDetail.Sequence.Name = txtSequenceName.Text;
                m_SequenceDetail.Sequence.SequenceType = (SequenceType)cbSequenceType.SelectedItem;

                NavigateStep initialNavigateStep = m_SequenceDetail.SequenceSteps.OfType<NavigateStep>().FirstOrDefault();
                if (initialNavigateStep == null)
                {
                    initialNavigateStep = new NavigateStep();
                    m_SequenceDetail.SequenceSteps.Insert(0, initialNavigateStep);
                }
                initialNavigateStep.URL = txtStartingURL.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
