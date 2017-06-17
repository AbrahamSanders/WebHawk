using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.Utils;
using UBoat.WebHawk.Controller.Model.Automation.Steps;
using UBoat.WebHawk.Controller.Model.Conditional;
using UBoat.WebHawk.Controller.Model.Data;
using UBoat.WebHawk.UI.StepEditors;
using UBoat.WebHawk.UI.Properties;
using UBoat.Utils.Validation;

namespace UBoat.WebHawk.UI
{
    public partial class frmStepEditor : Form, IValidatable
    {
        private StepEditContext m_StepEditContext;
        private ConditionNode m_ConditionalRoot;
        private ExpressionNode m_CurrentExpression;
        private StepEditor m_StepEditor;
        private bool m_ExpressionBuilderLocked;

        private DataType SelectedDataType
        {
            get
            {
                return (DataType)Enum.Parse(typeof(DataType), cbDataType.SelectedItem.ToString());
            }
        }

        public frmStepEditor()
        {
            InitializeComponent();

            tlvCondition.FormatRow += tlvCondition_FormatRow;
            tlvCondition.CanExpandGetter = zCanExpandGetter;
            tlvCondition.ChildrenGetter = zChildrenGetter;
            tlvCondition.HotItemStyle = new BrightIdeasSoftware.HotItemStyle()
            {
                Decoration = new BrightIdeasSoftware.RowBorderDecoration()
                {
                    BorderPen = new Pen(Color.Transparent, 2),
                    BoundsPadding = new Size(1, 1),
                    CornerRounding = 4.0f
                }
            };

            olvColumnConditional.AspectGetter = zConditionalAspectGetter;
            olvColumnConditional.ImageGetter = zConditionalImageGetter;
            olvColumnVariable.AspectGetter = zVariableAspectGetter;
            olvColumnComparative.AspectGetter = zComparativeAspectGetter;
            olvColumnValue.AspectGetter = zValueAspectGetter;

            cbCondition.DataSource = Enum.GetNames(typeof(Conditional));
            cbDataType.DataSource = Enum.GetNames(typeof(DataType))
                .Where(dt => dt != "List" && dt != "Object").ToList();

            cbStepFailureScope.DataSource = Enum.GetValues(typeof(StepFailureScope));

            imageListConditions.Images.AddRange(new Image[]
            {
                Resources.arrow_branch,
                Resources.Document
            });
        }

        public frmStepEditor(StepEditContext stepEditContext)
            : this()
        {
            this.SetStep(stepEditContext);
        }

        public void SetStep(StepEditContext stepEditContext)
        {
            this.m_StepEditContext = stepEditContext;
            cbVariable.DataSource = m_StepEditContext.StateVariables.Primitives();

            //Step
            tpStep.Text = m_StepEditContext.Step.DisplayName;
            m_StepEditor = StepEditorFactory.GetStepEditor(m_StepEditContext);
            m_StepEditor.Dock = DockStyle.Fill;
            tpStep.Controls.Add(m_StepEditor);

            //Condition
            if (m_StepEditContext.Step.Condition != null)
            {
                m_ConditionalRoot = m_StepEditContext.Step.Condition;
                //m_CurrentExpression = 

                zUpdateExpressionBuilder();
                btnRemoveCondition.Enabled = true;
                panelExpressionBuilder.Enabled = true;
            }

            //Behavior
            cbStepFailureScope.SelectedItem = m_StepEditContext.Step.FailureScope;

            zRefreshCondition();
        }

        public ValidationResult PerformValidation()
        {
            //TODO: conditional and behavior editor validation...
            ValidationResult result = new ValidationResult(true);
            return result;
        }

        private void zRefreshCondition()
        {
            tlvCondition.ClearObjects();
            List<ConditionNode> nodeObjects = new List<ConditionNode>();
            if (m_ConditionalRoot != null)
            {
                nodeObjects.Add(m_ConditionalRoot);
            }
            tlvCondition.SetObjects(nodeObjects);
            tlvCondition.RefreshObjects(nodeObjects);

            tlvCondition.ExpandAll();
            //if (m_CurrentExpression != null)
            //{
            //    tlvCondition.ExpandToObject(m_CurrentExpression);
            //}
        }

