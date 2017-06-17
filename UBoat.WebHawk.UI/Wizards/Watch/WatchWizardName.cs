using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.WebHawk.Controller.Model.Automation;
using UBoat.WebHawk.Controller.Model.Automation.Steps;

namespace UBoat.WebHawk.UI.Wizards.Watch
{
    public partial class WatchWizardName : WizardPage
    {
        public WatchWizardName()
        {
            InitializeComponent();
        }

        protected override void InitPage()
        {
            if (this.Task.TaskSequence.Name != null)
            {
                txtName.Text = this.Task.TaskSequence.Name;
            }
            //NavigateStep navStep = this.Task.TaskSequence.SequenceSteps.OfType<NavigateStep>().First();
            //txtURL.Text = navStep.URL;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            lblNameExists.Visible = false;
            ValidateNext();
        }

        private void txtURL_TextChanged(object sender, EventArgs e)
        {
            ValidateNext();
        }

        protected override void ValidateNext()
        {
            if (!String.IsNullOrWhiteSpace(txtName.Text) && !String.IsNullOrWhiteSpace(txtURL.Text))
            {
                if (txtName.Text == this.Task.TaskSequence.Name || WebHawkAppContext.AutomationController.ValidateNewSequenceName(txtName.Text))
                {
                    zOnEnableNext(EventArgs.Empty);
                    return;
                }
                else
                {
                    lblNameExists.Visible = true;
                }
            }
            zOnDisableNext(EventArgs.Empty);
        }

        public override void OnNext()
        {
            this.Task.TaskSequence.Name = txtName.Text;
            //NavigateStep navStep = this.Task.TaskSequence.SequenceSteps.OfType<NavigateStep>().First();
            //navStep.URL = txtURL.Text;
        }
    }
}
