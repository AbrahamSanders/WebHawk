using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.WebHawk.Controller.Data;
using UBoat.WebHawk.Controller.Automation;
using UBoat.WebHawk.Controller.Model.Automation.Steps;
using UBoat.WebHawk.Controller.Model.Data;
using UBoat.Utils;
using UBoat.Utils.Threading;
using UBoat.Utils.DOM;
using UBoat.WebHawk.UI.Properties;


namespace UBoat.WebHawk.UI
{
    public partial class SequenceRecorder : UserControl
    {
        #region Private Members

        private readonly object m_Lock;
        private bool m_RecordingEnabled;
        private bool m_RecordingActive;
        private bool m_Executing;
        private AutomationEngine m_AutomationEngine;
        private HashSet<HtmlElement> m_ElementsWithHandlers;
        private ElementSelector m_ElementSelector;
        private ElementSelectMode m_ElementSelectMode;
        private int m_VariableGen;
        private Dictionary<Step, int> m_StepIndex;
        private WebBrowserHelper m_BrowserHelper;
        private Step m_CurrentStep;
        private bool m_IsDirty;

        private enum ElementSelectMode
        {
            Get,
            Set
        }

        #endregion

        #region Public Properties

        public bool IsExecuting
        {
            get
            {
                return m_Executing;
            }
        }

        public bool RecordingEnabled
        {
            get
            {
                return m_RecordingEnabled;
            }
            set
            {
                m_RecordingEnabled = value;
                if (value)
                {
                    zEnableRecording();
                }
                else
                {
                    zDisableRecording();
                }
            }
        }

        public AutomationEngine AutomationEngine
        {
            get
            {
                return m_AutomationEngine;
            }
        }

        public List<Step> SequenceSteps
        {
            get
            {
                return m_AutomationEngine != null 
                    ? m_AutomationEngine.Sequence 
                    : null;
            }
        }

        public bool IsDirty
        {
            get
            {
                return m_IsDirty;
            }
        }

        #endregion

        #region Constructors

        public SequenceRecorder()
        {
            InitializeComponent();

            m_Lock = new object();
            m_BrowserHelper = new WebBrowserHelper(wbRecorder);
            m_AutomationEngine = new AutomationEngine(wbRecorder);
            m_ElementsWithHandlers = new HashSet<HtmlElement>();
            m_ElementSelector = new ElementSelector(wbRecorder);
            m_ElementSelector.ElementSelected += m_ElementSelector_ElementSelected;
            m_StepIndex = new Dictionary<Step, int>();

            tlvSequence.FormatRow += tlvSequence_FormatRow;
            tlvSequence.CanExpandGetter = zCanExpandGetter;
            tlvSequence.ChildrenGetter = zChildrenGetter;
            tlvSequence.HotItemStyle = new BrightIdeasSoftware.HotItemStyle()
            {
                Decoration = new BrightIdeasSoftware.RowBorderDecoration()
                {
                    BorderPen = new Pen(Color.Transparent, 2),
                    BoundsPadding = new Size(1, 1),
                    CornerRounding = 4.0f
                }
            };
            BrightIdeasSoftware.SimpleDropSink sink = (BrightIdeasSoftware.SimpleDropSink)tlvSequence.DropSink;
            sink.CanDropBetween = true;

            olvColumnOrder.AspectGetter = zOrderAspectGetter;
            olvColumnOrder.ImageGetter = zOrderImageGetter;
            olvColumnHasCondition.ImageGetter = zHasConditionImageGetter;
            olvColumnIsIteration.ImageGetter = zIsIterationImageGetter;
            olvColumnEdit.AspectGetter = (obj) => "Edit...";
            olvColumnDelete.AspectGetter = (obj) => "Remove";
            olvColumnExecute.AspectGetter = (obj) => "Go!";

            tlvVariables.CanExpandGetter = zVariableCanExpandGetter;
            tlvVariables.ChildrenGetter = zVariableChildrenGetter;
            olvColumnVariableValue.AspectGetter = zVariableValueAspectGetter;
            
            imageListSequence.Images.AddRange(new Image[]
            {
                Resources.GreenArrow,
                Resources.RedArrow,
                Resources.Document,
                Resources.Iteration
            });

            cbAvailableStepList.DataSource = Step.GetAvailableStepList(false)
                .OrderBy(s => s.DisplayName)
                .ToList();
        }

