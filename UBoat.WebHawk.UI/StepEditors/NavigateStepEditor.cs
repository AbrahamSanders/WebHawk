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
using UBoat.Utils.Validation;

namespace UBoat.WebHawk.UI.StepEditors
{
    public partial class NavigateStepEditor : StepEditor
    {
        protected NavigateStep Step
        {
            get
            {
                return (NavigateStep)StepEditContext.Step;
            }
        }

        public NavigateStepEditor()
        {
            InitializeComponent();

            cbWaitType.DisplayMember = "Key";
            cbWaitType.ValueMember = "Value";
            cbWaitType.DataSource = new BindingSource(new Dictionary<string, NavigateWaitType>()
            {
                { "Navigated URL Document Complete (Recommended)", NavigateWaitType.UriDocumentComplete },
                { "Any Document Complete (Use only if step hangs)", NavigateWaitType.AnyDocumentComplete }
            }, null);
        }

        public NavigateStepEditor(StepEditContext context)
            : this()
        {
            this.SetContext(context);
        }

        public override void SetContext(StepEditContext context)
        {
            base.SetContext(context);

            urlEditor.SetContext(StepEditContext.StateVariables, Step.URL, Step.TrimVariableValueWhitespace);
            cbWaitType.SelectedValue = Step.WaitType;
        }

        public override ValidationResult PerformValidation()
        {
            ValidationResult result = base.PerformValidation();
            return result;
        }

        public override void Save()
        {
            base.Save();

            Step.URL = this.urlEditor.Value;
            Step.TrimVariableValueWhitespace = this.urlEditor.TrimVariableValueWhitespace;
            Step.WaitType = (NavigateWaitType)cbWaitType.SelectedValue;
        }
    }
}
