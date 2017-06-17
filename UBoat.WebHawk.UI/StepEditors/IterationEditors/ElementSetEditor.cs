using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using web = System.Web.UI.WebControls;

using UBoat.Utils.Threading;
using UBoat.Utils.DOM;
using UBoat.WebHawk.Controller.Automation;
using UBoat.WebHawk.Controller.Model.Automation.Steps;
using UBoat.WebHawk.Controller.Model.Automation.Iterations;
using UBoat.WebHawk.UI.Properties;


namespace UBoat.WebHawk.UI.StepEditors.IterationEditors
{
    public partial class ElementSetEditor : Form
    {
        private AutomationEngine m_AutomationEngine;
        private WebBrowserHelper m_BrowserHelper;
        private ElementSelector m_ContainerSelector;
        private ElementSelector m_PreviewSelector;
        private StepEditContext m_StepEditContext;

        private bool m_Scrolled;
        private ElementIdentifier m_ContainerIdentifier;
        private List<ElementIdentifier> m_Pattern;

        public ElementIdentifier ContainerIdentifier
        {
            get
            {
                return m_ContainerIdentifier;
            }
        }

        public ElementSetEditor()
        {
            InitializeComponent();
            this.Disposed += ElementSetEditor_Disposed;

            m_BrowserHelper = new WebBrowserHelper(wbElementSet);
            m_ContainerSelector = new ElementSelector(wbElementSet);
            m_ContainerSelector.MaxUserSelectionCount = 1;
            m_ContainerSelector.ForceUseTableRow = true;
            m_ContainerSelector.SelectBorderColor = Color.Blue;
            m_ContainerSelector.ElementSelected += m_ContainerSelector_ElementSelected;
            m_ContainerSelector.ElementUnselected += m_ContainerSelector_ElementUnselected;

            m_PreviewSelector = new ElementSelector(wbElementSet);
        }

        public ElementSetEditor(StepEditContext stepEditContext, ElementIdentifier containerIdentifier)
            : this()
        {
            m_StepEditContext = stepEditContext;
            m_ContainerIdentifier = containerIdentifier;
        }

        private void ElementSetEditor_Load(object sender, EventArgs e)
        {
            m_AutomationEngine = new AutomationEngine(wbElementSet);
            m_AutomationEngine.SetSequence(m_StepEditContext.Sequence);
            m_AutomationEngine.ExecutionComplete += m_AutomationEngine_ExecutionComplete;
            m_AutomationEngine.ExecuteSequence(m_StepEditContext.GetEditStepPosition());
        }

        void m_AutomationEngine_ExecutionComplete(object sender, ExecutionCompleteEventArgs e)
        {
            m_AutomationEngine.ExecutionComplete -= m_AutomationEngine_ExecutionComplete;

            GroupStep groupStep = (GroupStep)m_StepEditContext.Step;
            m_Pattern = groupStep.Steps.OfType<ElementStep>().Select(gvs => gvs.Element).ToList();

            ThreadingUtils.InvokeControlAction(this, ctl =>
            {
                if (m_ContainerIdentifier != null)
                {
                    zElementSelected();
                }
                zPreview();

                pbLoading.Visible = false;
                EditorPanel.Visible = true;
            });
        }

        private void btnSelectContainer_Click(object sender, EventArgs e)
        {
            if (m_ContainerSelector.IsActive)
            {
                m_ContainerSelector.Deactivate();
                btnSelectContainer.BackgroundImage = Resources.Pointer;
            }
            else
            {
                m_ContainerSelector.Activate();
                btnSelectContainer.BackgroundImage = Resources.DoneIcon;
            }
        }

        void m_ContainerSelector_ElementUnselected(object sender, ElementSelectorEventArgs e)
        {
            if (e.FromUserAction)
            {
                m_ContainerIdentifier = null;
                txtElementSetContainer.Text = String.Empty;
                btnSelect.Enabled = false;
                zPreview();
            }
        }

        void m_ContainerSelector_ElementSelected(object sender, ElementSelectorEventArgs e)
        {
            if (e.FromUserAction)
            {
                m_ContainerIdentifier = ElementIdentifier.FromHtmlElement(e.Element).RemoveSelector();
                zElementSelected();
                zPreview();
            }
        }

        private void zElementSelected()
        {
            txtElementSetContainer.Text = m_ContainerIdentifier.PrimaryIdentifier;
            btnSelect.Enabled = true;
        }

        private void zPreview()
        {
            m_PreviewSelector.ClearSelection();
            if (m_ContainerIdentifier == null)
            {
                zShowPattern();
            }
            else
            {
                zShowProjection();
            }
        }

        private void zShowPattern()
        {
            foreach (ElementIdentifier identifier in m_Pattern)
            {
                m_BrowserHelper.PollElement(identifier, e => zShowPatternElement(e, true));
            }
        }

        private void zShowProjection()
        {
            m_BrowserHelper.PollElements(m_ContainerIdentifier, (containerElements) =>
            {
                foreach (HtmlElement containerElement in containerElements)
                {
                    zShowPatternElement(containerElement, false);
                    foreach (ElementIdentifier patternIdentifier in m_Pattern)
                    {
                        ElementIdentifier relativePatternIdentifier = patternIdentifier.RelativeTo(m_ContainerIdentifier);
                        HtmlElement patternElement = m_BrowserHelper.FindElement(relativePatternIdentifier, containerElement);
                        zShowPatternElement(patternElement, true);
                    }
                }
            });
        }

        private void zShowPatternElement(HtmlElement patternElement, bool isPattern)
        {
            if (patternElement != null)
            {
                if (!m_PreviewSelector.SelectedElements.Contains(patternElement))
                {
                    m_PreviewSelector.SelectElement(patternElement,
                        System.Web.UI.WebControls.BorderStyle.Dashed,
                        isPattern ? Color.Green : Color.Blue);
                }
                
                if (!m_Scrolled)
                {
                    patternElement.ScrollIntoView(true);
                    m_Scrolled = true;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_ContainerSelector.Deactivate();

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            m_ContainerSelector.Deactivate();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        void ElementSetEditor_Disposed(object sender, EventArgs e)
        {
            if (m_AutomationEngine != null)
            {
                m_AutomationEngine.Dispose();
                m_AutomationEngine = null;
            }
        }
    }
}
