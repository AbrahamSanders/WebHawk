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
using UBoat.Utils.DOM;
using UBoat.Utils.Validation;

namespace UBoat.WebHawk.UI.StepEditors
{
    public partial class ElementStepEditor : StepEditor
    {
        private ElementStep Step
        {
            get
            {
                return (ElementStep)StepEditContext.Step;
            }
        }

        protected ElementIdentifier m_ElementIdentifier;

        public ElementStepEditor()
        {
            InitializeComponent();
        }

        public override void SetContext(StepEditContext context)
        {
            base.SetContext(context);

            m_ElementIdentifier = Step.Element != null ? ElementIdentifier.Copy(Step.Element) : new ElementIdentifier();
            txtElementPath.Text = m_ElementIdentifier.PrimaryIdentifier;
            rbStaticElement.Checked = Step.ElementType == ElementType.Static;
            rbDynamicElement.Checked = Step.ElementType == ElementType.Dynamic;
            ipPollingTimeout.Enabled = rbDynamicElement.Checked;
            if (rbDynamicElement.Checked && Step.PollingTimeout != null)
            {
                ipPollingTimeout.SetValue(Step.PollingTimeout.Value);
            }
            else
            {
                ipPollingTimeout.SetValue(TimeSpan.FromSeconds(5));
            }
        }

        private void rbDynamicElement_CheckedChanged(object sender, EventArgs e)
        {
            ipPollingTimeout.Enabled = rbDynamicElement.Checked;
        }

        public override ValidationResult PerformValidation()
        {
            ValidationResult result = base.PerformValidation();
            return result;
        }

        public override void Save()
        {
            base.Save();

            Step.Element = m_ElementIdentifier;
            Step.ElementType = rbStaticElement.Checked ? ElementType.Static : ElementType.Dynamic;
            Step.PollingTimeout = rbDynamicElement.Checked ? ipPollingTimeout.Value.Value : new TimeSpan?();
        }

        private void btnEditElementIdentifier_Click(object sender, EventArgs e)
        {
            using (frmElementIdentifierEditor frm = new frmElementIdentifierEditor(m_ElementIdentifier))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    txtElementPath.Text = m_ElementIdentifier.PrimaryIdentifier;
                }
            }
        }
    }
}
