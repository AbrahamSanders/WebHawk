using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.Utils;
using UBoat.WebHawk.Controller.Data;
using UBoat.WebHawk.Controller.Model.Automation.Steps;

namespace UBoat.WebHawk.Controller.Automation.StepExecutors
{
    internal class ClickStepExecutor : ElementStepExecutor<ClickStep>
    {
        protected override void OnElementLocated(HtmlElement element)
        {
            switch (m_Step.ClickType)
            {
                case ClickType.Left:
                    element.InvokeMember("click");
                    break;
                case ClickType.Right:
                    //TODO: right click
                    break;
                default:
                    throw new NotImplementedException();
            }

            zCompleteStep(StepResult.Success);
        }
    }
}