        public SequenceRecorder(List<Step> sequence) : this()
        {
            SetSequence(sequence);
        }

        #endregion

        #region Public Methods

        public void SetSequence(List<Step> sequence)
        {
            m_AutomationEngine.SetSequence(sequence);
            m_AutomationEngine.StepBegin += m_AutomationEngine_StepBegin;
            m_AutomationEngine.StepComplete += m_AutomationEngine_StepComplete;
            m_AutomationEngine.ExecutionBegin += m_AutomationEngine_ExecutionBegin;
            m_AutomationEngine.ExecutionComplete += m_AutomationEngine_ExecutionComplete;
            zRefreshSteps();
            btnToggleRecording.Enabled = true;
        }

        public void ResetIsDirtyFlag()
        {
            m_IsDirty = false;
        }

        public void ExecuteSequence()
        {
            ExecuteSequence(Int32.MaxValue);
        }

        public void ExecuteSequence(int executionScope)
        {
            if (!m_Executing)
            {
                m_Executing = true;
                zPauseRecording();

                m_AutomationEngine.ExecuteSequence(executionScope);
            }
        }

        public void StopExecution()
        {
            m_AutomationEngine.StopExecution();
        }

        #endregion

        #region Private Methods

        #region Sequence Execution

        void m_AutomationEngine_StepBegin(object sender, StepEventArgs e)
        {
            ThreadingUtils.InvokeControlAction(tlvSequence, tlv =>
            {
                tlv.ExpandToObject(m_AutomationEngine.CurrentStep);
                tlv.RefreshObject(m_AutomationEngine.CurrentStep);
                tlv.Refresh();
            });
        }

        void m_AutomationEngine_StepComplete(object sender, StepEventArgs e)
        {
            if (cbRefreshVariablesInRealTime.Checked)
            {
                zRefreshVariables();
            }
        }

        void m_AutomationEngine_ExecutionBegin(object sender, ExecutionBeginEventArgs e)
        {
            ThreadingUtils.InvokeControlAction(this, ctl =>
            {
                zOnExecutionStart(EventArgs.Empty);
            });
        }

        void m_AutomationEngine_ExecutionComplete(object sender, ExecutionCompleteEventArgs e)
        {
            zRefreshVariables();
            m_Executing = false;
            ThreadingUtils.InvokeControlAction(this, ctl =>
            {
                zResumeRecording();
                zSelectAllStepElements();

                zOnExecutionStop(EventArgs.Empty);
            });
        }

        #endregion

        #region Step Management

        void tlvSequence_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
        {
            if (e.Model == m_CurrentStep)
            {
                e.Item.Decoration = new BrightIdeasSoftware.RowBorderDecoration()
                {
                    BorderPen = new Pen(Color.Transparent, 2),
                    BoundsPadding = new Size(1, 1),
                    CornerRounding = 4.0f
                };
            }
        }

        private bool zCanExpandGetter(object obj)
        {
            return obj is GroupStep;
        }

        private IEnumerable zChildrenGetter(object obj)
        {
            return ((GroupStep)obj).Steps;
        }

        private object zOrderAspectGetter(object obj)
        {
            Step step = (Step)obj;
            int stepOrder = m_StepIndex[step];
            
            int whitespaceCount = 5 - stepOrder.ToString().Length;
            StringBuilder whitespace = new StringBuilder();
            for (int x = 0; x < whitespaceCount; x++)
            {
                whitespace.Append(" ");
            }

            return String.Format("{0}. {1}{2}", stepOrder, whitespace.ToString(), step.DisplayName);
        }

        private object zOrderImageGetter(object obj)
        {
            if (m_AutomationEngine.CurrentStep == (Step)obj)
            {
                return 0;
            }
            return -1;
        }

        private object zHasConditionImageGetter(object obj)
        {
            if (((Step)obj).Condition != null)
            {
                return 2;
            }
            return -1;
        }

        private object zIsIterationImageGetter(object obj)
        {
            if (obj is GroupStep && ((GroupStep)obj).Iteration != null)
            {
                return 3;
            }
            return -1;
        }