        void tlvCondition_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
        {
            if (e.Model == m_CurrentExpression)
            {
                e.Item.Decoration = new BrightIdeasSoftware.RowBorderDecoration()
                {
                    BorderPen = new Pen(Color.Transparent, 2),
                    BoundsPadding = new Size(1, 1),
                    CornerRounding = 4.0f
                };
            }
        }

        private void tlvCondition_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            if (e.Model is ExpressionNode)
            {
                m_CurrentExpression = (ExpressionNode)e.Model;
                zRefreshCondition();
                zUpdateExpressionBuilder();
            }
        }

        private void btnAddCondition_Click(object sender, EventArgs e)
        {
            Conditional conditional = (Conditional)Enum.Parse(typeof(Conditional), cbCondition.SelectedItem.ToString());
            ExpressionNode newExpression = new ExpressionNode();
            newExpression.StateVariable = cbVariable.Items[0].ToString();

            if (m_ConditionalRoot == null)
            {
                m_ConditionalRoot = newExpression;
            }
            else
            {
                LogicalNode selectedLogicalNode = (LogicalNode)tlvCondition.GetParent(m_CurrentExpression);
                if (selectedLogicalNode == null)
                {
                    m_ConditionalRoot = new LogicalNode()
                    {
                        Nodes = new List<ConditionNode>()
                        {
                            m_ConditionalRoot,
                            newExpression
                        },
                        ConditionalOperator = conditional
                    };
                }
                else if (selectedLogicalNode.ConditionalOperator != conditional)
                {
                    LogicalNode newLogicalNode = new LogicalNode()
                    {
                        Nodes = new List<ConditionNode>()
                        {
                            newExpression
                        },
                        ConditionalOperator = conditional
                    };
                    selectedLogicalNode.Nodes.Add(newLogicalNode);
                }
                else
                {
                    selectedLogicalNode.Nodes.Add(newExpression);
                }
            }

            m_CurrentExpression = newExpression;
            zUpdateExpressionBuilder();
            zRefreshCondition();

            btnRemoveCondition.Enabled = true;
            panelExpressionBuilder.Enabled = true;
        }

        private void btnRemoveCondition_Click(object sender, EventArgs e)
        {
            if (m_CurrentExpression == m_ConditionalRoot)
            {
                m_ConditionalRoot = null;
            }
            else
            {
                LogicalNode selectedLogicalNode = (LogicalNode)tlvCondition.GetParent(m_CurrentExpression);
                if (selectedLogicalNode != null)
                {
                    selectedLogicalNode.Nodes.Remove(m_CurrentExpression);
                    if (selectedLogicalNode.Nodes.Count < 2)
                    {
                        //Remove logical node
                        LogicalNode parentLogicalNode = (LogicalNode)tlvCondition.GetParent(selectedLogicalNode);
                        
                        if (parentLogicalNode != null && selectedLogicalNode.Nodes.Count == 0)
                        {
                            parentLogicalNode.Nodes.Remove(selectedLogicalNode);
                        }
                        else if (parentLogicalNode == null && selectedLogicalNode.Nodes.Count == 1)
                        {
                            //TODO when not drinking beer: resolve lowest level in loop in case nested logical node
                            m_ConditionalRoot = selectedLogicalNode.Nodes.First();
                            selectedLogicalNode.Nodes.Clear();
                        }
                    }
                }
            }
            m_CurrentExpression = null;
            zRefreshCondition();
        }

