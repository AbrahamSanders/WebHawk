using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.WebHawk.Controller.Model.Automation.Iterations;

namespace UBoat.WebHawk.UI.StepEditors.IterationEditors
{
    public static class IterationEditorFactory
    {
        public static StepEditor GetIterationEditor(StepEditContext context, Iteration iteration)
        {
            if (iteration is FixedIteration)
            {
                return new FixedIterationEditor(context, (FixedIteration)iteration);
            }
            if (iteration is ConditionalIteration)
            {
                return new ConditionalIterationEditor(context, (ConditionalIteration)iteration);
            }
            if (iteration is ElementSetIteration)
            {
                return new ElementSetIterationEditor(context, (ElementSetIteration)iteration);
            }
            if (iteration is DataSetIteration)
            {
                return new DataSetIterationEditor(context, (DataSetIteration)iteration);
            }

            throw new NotSupportedException();
        }
    }
}
