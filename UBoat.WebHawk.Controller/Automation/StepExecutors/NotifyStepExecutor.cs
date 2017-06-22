using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.Utils;
using UBoat.WebHawk.Controller.Model.Automation.Steps;
using notificationModel = UBoat.WebHawk.Controller.Model.Notification;
using UBoat.WebHawk.Controller.Notification;
using UBoat.WebHawk.Controller.Data;

namespace UBoat.WebHawk.Controller.Automation.StepExecutors
{
    internal class NotifyStepExecutor : StepExecutor<NotifyStep>
    {
        protected override void zExecuteStep()
        {
            string message = DataUtils.ApplyStateVariablesToString(m_Step.Message, CurrentScope.DataScope, m_Step.TrimVariableValueWhitespace);
            foreach (notificationModel.Notification notification in m_Step.Notifications)
            {
                INotify notify = NotifyFactory.GetNotification(notification, m_Context.BrowserHelper.Browser);
                notify.Send("WebHawk Notification", message);
            }

            zCompleteStep(StepResult.Success);
        }
    }
}
