using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.WebHawk.Controller.Model.Automation;
using UBoat.WebHawk.Controller.Model.Automation.Iterations;
using UBoat.Utils.DOM;
using UBoat.WebHawk.Controller.Model.Data;
using UBoat.Utils.Validation;

namespace UBoat.WebHawk.UI.StepEditors.IterationEditors
{
    public partial class ElementSetIterationEditor : ElementSetIterationEditorBase
    {
        private ElementIdentifier m_ContainerIdentifier;

        public override string Title
        {
            get
            {
                return "Element Set Iteration";
            }
        }

        public ElementSetIterationEditor()
        {
            InitializeComponent();
        }

        public ElementSetIterationEditor(StepEditContext context, ElementSetIteration iteration)
            : this()
        {
            this.SetContext(context, iteration);
        }

        public override void SetContext(StepEditContext context, ElementSetIteration iteration)
        {
            base.SetContext(context, iteration);
            m_ContainerIdentifier = this.Target.ElementSetContainer;
            if (m_ContainerIdentifier != null)
            {
                txtElementSetContainer.Text = m_ContainerIdentifier.PrimaryIdentifier;
                btnEdit.Enabled = true;
            }
            rbStaticElement.Checked = this.Target.ElementType == ElementType.Static;
            rbDynamicElement.Checked = this.Target.ElementType == ElementType.Dynamic;
            ipPollingTimeout.Enabled = rbDynamicElement.Checked;
            if (rbDynamicElement.Checked && this.Target.PollingTimeout != null)
            {
                ipPollingTimeout.SetValue(this.Target.PollingTimeout.Value);
            }
            else
            {
                ipPollingTimeout.SetValue(TimeSpan.FromSeconds(5));
            }

            if (this.Target.ObjectSetClassName != null)
            {
                txtObjectClassName.Text = this.Target.ObjectSetClassName;
            }
            if (this.Target.ObjectSetScopeName != null)
            {
                txtScopeName.Text = this.Target.ObjectSetScopeName;
            }

            cbListName.BindEditableStateVariables(this.StepEditContext.StateVariables.Lists(), this.Target.ObjectSetListName, true);

            cbPersistList.Checked = iteration.PersistenceMode == PersistenceMode.Persisted;
    
            cbIncludeInXML.Checked = iteration.IncludeInXML;
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
            this.Target.ElementSetContainer = m_ContainerIdentifier;
            this.Target.ElementType = rbStaticElement.Checked ? ElementType.Static : ElementType.Dynamic;
            this.Target.PollingTimeout = rbDynamicElement.Checked ? ipPollingTimeout.Value.Value : new TimeSpan?();
            this.Target.ObjectSetClassName = !String.IsNullOrWhiteSpace(txtObjectClassName.Text) ? txtObjectClassName.Text : null;
            this.Target.ObjectSetScopeName = !String.IsNullOrWhiteSpace(txtScopeName.Text) ? txtScopeName.Text : null;
            this.Target.ObjectSetListName = !String.IsNullOrWhiteSpace(cbListName.Text) ? cbListName.Text : null;
            this.Target.PersistenceMode = cbPersistList.Checked ? PersistenceMode.Persisted : PersistenceMode.None;
            this.Target.IncludeInXML = cbIncludeInXML.Checked;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (m_ContainerIdentifier != null)
            {
                using (frmElementIdentifierEditor frm = new frmElementIdentifierEditor(m_ContainerIdentifier))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        txtElementSetContainer.Text = m_ContainerIdentifier.PrimaryIdentifier;
                    }
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            using (ElementSetEditor frmElementSetEditor = new ElementSetEditor(this.StepEditContext, m_ContainerIdentifier))
            {
                if (frmElementSetEditor.ShowDialog() == DialogResult.OK)
                {
                    m_ContainerIdentifier = frmElementSetEditor.ContainerIdentifier;
                    txtElementSetContainer.Text = m_ContainerIdentifier.PrimaryIdentifier;
                    btnEdit.Enabled = true;
                }
            }
        }

        private void txtObjectClassName_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtObjectClassName.Text))
            {
                if (String.IsNullOrWhiteSpace(txtScopeName.Text))
                {
                    txtScopeName.Text = txtObjectClassName.Text;
                }
                if (String.IsNullOrWhiteSpace(cbListName.Text))
                {
                    PluralizationService pluralization = PluralizationService.CreateService(CultureInfo.CurrentUICulture);
                    cbListName.Text = pluralization.Pluralize(txtObjectClassName.Text);
                }
            }
        }
    }

    /// <summary>
    /// BULLSHIT intermediate base class becuase the winforms designer can't load anything whos immediate base class is generic... FUCK!
    /// Just pretend this isn't here and go on with your day.
    /// http://stackoverflow.com/questions/13345551/why-do-base-windows-forms-form-class-with-generic-types-stop-the-designer-loadin
    /// </summary>
    public class ElementSetIterationEditorBase : StepEditor<ElementSetIteration>
    {
    }
}