        private bool zVariableCanExpandGetter(object obj)
        {
            return obj is ListStateVariable || obj is ObjectStateVariable;
        }

        private IEnumerable zVariableChildrenGetter(object obj)
        {
            if (obj is ListStateVariable)
            {
                return ((ListStateVariable)obj).Value;
            }
            if (obj is ObjectStateVariable)
            {
                return ((ObjectStateVariable)obj).Value.Values.ToList();
            }
            throw new NotSupportedException();
        }

        private object zVariableValueAspectGetter(object obj)
        {
            return ((IStateVariable)obj).ValueAsString();

            //IStateVariable variable;
            //if (m_AutomationEngine.DataContext.StateVariables.TryGetValue(((GetValueStep)obj).StateVariable, out variable))
            //{
            //    return variable.ValueAsString();
            //}
            //return String.Empty;
        }

        private void btnAddStep_Click(object sender, EventArgs e)
        {
            Step availableStep = (Step)cbAvailableStepList.SelectedItem;
            Step newStep = Step.CreateInstance(availableStep.GetType());
            zAddStep(newStep);
        }

        private void zAddStep(Step step)
        {
            List<Step> container;
            int containerIndex;
            if (m_CurrentStep != null)
            {
                container = AutomationUtils.GetStepParent(m_AutomationEngine.Sequence, m_CurrentStep);
                containerIndex = container.IndexOf(m_CurrentStep);
            }
            else
            {
                container = m_AutomationEngine.Sequence;
                containerIndex = m_AutomationEngine.Sequence.Count - 1;
            }
            container.Insert(containerIndex + 1, step);
            m_CurrentStep = step;

            m_AutomationEngine.ResetSequence();
            zFullRefreshSteps();

            zOnSequenceChanged(EventArgs.Empty);
        }

        private void zRemoveSteps(IEnumerable<Step> steps)
        {
            if (steps.Count() > 0)
            {
                foreach (Step step in steps)
                {
                    List<Step> stepContainer = AutomationUtils.GetStepParent(m_AutomationEngine.Sequence, step);

                    int containerIndex = stepContainer.IndexOf(step);
                    stepContainer.Remove(step);

                    containerIndex = stepContainer.Count > containerIndex ? containerIndex : stepContainer.Count - 1;
                    if (containerIndex > -1)
                    {
                        m_CurrentStep = stepContainer[containerIndex];
                    }
                    else
                    {
                        m_CurrentStep = null;
                    }

                    if (step is GroupStep)
                    {
                        GroupStep groupStep = (GroupStep)step;
                        if (groupStep.Steps.Count > 0)
                        {
                            stepContainer.AddRange(groupStep.Steps);
                        }
                    }
                }

                m_AutomationEngine.ResetSequence();

                IList selectedObjects = tlvSequence.SelectedObjects;
                zFullRefreshSteps();
                tlvSequence.SelectedObjects = selectedObjects;

                zOnSequenceChanged(EventArgs.Empty);
            }
        }

        private void btnGroupSteps_Click(object sender, EventArgs e)
        {
            zGroupSteps(tlvSequence.SelectedObjects.Cast<Step>().ToList());
        }

        private void zGroupSteps(List<Step> steps)
        {
            if (steps.Count > 0)
            {
                GroupStep groupStep = new GroupStep();

                List<Step> container = AutomationUtils.GetStepParent(m_AutomationEngine.Sequence, steps.First());
                int groupIndex = container.IndexOf(steps.First());
                foreach (Step step in steps)
                {
                    if (AutomationUtils.GetStepParent(m_AutomationEngine.Sequence, step) == container)
                    {
                        container.Remove(step);
                        groupStep.Steps.Add(step);
                    }
                }
                container.Insert(groupIndex, groupStep);
                m_CurrentStep = steps.Last();

                m_AutomationEngine.ResetSequence();
                zFullRefreshSteps();

                zOnSequenceChanged(EventArgs.Empty);
            }
        }

        private void zRefreshSteps()
        {
            zBuildStepIndex();
            ThreadingUtils.InvokeControlAction(tlvSequence, tlv =>
            {
                tlv.SetObjects(m_AutomationEngine.Sequence, true);
            });

            zRefreshVariables();
        }

