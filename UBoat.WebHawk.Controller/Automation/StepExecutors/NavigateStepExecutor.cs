using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.Utils;
using UBoat.Utils.Threading;
using UBoat.WebHawk.Controller.Data;
using UBoat.WebHawk.Controller.Model.Automation.Steps;

namespace UBoat.WebHawk.Controller.Automation.StepExecutors
{
    internal class NavigateStepExecutor : StepExecutor<NavigateStep>
    {
        protected override void zExecuteStep()
        {
            m_Context.BrowserHelper.Browser.DocumentCompleted += m_Browser_DocumentCompleted;

            string url = DataUtils.ApplyStateVariablesToString(m_Step.URL, CurrentScope.DataScope, true);
            m_Context.BrowserHelper.Browser.Navigate(url);
        }

        void m_Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (m_Step.WaitType == NavigateWaitType.AnyDocumentComplete 
                || (e.Url != null && e.Url == m_Context.BrowserHelper.Browser.Url))
            {
                m_Context.BrowserHelper.Browser.DocumentCompleted -= m_Browser_DocumentCompleted;
                zCompleteStep(StepResult.Success);
            }
        }
    }
}
