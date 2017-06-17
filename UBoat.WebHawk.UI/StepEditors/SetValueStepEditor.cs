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
    public partial class SetValueStepEditor : ElementStepEditor
    {
        protected SetValueStep Step
        {
            get
            {
                return (SetValueStep)StepEditContext.Step;
            }
        }

        public SetValueStepEditor()
        {
            InitializeComponent();
        }

        public SetValueStepEditor(StepEditContext context)
            : this()
        {
            this.SetContext(context);
        }

        public override void SetContext(StepEditContext context)
        {
            base.SetContext(context);

            setValueSelector.SetContext(Step.Mode, m_ElementIdentifier, Step.AttributeName);
            setValueEditor.SetContext(StepEditContext.StateVariables, Step.Value, Step.TrimVariableValueWhitespace);
        }

        public override ValidationResult PerformValidation()
        {
            ValidationResult result =  base.PerformValidation();
            return result;
        }

        public override void Save()
        {
            base.Save();

            Step.Mode = setValueSelector.ElementValueMode;
            Step.AttributeName = setValueSelector.AttributeName;
            Step.TrimVariableValueWhitespace = setValueEditor.TrimVariableValueWhitespace;
            Step.Value = setValueEditor.Value;
        }
    }
}
