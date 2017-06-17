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
using UBoat.WebHawk.Controller.Model.Conditional;
using UBoat.WebHawk.Controller.Model.Data;

namespace UBoat.WebHawk.UI.Wizards.Watch
{
    public partial class WatchWizardRules : WizardPage
    {
        public WatchWizardRules()
        {
            InitializeComponent();
        }

        protected override void InitPage()
        {
            //NotifyStep notifyStep = this.Task.TaskSequence.SequenceSteps.OfType<NotifyStep>().First();
            //if (notifyStep.Condition != null)
            //{
            //    ExpressionNode expression = (ExpressionNode)notifyStep.Condition;

            //    if (expression.ComparativeOperator == Comparative.GreaterThanOrEquals)
            //    {
            //        rbNumberAboveThreshold.Checked = true;
            //        nudAboveThreshold.Value = Convert.ToDecimal(expression.Value);
            //    }
            //    if (expression.ComparativeOperator == Comparative.LessThanOrEquals)
            //    {
            //        rbNumberBelowThreshold.Checked = true;
            //        nudBelowThreshold.Value = Convert.ToDecimal(expression.Value);
            //    }
            //    if (expression.ComparativeOperator == Comparative.Contains)
            //    {
            //        rbTextContainsPhrase.Checked = true;
            //        txtPhrase.Text = expression.Value;
            //    }
            //}
        }

        private void rbNumberAboveThreshold_CheckedChanged(object sender, EventArgs e)
        {
            nudAboveThreshold.Enabled = true;
            nudBelowThreshold.Enabled = false;
            txtPhrase.Enabled = false;
            zOnEnableNext(EventArgs.Empty);
        }

        private void rbNumberBelowThreshold_CheckedChanged(object sender, EventArgs e)
        {
            nudAboveThreshold.Enabled = false;
            nudBelowThreshold.Enabled = true;
            txtPhrase.Enabled = false;
            zOnEnableNext(EventArgs.Empty);
        }

        private void rbTextContainsPhrase_CheckedChanged(object sender, EventArgs e)
        {
            nudAboveThreshold.Enabled = false;
            nudBelowThreshold.Enabled = false;
            txtPhrase.Enabled = true;
            ValidateNext();
        }

        private void txtPhrase_TextChanged(object sender, EventArgs e)
        {
            ValidateNext();
        }

        protected override void ValidateNext()
        {
            if (rbNumberAboveThreshold.Checked)
            {
                zOnEnableNext(EventArgs.Empty);
                return;
            }
            if (rbNumberBelowThreshold.Checked)
            {
                zOnEnableNext(EventArgs.Empty);
                return;
            }
            if (rbTextContainsPhrase.Checked && !string.IsNullOrWhiteSpace(txtPhrase.Text))
            {
                zOnEnableNext(EventArgs.Empty);
                return;
            }
            zOnDisableNext(EventArgs.Empty);
        }

        public override void OnNext()
        {
            DataType dataType = default(DataType);
            Comparative comp = default(Comparative);
            string value = null;

            if (rbNumberAboveThreshold.Checked)
            {
                dataType = DataType.Numeric;
                comp = Comparative.GreaterThanOrEquals;
                value = nudAboveThreshold.Value.ToString();
            }
            if (rbNumberBelowThreshold.Checked)
            {
                dataType = DataType.Numeric;
                comp = Comparative.LessThanOrEquals;
                value = nudBelowThreshold.Value.ToString();
            }
            if (rbTextContainsPhrase.Checked)
            {
                dataType = DataType.String;
                comp = Comparative.Contains;
                value = txtPhrase.Text;
            }
            //NotifyStep notifyStep = this.Task.TaskSequence.SequenceSteps.OfType<NotifyStep>().First();
            //notifyStep.Condition = new ExpressionNode()
            //{
            //    StateVariable = "WatchElement",
            //    DataType = dataType,
            //    ComparativeOperator = comp,
            //    Value = value
            //};

            //NavigateStep navStep = this.Task.TaskSequence.SequenceSteps.OfType<NavigateStep>().First();
            //notifyStep.Message = zBuildMessage(
            //    this.Task.TaskSequence.Name,
            //    navStep.URL,
            //    ((ExpressionNode)notifyStep.Condition).GetDescription());
        }

        private string zBuildMessage(string sequenceName, string url, string expressionDescription)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("Your watch \"{0}\" has met its criteria: {1}!", sequenceName, expressionDescription));
            sb.AppendLine(String.Format("View at: {0}", url));
            return sb.ToString();
        }
    }
}