        private void zFullRefreshSteps()
        {
            tlvSequence.ClearObjects();
            zRefreshSteps();
            tlvSequence.RefreshObjects(m_AutomationEngine.Sequence);

            tlvSequence.ExpandAll();
        }

        private void zBuildStepIndex()
        {
            m_StepIndex.Clear();
            int counter = 1;
            zBuildStepIndexRecursive(m_AutomationEngine.Sequence, ref counter);
        }

        private void zBuildStepIndexRecursive(List<Step> sequence, ref int counter)
        {
            foreach (Step step in sequence)
            {
                m_StepIndex.Add(step, counter);
                counter++;

                if (step is GroupStep)
                {
                    zBuildStepIndexRecursive(((GroupStep)step).Steps, ref counter);
                }
            }
        }

        private void zRefreshVariables()
        {
            ThreadingUtils.InvokeControlAction(tlvVariables, tv =>
            {
                tlvVariables.SetObjects(m_AutomationEngine.DataContext.StateVariables.Values, true);
                tlvVariables.RefreshObjects(m_AutomationEngine.DataContext.StateVariables.Values.ToList());
            });
        }

        private void tlvSequence_HyperlinkClicked(object sender, BrightIdeasSoftware.HyperlinkClickedEventArgs e)
        {
            Step step = (Step)e.Model;

            if (e.Column == olvColumnEdit)
            {
                zEditStep(step);
            }
            if (e.Column == olvColumnDelete)
            {
                zRemoveSteps(new List<Step>() { step });
            }
            if (e.Column == olvColumnExecute)
            {
                ExecuteSequence(m_StepIndex[step]);
            }
            e.Handled = true;
        }

        private void tlvSequence_CellRightClick(object sender, BrightIdeasSoftware.CellRightClickEventArgs e)
        {
            stepEditToolStripMenuItem.Enabled = tlvSequence.SelectedObjects.Count == 1;
            stepGoToThisStepToolStripMenuItem.Enabled = tlvSequence.SelectedObjects.Count == 1;
            stepCutToolStripMenuItem.Enabled = tlvSequence.SelectedObjects.Count > 0;
            stepCopyToolStripMenuItem.Enabled = tlvSequence.SelectedObjects.Count > 0;
            stepPasteToolStripMenuItem.Enabled = zClipboardHasSteps() && tlvSequence.SelectedObjects.Count < 2;
            stepRemoveToolStripMenuItem.Enabled = tlvSequence.SelectedObjects.Count > 0;

            e.MenuStrip = stepsMenu;
        }

        private void stepEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zEditStep((Step)tlvSequence.SelectedObject);
        }

