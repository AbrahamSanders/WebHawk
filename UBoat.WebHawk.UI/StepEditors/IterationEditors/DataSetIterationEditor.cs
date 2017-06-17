using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.WebHawk.Controller.Automation;
using UBoat.WebHawk.Controller.Model.Automation.Iterations;
using UBoat.WebHawk.Controller.Model.Automation.Steps;
using UBoat.WebHawk.Controller.Data;
using UBoat.Utils.Validation;


namespace UBoat.WebHawk.UI.StepEditors.IterationEditors
{
    public partial class DataSetIterationEditor : DataSetIterationEditorBase
    {
        private bool m_Loading;

        public override string Title
        {
            get
            {
                return "Data Set Iteration";
            }
        }

        public DataSetIterationEditor()
        {
            InitializeComponent();
        }

        public DataSetIterationEditor(StepEditContext context, DataSetIteration iteration)
            : this()
        {
            this.SetContext(context, iteration);
        }

        public override void SetContext(StepEditContext context, DataSetIteration iteration)
        {
            base.SetContext(context, iteration);

            m_Loading = true;
            cbListVariableList.DataSource = context.StateVariables.Lists();
            if (iteration.ObjectSetListName != null)
            {
                cbListVariableList.Text = iteration.ObjectSetListName;
            }
            if (iteration.ObjectSetClassName != null)
            {
                cbObjectClassList.Text = iteration.ObjectSetClassName;
            }
            else
            {
                cbObjectClassList.Text = "[Any]";
            }
            if (this.Target.ObjectSetScopeName != null)
            {
                txtScopeName.Text = this.Target.ObjectSetScopeName;
            }
            m_Loading = false;
        }

        public override ValidationResult PerformValidation()
        {
            ValidationResult result = base.PerformValidation();
            return result;
        }

        public override void Save()
        {
            this.Target.ObjectSetListName = cbListVariableList.SelectedIndex > -1 
                ? Convert.ToString(cbListVariableList.SelectedItem) 
                : null;
            this.Target.ObjectSetClassName = cbObjectClassList.SelectedIndex > -1 && Convert.ToString(cbObjectClassList.SelectedItem) != "[Any]"
                ? Convert.ToString(cbObjectClassList.SelectedItem) 
                : null;
            this.Target.ObjectSetScopeName = !String.IsNullOrWhiteSpace(txtScopeName.Text) 
                ? txtScopeName.Text 
                : null;
        }

        private void cbListVariableList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbListVariableList.SelectedIndex > -1)
            {
                List<string> availableClassList = AutomationUtils.GetListClassNamesInStepScope(this.StepEditContext.Sequence, this.StepEditContext.Step, Convert.ToString(cbListVariableList.SelectedItem));
                availableClassList.Insert(0, "[Any]");
                cbObjectClassList.DataSource = availableClassList;
            }
        }

        private void cbObjectClassList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbListVariableList.SelectedIndex > -1 && cbObjectClassList.SelectedIndex > -1)
            {
                string listVariableName = Convert.ToString(cbListVariableList.SelectedItem);
                string objectClassName = Convert.ToString(cbObjectClassList.SelectedItem);
                string suggestedScopeName = zGetSuggestedScopeName(listVariableName, objectClassName);
                if (String.IsNullOrWhiteSpace(txtScopeName.Text))
                {
                    txtScopeName.Text = suggestedScopeName;
                }
                else if (txtScopeName.Text != suggestedScopeName && !m_Loading)
                {
                    bool changeScopeName = MessageBox.Show(
                        String.Format("The current Scope Name is \"{0}\". Would you like to change it to \"{1}\" in order to better represent the selected Object Class \"{2}\"?", 
                            txtScopeName.Text, 
                            suggestedScopeName, 
                            objectClassName), 
                        "Object Class Changed", 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Question) == DialogResult.Yes;
                    if (changeScopeName)
                    {
                        txtScopeName.Text = suggestedScopeName;
                    }
                }
            }
        }

        private string zGetSuggestedScopeName(string listVariableName, string objectClassName)
        {
            string suggestedScopeName;
            if (objectClassName == "[Any]")
            {
                suggestedScopeName = String.Format("{0}{1}Item",
                    DataUtils.GetUnscopedVariableName(listVariableName),
                    listVariableName.ToLower().EndsWith("list") ? String.Empty : "List");
            }
            else
            {
                suggestedScopeName = objectClassName;
            }
            return suggestedScopeName;
        }
    }

    /// <summary>
    /// BULLSHIT intermediate base class becuase the winforms designer can't load anything whos immediate base class is generic... FUCK!
    /// Just pretend this isn't here and go on with your day.
    /// http://stackoverflow.com/questions/13345551/why-do-base-windows-forms-form-class-with-generic-types-stop-the-designer-loadin
    /// </summary>
    public class DataSetIterationEditorBase : StepEditor<DataSetIteration>
    {
    }
}
