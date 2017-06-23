using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.WebHawk.Controller.Model.Automation.Steps;

namespace UBoat.WebHawk.UI.StepEditors
{
    public static class StepEditorFactory
    {
        public static StepEditor GetStepEditor(StepEditContext context)
        {
            if (context.Step is NavigateStep)
            {
                return new NavigateStepEditor(context);
            }
            if (context.Step is ClickStep)
            {
                return new ClickStepEditor(context);
            }
            if (context.Step is GetValueStep)
            {
                return new GetValueStepEditor(context);
            }
            if (context.Step is SetValueStep)
            {
                return new SetValueStepEditor(context);
            }
            if (context.Step is GroupStep)
            {
                return new GroupStepEditor(context);
            }
            if (context.Step is NotifyStep)
            {
                return new NotifyStepEditor(context);
            }
            if (context.Step is DatabaseStep)
            {
                return new DatabaseStepEditor(context);
            }
            if (context.Step is WaitStep)
            {
                return new WaitStepEditor(context);
            }

            throw new NotSupportedException();
        }
    }
}
