using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.Utils;
using UBoat.Utils.Threading;
using UBoat.Utils.DOM;
using UBoat.WebHawk.Controller.Model.Automation;
using UBoat.WebHawk.Controller.Model.Automation.Steps;
using UBoat.WebHawk.Controller.Automation.Iterators;
using UBoat.WebHawk.Controller.Data;

namespace UBoat.WebHawk.Controller.Automation.StepExecutors
{
    internal abstract class ElementStepExecutor<T> : StepExecutor<T> where T : ElementStep
    {
        protected override void zExecuteStep()
        {
            ElementIdentifier elementIdentifier = zGetElementIdentifier();
            ThreadingUtils.InvokeControlAction(m_Context.BrowserHelper.Browser, ctl =>
            {
                if (m_Step.ElementType == ElementType.Static)
                {
                    HtmlElement element = m_Context.BrowserHelper.FindElement(elementIdentifier, CurrentScope.ElementSetIteratorItem);
                    zElementLocated(element);
                }
                else
                {
                    m_Context.BrowserHelper.PollElement(elementIdentifier, CurrentScope.ElementSetIteratorItem, m_Step.PollingTimeout.Value, zElementLocated);
                }
            });
        }

        private ElementIdentifier zGetElementIdentifier()
        {
            ElementIdentifier elementIdentifier = null;
            if (CurrentScope.ElementSetContainerIdentifier != null)
            {
                elementIdentifier = m_Step.Element.RelativeTo(CurrentScope.ElementSetContainerIdentifier);
            }
            else
            {
                elementIdentifier = m_Step.Element;
            }
            return elementIdentifier;
        }

        private void zElementLocated(HtmlElement element)
        {
            if (element == null)
            {
                zCompleteStep(StepResult.Failed);
                return;
            }
            OnElementLocated(element);
        }

        protected abstract void OnElementLocated(HtmlElement element);
    }
}
