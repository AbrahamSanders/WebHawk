using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.WebHawk.Controller.Model.Automation.Iterations;
using UBoat.Utils.Validation;

namespace UBoat.WebHawk.UI.StepEditors.IterationEditors
{
    public partial class ConditionalIterationEditor : ConditionalIterationEditorBase
    {
        public override string Title
        {
            get
            {
                return "Conditional Iteration";
            }
        }

        public ConditionalIterationEditor()
        {
            InitializeComponent();
        }

        public ConditionalIterationEditor(StepEditContext context, ConditionalIteration iteration)
            : this()
        {
            this.SetContext(context, iteration);
        }

        public override void SetContext(StepEditContext context, ConditionalIteration iteration)
        {
            base.SetContext(context, iteration);

            cbSkipInitialConditionCheck.Checked = iteration.SkipInitialConditionCheck;
        }

        public override ValidationResult PerformValidation()
        {
            ValidationResult result = base.PerformValidation();
            return result;
        }

        public override void Save()
        {
            this.Target.SkipInitialConditionCheck = cbSkipInitialConditionCheck.Checked;
        }
    }

    /// <summary>
    /// BULLSHIT intermediate base class becuase the winforms designer can't load anything whos immediate base class is generic... FUCK!
    /// Just pretend this isn't here and go on with your day.
    /// http://stackoverflow.com/questions/13345551/why-do-base-windows-forms-form-class-with-generic-types-stop-the-designer-loadin
    /// </summary>
    public class ConditionalIterationEditorBase : StepEditor<ConditionalIteration>
    {
    }
}