        private void zUpdateExpressionNode()
        {
            if (m_CurrentExpression != null && !m_ExpressionBuilderLocked)
            {
                m_CurrentExpression.StateVariable = cbVariable.SelectedItem.ToString();
                m_CurrentExpression.DataType = (DataType)Enum.Parse(typeof(DataType), cbDataType.SelectedItem.ToString());
                m_CurrentExpression.CaseSensitive = cbCaseSensitive.Checked;
                m_CurrentExpression.ComparativeOperator = (Comparative)Enum.Parse(typeof(Comparative), cbComparative.SelectedItem.ToString());
                m_CurrentExpression.Negated = cbNegate.Checked;
                m_CurrentExpression.Value = veValue.GetValue();
                m_CurrentExpression.VariableAsValue = cbUseVariable.Checked;

                zRefreshCondition();
            }
        }

        private void zUpdateExpressionBuilder()
        {
            if (m_CurrentExpression != null)
            {
                m_ExpressionBuilderLocked = true;

                cbVariable.SelectedItem = m_CurrentExpression.StateVariable;
                cbDataType.SelectedItem = m_CurrentExpression.DataType.ToString();
                cbCaseSensitive.Checked = m_CurrentExpression.CaseSensitive;
                cbComparative.SelectedItem = m_CurrentExpression.ComparativeOperator.ToString();
                cbNegate.Checked = m_CurrentExpression.Negated;
                cbUseVariable.Checked = m_CurrentExpression.VariableAsValue;
                veValue.SetValue(m_CurrentExpression.Value);

                m_ExpressionBuilderLocked = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cbVariable_SelectedIndexChanged(object sender, EventArgs e)
        {
            zUpdateExpressionNode();
        }

        private void cbComparative_SelectedIndexChanged(object sender, EventArgs e)
        {
            zUpdateExpressionNode();
        }

        private void veValue_ValueChanged(object sender, ValueEntryValueChangedEventArgs e)
        {
            zUpdateExpressionNode();
        }

        private void cbNegate_CheckedChanged(object sender, EventArgs e)
        {
            zUpdateExpressionNode();
        }

        private void cbCaseSensitive_CheckedChanged(object sender, EventArgs e)
        {
            zUpdateExpressionNode();
        }

        private void cbDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataType dataType = SelectedDataType;
            veValue.SetDataType(dataType);
            cbComparative.DataSource = dataType.GetSupportedComparatives();
            cbCaseSensitive.Visible = dataType == DataType.String;
            zUpdateExpressionNode();
        }

        private void cbUseVariable_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUseVariable.Checked)
            {
                veValue.SetList(m_StepEditContext.StateVariables.Primitives());
            }
            else
            {
                veValue.SetDataType(SelectedDataType);
            }
            zUpdateExpressionNode();
        }

        private void frmStepEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_StepEditor != null)
            {
                m_StepEditor.Dispose();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validator.ValidateWithPrompt("Save Step", this, m_StepEditor))
            {
                //Step
                m_StepEditor.Save();
                //Conditional
                m_StepEditContext.Step.Condition = m_ConditionalRoot;
                //Behavior
                m_StepEditContext.Step.FailureScope = (StepFailureScope)cbStepFailureScope.SelectedItem;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        #region tlvConditional Configuration

        private bool zCanExpandGetter(object obj)
        {
            return obj is LogicalNode;
        }

        private IEnumerable zChildrenGetter(object obj)
        {
            return ((LogicalNode)obj).Nodes;
        }

        private object zConditionalAspectGetter(object obj)
        {
            if (obj is LogicalNode)
            {
                return ((LogicalNode)obj).ConditionalOperator;
            }
            return null;
        }

        private object zConditionalImageGetter(object obj)
        {
            if (obj is ExpressionNode)
            {
                return 1;
            }
            return 0;
        }

        private object zVariableAspectGetter(object obj)
        {
            if (obj is ExpressionNode)
            {
                return ((ExpressionNode)obj).StateVariable;
            }
            return null;
        }

        private object zComparativeAspectGetter(object obj)
        {
            if (obj is ExpressionNode)
            {
                return ((ExpressionNode)obj).ComparativeOperator;
            }
            return null;
        }

        private object zValueAspectGetter(object obj)
        {
            if (obj is ExpressionNode)
            {
                return ((ExpressionNode)obj).Value;
            }
            return null;
        }

        #endregion
    }
}