        private void stepGoToThisStepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteSequence(m_StepIndex[(Step)tlvSequence.SelectedObject]);
        }

        private void stepCutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zCopyStepsToClipboard(tlvSequence.SelectedObjects.Cast<Step>(), true);
        }

        private void stepCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zCopyStepsToClipboard(tlvSequence.SelectedObjects.Cast<Step>(), false);
        }

        private void stepPasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zPasteStepsFromClipboard((Step)tlvSequence.SelectedObject);
        }

        private void stepRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zRemoveSteps(tlvSequence.SelectedObjects.Cast<Step>());
        }

        private void zEditStep(Step step)
        {
            List<StateVariableInfo> variables = AutomationUtils.GetVariablesInStepScope(m_AutomationEngine.Sequence, step);
            StepEditContext editContext = new StepEditContext(step, m_AutomationEngine.Sequence, m_StepIndex, variables);

            DialogResult result;
            using (frmStepEditor editor = new frmStepEditor(editContext))
            {
                result = editor.ShowDialog();
            }
            zRefreshSteps();
            if (result == DialogResult.OK)
            {
                zOnSequenceChanged(EventArgs.Empty);
            }
        }

        private void tlvSequence_SelectionChanged(object sender, EventArgs e)
        {
            btnGroupSteps.Enabled = zCanGroupSelection();
        }

        private bool zCanGroupSelection()
        {
            if (tlvSequence.SelectedIndices.Count == 0)
            {
                return false;
            }
            for (int x = 0; x < tlvSequence.SelectedIndices.Count - 1; x++)
            {
                if (tlvSequence.SelectedIndices[x + 1] > tlvSequence.SelectedIndices[x] + 1)
                {
                    return false;
                }
            }
            return true;
        }

        private void tlvSequence_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            m_CurrentStep = (Step)e.Model;
            zRefreshSteps();
        }

        private void btnRefreshVariables_Click(object sender, EventArgs e)
        {
            zRefreshVariables();
        }

        private void tlvSequence_ModelCanDrop(object sender, BrightIdeasSoftware.ModelDropEventArgs e)
        {
            e.Handled = true;
            e.DropSink.CanDropOnItem = e.TargetModel is GroupStep;
            if (e.DropTargetLocation == BrightIdeasSoftware.DropTargetLocation.None)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            foreach (object sourceModel in e.SourceModels)
            {
                if (sourceModel == e.TargetModel
                    || (e.DropTargetLocation == BrightIdeasSoftware.DropTargetLocation.Item
                        && (!(e.TargetModel is GroupStep) || tlvSequence.GetParent(sourceModel) == e.TargetModel))
                    || tlvSequence.IsAncestor(e.TargetModel, sourceModel))
                {
                    e.Effect = DragDropEffects.None;
                    return;
                }
            }
            e.Effect = DragDropEffects.Move;
        }

        private void tlvSequence_ModelDropped(object sender, BrightIdeasSoftware.ModelDropEventArgs e)
        {
            e.Handled = true;
            Step targetStep = (Step)e.TargetModel;
            IEnumerable<Step> toMove = e.SourceModels.Cast<Step>();
            toMove = zCopySteps(toMove, true);
            switch (e.DropTargetLocation)
            {
                case BrightIdeasSoftware.DropTargetLocation.AboveItem:
                    zPasteSteps(toMove, targetStep, 0);
                    break;
                case BrightIdeasSoftware.DropTargetLocation.BelowItem:
                    zPasteSteps(toMove, targetStep, 1);
                    break;
                case BrightIdeasSoftware.DropTargetLocation.Item:
                    zPasteSteps(toMove, targetStep, -1);
                    break;
                default:
                    return;
            }
        }

        private void tlvSequence_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.C || e.KeyCode == Keys.X)
                {
                    bool isCut = e.KeyCode == Keys.X;
                    zCopyStepsToClipboard(tlvSequence.SelectedObjects.Cast<Step>(), isCut);
                    e.Handled = true;
                }
                if (e.KeyCode == Keys.V)
                {
                    zPasteStepsFromClipboard(m_CurrentStep);
                    e.Handled = true;
                }
            }

            if (e.KeyCode == Keys.Delete)
            {
                zRemoveSteps(tlvSequence.SelectedObjects.Cast<Step>());
                e.Handled = true;
            }
        }

        private bool zClipboardHasSteps()
        {
            IDataObject iData = Clipboard.GetDataObject();
            if (iData != null && iData.GetDataPresent(typeof(List<Step>)))
            {
                return true;
            }
            return false;
        }

        private void zCopyStepsToClipboard(IEnumerable<Step> stepsToCopy, bool isCut)
        {
            List<Step> copiedSteps = zCopySteps(tlvSequence.SelectedObjects.Cast<Step>(), isCut);
            if (copiedSteps.Count > 0)
            {
                Clipboard.SetDataObject(copiedSteps);
            }
        }

        private List<Step> zCopySteps(IEnumerable<Step> stepsToCopy, bool isCut)
        {
            List<Step> copiedSteps = new List<Step>();
            if (stepsToCopy.Count() > 0)
            {
                //Copy operation
                Dictionary<Guid, Step> steps = stepsToCopy.ToDictionary(s => Guid.NewGuid(), s => s);
                byte[] stepsDeepCopyBytes = Converter.ToBinary(steps);
                Dictionary<Guid, Step> stepsLookup = Converter.FromBinary<Dictionary<Guid, Step>>(stepsDeepCopyBytes);

                foreach (KeyValuePair<Guid, Step> stepKVP in stepsLookup)
                {
                    if (stepKVP.Value is GroupStep)
                    {
                        ((GroupStep)stepKVP.Value).Steps.Clear();
                    }
                    Step originalStep = steps[stepKVP.Key];
                    GroupStep originalStepAncestor;
                    while (true)
                    {
                        originalStepAncestor = AutomationUtils.GetParentGroupStep(m_AutomationEngine.Sequence, originalStep);
                        if (originalStepAncestor == null)
                        {
                            copiedSteps.Add(stepKVP.Value);
                            break;
                        }
                        if (steps.ContainsValue(originalStepAncestor))
                        {
                            Guid originalStepAncestorKey = steps.First(kvp => kvp.Value == originalStepAncestor).Key;
                            GroupStep parentCopiedStep = (GroupStep)stepsLookup[originalStepAncestorKey];
                            parentCopiedStep.Steps.Add(stepKVP.Value);
                            break;
                        }
                        originalStep = originalStepAncestor;
                    }
                }

                //Cut operation
                if (isCut)
                {
                    zRemoveSteps(steps.Values);
                }

                //Cleanup & persist to clipboard
                steps.Clear();
                stepsLookup.Clear();
            }
            return copiedSteps;
        }

        private void zPasteStepsFromClipboard(Step pasteTarget)
        {
            IDataObject iData = Clipboard.GetDataObject();
            if (iData != null && iData.GetDataPresent(typeof(List<Step>)))
            {
                try
                {
                    List<Step> stepsFromClipboard = stepsFromClipboard = (List<Step>)iData.GetData(typeof(List<Step>));
                    zPasteSteps(stepsFromClipboard, m_CurrentStep, 1);
                }
                catch (Exception ex)
                {
                    //TODO: log that data could not be pasted.
                }
            }
        }

        private void zPasteSteps(IEnumerable<Step> stepsToPaste, Step pasteTarget, int siblingOffset)
        {
            if (stepsToPaste != null && stepsToPaste.Count() > 0)
            {
                if (pasteTarget != null)
                {
                    if (siblingOffset == -1)
                    {
                        GroupStep targetGroupStep = (GroupStep)pasteTarget;
                        targetGroupStep.Steps.AddRange(stepsToPaste);
                    }
                    else
                    {
                        List<Step> container = AutomationUtils.GetStepParent(m_AutomationEngine.Sequence, pasteTarget);
                        container.InsertRange(container.IndexOf(pasteTarget) + siblingOffset, stepsToPaste);
                    }
                }
                else
                {
                    m_AutomationEngine.Sequence.AddRange(stepsToPaste);
                }

                m_CurrentStep = stepsToPaste.Last();
                m_AutomationEngine.ResetSequence();

                IList selectedObjects = tlvSequence.SelectedObjects;
                zFullRefreshSteps();
                tlvSequence.SelectedObjects = selectedObjects;

                zOnSequenceChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region Recorder Management

        private void btnToggleRecording_Click(object sender, EventArgs e)
        {
            if (!RecordingEnabled)
            {
                RecordingEnabled = true;
            }
            else
            {
                RecordingEnabled = false;
            }
        }

        private void zStartRecording()
        {
            if (!m_RecordingActive)
            {
                if (wbRecorder.Document != null)
                {
                    wbRecorder.Document.MouseUp += Document_MouseUp;
                    wbRecorder.Document.Focusing += Document_Focusing;
                }
                btnSelectGetElement.Enabled = true;
                btnSelectSetElement.Enabled = true;
                m_RecordingActive = true;
            }
        }

        private void zStopRecording()
        {
            if (m_RecordingActive)
            {
                if (wbRecorder.Document != null)
                {
                    wbRecorder.Document.MouseUp -= Document_MouseUp;
                    wbRecorder.Document.Focusing -= Document_Focusing;
                }
                zRemoveElementEventHandlers();
                zDisableSelectMode();
                btnSelectGetElement.Enabled = false;
                btnSelectSetElement.Enabled = false;
                m_RecordingActive = false;
            }
        }

        private void zEnableRecording()
        {
            btnToggleRecording.BackgroundImage = Resources.StopIcon;
            lblRecordingStatus.Text = "Recording";
            pbRecordingStatus.Image = Resources.GreenCircle;
            zStartRecording();
        }

        private void zDisableRecording()
        {
            btnToggleRecording.BackgroundImage = Resources.PlayIcon;
            lblRecordingStatus.Text = "Not Recording";
            pbRecordingStatus.Image = Resources.RedCircle;
            zStopRecording();
        }

        private void zPauseRecording()
        {
            if (m_RecordingEnabled)
            {
                zStopRecording();
                lblRecordingStatus.Text = "Recording Paused";
                pbRecordingStatus.Image = Resources.YellowCircle;
            }
        }

        private void zResumeRecording()
        {
            if (m_RecordingEnabled)
            {
                zStartRecording();
                lblRecordingStatus.Text = "Recording";
                pbRecordingStatus.Image = Resources.GreenCircle;
            }
        }

        #endregion

        #region Recorder event handlers

        void Document_MouseUp(object sender, HtmlElementEventArgs e)
        {
            if (!m_ElementSelector.IsActive)
            {
                HtmlElement element = wbRecorder.Document.GetElementFromPoint(e.ClientMousePosition);
                if (element != null)
                {
                    ClickStep clickStep = new ClickStep()
                    {
                        ClickType = ClickType.Left,
                        Element = ElementIdentifier.FromHtmlElement(element)
                    };
                    zAddStep(clickStep);
                }
            }
        }

        void m_ElementSelector_ElementSelected(object sender, ElementSelectorEventArgs e)
        {
            if (e.FromUserAction)
            {
                //TODO: refactor this so that code is not repeated.
                if (m_ElementSelectMode == ElementSelectMode.Get)
                {
                    GetValueStep getValueStep = new GetValueStep()
                    {
                        StateVariable = zGenerateVariableName(),
                        Element = ElementIdentifier.FromHtmlElement(e.Element),
                        XMLFieldOutputMode = XMLFieldOutputMode.Attribute,
                        PersistenceMode = PersistenceMode.None
                    };
                    //Default mode & attribute based on tag type
                    if (e.Element.TagName.ToLower() == "input")
                    {
                        getValueStep.Mode = ElementValueMode.Attribute;
                        getValueStep.AttributeName = "value";
                    }
                    else
                    {
                        getValueStep.Mode = ElementValueMode.InnerText;
                    }
                    zAddStep(getValueStep);
                }
                else
                {
                    SetValueStep setValueStep = new SetValueStep()
                    {
                        Element = ElementIdentifier.FromHtmlElement(e.Element)
                    };
                    //Default mode & attribute based on tag type
                    if (e.Element.TagName.ToLower() == "input")
                    {
                        setValueStep.Mode = ElementValueMode.Attribute;
                        setValueStep.AttributeName = "value";
                    }
                    else
                    {
                        setValueStep.Mode = ElementValueMode.InnerText;
                    }
                    zAddStep(setValueStep);
                }
            }
        }

        void Document_Focusing(object sender, HtmlElementEventArgs e)
        {
            if (m_RecordingActive && !m_ElementSelector.IsActive)
            {
                HtmlElement activeElement = wbRecorder.Document.ActiveElement;
                lock (m_Lock)
                {
                    if (activeElement != null
                        && activeElement.TagName.ToLower() == "input"
                        && !m_ElementsWithHandlers.Contains(activeElement))
                    {
                        activeElement.AttachEventHandler("onchange", element_OnChange);
                        m_ElementsWithHandlers.Add(activeElement);
                    }
                }
            }
        }

        void element_OnChange(object sender, EventArgs e)
        {
            HtmlElement activeElement = wbRecorder.Document.ActiveElement;
            if (activeElement != null)
            {
                SetValueStep setValueStep = new SetValueStep()
                {
                    Element = ElementIdentifier.FromHtmlElement(activeElement),
                    Mode = ElementValueMode.Attribute,
                    AttributeName = "value",
                    Value = activeElement.GetAttribute("value")
                };
                zAddStep(setValueStep);
            }
        }

        private void zRemoveElementEventHandlers()
        {
            lock (m_Lock)
            {
                foreach (HtmlElement element in m_ElementsWithHandlers)
                {
                    element.DetachEventHandler("onchange", element_OnChange);
                }
                m_ElementsWithHandlers.Clear();
            }
        }

        #endregion

        #region Element Selector

        private void btnSelectGetElement_Click(object sender, EventArgs e)
        {
            if (!m_ElementSelector.IsActive)
            {
                m_ElementSelectMode = ElementSelectMode.Get;
                zEnableSelectMode();
            }
            else
            {
                zDisableSelectMode();
            }
        }

        private void btnSelectSetElement_Click(object sender, EventArgs e)
        {
            if (!m_ElementSelector.IsActive)
            {
                m_ElementSelectMode = ElementSelectMode.Set;
                zEnableSelectMode();
            }
            else
            {
                zDisableSelectMode();
            }
        }

        private void zEnableSelectMode()
        {
            if (m_ElementSelector.Activate())
            {
                if (m_ElementSelectMode == ElementSelectMode.Get)
                {
                    m_ElementSelector.SelectBorderColor = Color.Green;
                    btnSelectGetElement.BackgroundImage = Resources.DoneIcon;
                    btnSelectSetElement.Enabled = false;
                }
                else
                {
                    m_ElementSelector.SelectBorderColor = Color.Blue;
                    btnSelectSetElement.BackgroundImage = Resources.DoneIcon;
                    btnSelectGetElement.Enabled = false;
                }
                zRemoveElementEventHandlers();
            }
        }

        private void zDisableSelectMode()
        {
            if (m_ElementSelector.Deactivate())
            {
                if (m_ElementSelectMode == ElementSelectMode.Get)
                {
                    btnSelectGetElement.BackgroundImage = Resources.GetValueIcon;
                    btnSelectSetElement.Enabled = true;
                }
                else
                {
                    btnSelectSetElement.BackgroundImage = Resources.SetValueIcon;
                    btnSelectGetElement.Enabled = true;
                }
            }
        }

        private void zSelectAllStepElements()
        {
            m_ElementSelector.ClearSelection();
            List<GetValueStep> getValueSteps = zFindCurrentGetValueSteps(m_AutomationEngine.CurrentStep);
            if (getValueSteps.Count > 0)
            {
                foreach (GetValueStep getValueStep in getValueSteps)
                {
                    m_BrowserHelper.PollElement(getValueStep.Element, m_ElementSelector.SelectElement);
                }
            }
        }

        private List<GetValueStep> zFindCurrentGetValueSteps(Step relativeToStep)
        {
            List<GetValueStep> getValueSteps = new List<GetValueStep>();
            foreach (GetValueStep step in m_StepIndex.Keys.OfType<GetValueStep>())
            {
                if (m_StepIndex[step] > m_StepIndex[relativeToStep])
                {
                    break;
                }
                getValueSteps.Add(step);
            }
            return getValueSteps;
        }

        private string zGenerateVariableName()
        {
            m_VariableGen++;
            return String.Format("Variable{0}", m_VariableGen);
        }

        private void tlvVariables_SelectionChanged(object sender, EventArgs e)
        {
            if (!m_Executing && tlvVariables.SelectedObject != null)
            {
                //GetValueStep step = (GetValueStep)tlvVariables.SelectedObject;
                //m_BrowserHelper.FindElement(step.Element, m_ElementSelector.BlinkSelectedElement);
            }
        }

        #endregion

        #endregion

        #region Events

        public event EventHandler SequenceChanged;
        protected void zOnSequenceChanged(EventArgs e)
        {
            m_IsDirty = true;

            EventHandler evnt = SequenceChanged;
            if (evnt != null)
            {
                evnt(this, e);
            }
        }

        public event EventHandler ExecutionStart;
        protected void zOnExecutionStart(EventArgs e)
        {
            EventHandler evnt = ExecutionStart;
            if (evnt != null)
            {
                evnt(this, e);
            }
        }

        public event EventHandler ExecutionStop;
        protected void zOnExecutionStop(EventArgs e)
        {
            EventHandler evnt = ExecutionStop;
            if (evnt != null)
            {
                evnt(this, e);
            }
        }

        #endregion

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                zDisableRecording();
                if (m_AutomationEngine != null)
                {
                    m_AutomationEngine.StepBegin -= m_AutomationEngine_StepBegin;
                    m_AutomationEngine.StepComplete -= m_AutomationEngine_StepComplete;
                    m_AutomationEngine.ExecutionBegin -= m_AutomationEngine_ExecutionBegin;
                    m_AutomationEngine.ExecutionComplete -= m_AutomationEngine_ExecutionComplete;

                    m_AutomationEngine.Dispose();
                    m_AutomationEngine = null;
                }
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
