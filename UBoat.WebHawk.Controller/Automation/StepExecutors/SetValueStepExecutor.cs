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
    internal class SetValueStepExecutor : ElementStepExecutor<SetValueStep>
    {
        protected override void OnElementLocated(HtmlElement element)
        {
            string value = DataUtils.ApplyStateVariablesToString(m_Step.Value, CurrentScope.DataScope, m_Step.TrimVariableValueWhitespace);
            AutomationUtils.SetValueToHtmlElement(element, m_Step.Mode, m_Step.AttributeName, value);

            zCompleteStep(StepResult.Success);
        }
    }
}
