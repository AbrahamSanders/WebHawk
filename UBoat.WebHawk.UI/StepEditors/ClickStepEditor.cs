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
    public partial class ClickStepEditor : ElementStepEditor
    {
        protected ClickStep Step
        {
            get
            {
                return (ClickStep)StepEditContext.Step;
            }
        }

        public ClickStepEditor()
        {
            InitializeComponent();
        }

        public ClickStepEditor(StepEditContext context) 
            : this()
        {
            this.SetContext(context);
        }

        public override void SetContext(StepEditContext context)
        {
            base.SetContext(context);
        }

        public override ValidationResult PerformValidation()
        {
            ValidationResult result = base.PerformValidation();
            return result;
        }

        public override void Save()
        {
            base.Save();
        }
    }
}
