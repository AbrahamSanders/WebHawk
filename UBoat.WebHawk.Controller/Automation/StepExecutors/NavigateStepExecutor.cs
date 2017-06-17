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
        private string m_Url;

        protected override void zExecuteStep()
        {
            m_Context.BrowserHelper.Browser.DocumentCompleted += m_Browser_DocumentCompleted;

            m_Url = DataUtils.ApplyStateVariablesToString(m_Step.URL, CurrentScope.DataScope, true);
            m_Context.BrowserHelper.Browser.Navigate(m_Url);
        }

        void m_Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url != null && e.Url.ToString().ToLower() == m_Url.ToLower())
            {
                m_Context.BrowserHelper.Browser.DocumentCompleted -= m_Browser_DocumentCompleted;
                zCompleteStep(StepResult.Success);
            }
        }
    }
}
