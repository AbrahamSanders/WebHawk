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
using UBoat.Utils;
using UBoat.Utils.DOM;

namespace UBoat.WebHawk.UI.Wizards.Watch
{
    public partial class WatchWizardDOMSelector : WizardPage
    {
        private HtmlElement m_SelectedElement;
        private string m_SelectedElementStyle;
        private WebBrowserHelper m_BrowserHelper;

        public WatchWizardDOMSelector()
        {
            InitializeComponent();
            m_BrowserHelper = new WebBrowserHelper(wbDOMSelector, TimeSpan.FromSeconds(15));
        }

        protected override void InitPage()
        {
            //NavigateStep navStep = this.Task.TaskSequence.SequenceSteps.OfType<NavigateStep>().First();
            //wbDOMSelector.DocumentCompleted += wbDOMSelector_DocumentCompleted;
            //wbDOMSelector.Navigate(navStep.URL);
        }

        void wbDOMSelector_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            wbDOMSelector.DocumentCompleted -= wbDOMSelector_DocumentCompleted;
            wbDOMSelector.Document.MouseOver += Document_MouseOver;
            //GetValueStep getValueStep = this.Task.TaskSequence.SequenceSteps.OfType<GetValueStep>().First();

            //if (getValueStep.Element != null)
            //{
                //switch (getValueStep.Element.IdentifierType)
                //{
                //    case ElementIdentifierType.ID:
                //        m_BrowserHelper.GetElementById(getValueStep.Element.Identifier, zSelectElement);
                //        break;
                //    case ElementIdentifierType.Path:
                //        m_BrowserHelper.GetElementByPath(getValueStep.Element.Identifier, zSelectElement);
                //        break;
                //    default:
                //        throw new NotSupportedException();
                //}
            //}
        }

        void Document_MouseOver(object sender, HtmlElementEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                zSelectElement(e.ToElement);
            }
        }

        private void zSelectElement(HtmlElement element)
        {
            if (element != null)
            {
                if (m_SelectedElement != null)
                {
                    m_SelectedElement.Style = m_SelectedElementStyle;
                    m_SelectedElement = null;
                }
                if (!String.IsNullOrWhiteSpace(element.OuterText))
                {
                    m_SelectedElement = element;
                    m_SelectedElementStyle = element.Style;
                    lblSelectedElement.Text = m_SelectedElement.OuterText;
                    m_SelectedElement.Style = String.Format("{0}; {1}", m_SelectedElement.Style, "border-style:solid;border-color:red");
                }
                else
                {
                    lblSelectedElement.Text = "None";
                }
                ValidateNext();
            }
        }

        protected override void ValidateNext()
        {
            if (m_SelectedElement != null)
            {
                zOnEnableNext(EventArgs.Empty);
            }
            else
            {
                zOnDisableNext(EventArgs.Empty);
            }
        }

        public override void OnNext()
        {
            //GetValueStep getValueStep = this.Task.TaskSequence.SequenceSteps.OfType<GetValueStep>().First();

            //if (!String.IsNullOrEmpty(m_SelectedElement.Id))
            //{
            //    getValueStep.Element = new ElementIdentifier()
            //    {
            //        IdentifierType = ElementIdentifierType.ID,
            //        Identifier = m_SelectedElement.Id,
            //    };
            //}
            //else
            //{
            //    getValueStep.Element = new ElementIdentifier()
            //    {
            //        IdentifierType = ElementIdentifierType.Path,
            //        Identifier = zBuildElementPath(m_SelectedElement),
            //    };
            //}
            //getValueStep.StateVariable = "WatchElement";
        }

        private string zBuildElementPath(HtmlElement element)
        {
            string path = string.Empty;
            if (element.Parent != null && element.Parent.TagName.ToUpper() != "BODY")
            {
                path = zBuildElementPath(element.Parent);
            }
            return String.Format("{0}/{1}[{2}]", path, element.TagName, zGetElementIndex(element));
        }

        private int zGetElementIndex(HtmlElement element)
        {
            HtmlElement parentElement = element.Parent;
            if (parentElement != null)
            {
                List<HtmlElement> siblings = parentElement.Children.Cast<HtmlElement>().Where(e => e.TagName == element.TagName).ToList();
                for (int x = 0; x < siblings.Count; x++)
                {
                    if (siblings[x] == element)
                    {
                        return x;
                    }
                }
            }
            return 0;
        }
    }
}
