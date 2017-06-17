using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using UBoat.Utils.Threading;
using UBoat.Utils.DOM;
using UBoat.WebHawk.Controller.Automation;
using UBoat.WebHawk.Controller.Model.Automation.Steps;
using UBoat.WebHawk.Controller.Model.Automation.Iterations;

namespace UBoat.WebHawk.UI.StepEditors
{
    public partial class GetValueSuggestor : Form
    {
        private AutomationEngine m_AutomationEngine;
        private WebBrowserHelper m_BrowserHelper;
        private StepEditContext m_StepEditContext;
        private StepEditContext m_GroupStepEditContext;
        private ElementIdentifier m_ElementIdentifier;
        private ElementValueMode m_ElementValueMode;
        private string m_AttributeName;

        private List<string> m_Results;

        public List<string> Results
        {
            get
            {
                return m_Results;
            }
        }

        public GetValueSuggestor()
        {
            InitializeComponent();
            this.Disposed += GetValueSuggestor_Disposed;

            m_Results = new List<string>();
            m_BrowserHelper = new WebBrowserHelper(wbPreview);
            olvColumnValue.AspectGetter += (obj) => obj;
        }

        public GetValueSuggestor(StepEditContext stepEditContext, ElementIdentifier elementIdentifier, ElementValueMode elementValueMode, string attributeName) 
            : this()
        {
            m_StepEditContext = stepEditContext;
            GroupStep parentGroupStep = AutomationUtils.GetParentGroupStep(m_StepEditContext.Sequence, m_StepEditContext.Step);
            if (parentGroupStep != null && parentGroupStep.Iteration != null && parentGroupStep.Iteration is ElementSetIteration)
            {
                m_GroupStepEditContext = new StepEditContext(parentGroupStep, m_StepEditContext.Sequence, m_StepEditContext.StepIndex, m_StepEditContext.StateVariables);
            }
            m_ElementIdentifier = elementIdentifier;
            m_ElementValueMode = elementValueMode;
            m_AttributeName = attributeName;
        }

        private void GetValueSuggestor_Load(object sender, EventArgs e)
        {
            m_AutomationEngine = new AutomationEngine(wbPreview);
            m_AutomationEngine.SetSequence(m_StepEditContext.Sequence);
            m_AutomationEngine.ExecutionComplete += m_AutomationEngine_ExecutionComplete;

            int executionScope = m_GroupStepEditContext != null 
                ? m_GroupStepEditContext.GetEditStepPosition()
                : m_StepEditContext.GetEditStepPosition();
            m_AutomationEngine.ExecuteSequence(executionScope);
        }

        void m_AutomationEngine_ExecutionComplete(object sender, ExecutionCompleteEventArgs e)
        {
            m_AutomationEngine.ExecutionComplete -= m_AutomationEngine_ExecutionComplete;

            ElementIdentifier containerIdentifier = null;
            if (m_GroupStepEditContext != null)
            {
                GroupStep groupStep = (GroupStep)m_GroupStepEditContext.Step;
                containerIdentifier = ((ElementSetIteration)groupStep.Iteration).ElementSetContainer;
            }

            ThreadingUtils.InvokeControlAction(this, ctl =>
            {
                zDetect(containerIdentifier);
            });
        }

        private void zDetect(ElementIdentifier containerIdentifier)
        {
            if (containerIdentifier != null)
            {
                m_BrowserHelper.PollElements(containerIdentifier, (containerElements) =>
                {
                    foreach (HtmlElement containerElement in containerElements)
                    {
                        ElementIdentifier relativeIdentifier = m_ElementIdentifier.RelativeTo(containerIdentifier);
                        HtmlElement stepElement = m_BrowserHelper.FindElement(relativeIdentifier, containerElement);
                        if (stepElement != null)
                        {
                            string value = AutomationUtils.GetValueFromHtmlElement(stepElement, m_ElementValueMode, m_AttributeName);
                            if (!String.IsNullOrEmpty(value))
                            {
                                value = value.Trim();
                                if (!m_Results.Contains(value))
                                {
                                    m_Results.Add(value);
                                }
                            }
                        }
                    }
                    zShow();
                });
            }
            else
            {
                m_BrowserHelper.PollElement(m_ElementIdentifier, (getValueElement) =>
                {
                    string value = AutomationUtils.GetValueFromHtmlElement(getValueElement, m_ElementValueMode, m_AttributeName);
                    if (!String.IsNullOrEmpty(value))
                    {
                        value = value.Trim();
                        m_Results.Add(value);
                    }
                    zShow();
                });
            }
        }

        private void zShow()
        {
            olvDetectedValues.SetObjects(m_Results);

            pbLoading.Visible = false;
            olvDetectedValues.Visible = true;
            if (m_Results.Count > 0)
            {
                olvDetectedValues.CheckObjects(olvDetectedValues.Objects);
                btnAdd.Enabled = true;
            }
        }

        private void olvDetectedValues_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            btnAdd.Enabled = olvDetectedValues.CheckedItems.Count > 0;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            m_Results = olvDetectedValues.CheckedObjects
                .Cast<string>()
                .ToList();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        void GetValueSuggestor_Disposed(object sender, EventArgs e)
        {
            if (m_AutomationEngine != null)
            {
                m_AutomationEngine.Dispose();
                m_AutomationEngine = null;
            }
        }
    }
}
