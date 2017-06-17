using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.WebHawk.Controller.Model.Conditional;
using UBoat.WebHawk.Controller.Model.Automation.Steps;
using UBoat.WebHawk.Controller.Model.Data;
using UBoat.Utils.DOM;
using UBoat.Utils.Validation;


namespace UBoat.WebHawk.UI.StepEditors
{
    public partial class GetValueStepEditor : ElementStepEditor
    {
        private List<GetValueNormalizationRule> m_NormalizationRules;
        private bool m_AddNormalizationRuleMode;

        protected GetValueStep Step
        {
            get
            {
                return (GetValueStep)StepEditContext.Step;
            }
        }
        
        public GetValueStepEditor()
        {
            InitializeComponent();

            olvColumnDelete.AspectGetter = (obj) => "Delete";
        }

        public GetValueStepEditor(StepEditContext context)
            : this()
        {
            this.SetContext(context);
        }

        public override void SetContext(StepEditContext context)
        {
            base.SetContext(context);

            cbVariableName.BindEditableStateVariables(context.StateVariables.Primitives(), Step.StateVariable);
            cbPersistVariable.Checked = Step.PersistenceMode == PersistenceMode.Persisted;

            getValueSelector.SetContext(Step.Mode, m_ElementIdentifier, Step.AttributeName);

            rbXMLElement.Checked = Step.XMLFieldOutputMode == XMLFieldOutputMode.Element;
            rbXMLAttribute.Checked = Step.XMLFieldOutputMode == XMLFieldOutputMode.Attribute;
            rbXMLNone.Checked = Step.XMLFieldOutputMode == XMLFieldOutputMode.None;

            m_NormalizationRules = Step.NormalizationRules.Select(nr => nr.Clone()).ToList();
            zRefreshNormalizationRules();
            cbUseNormalizationDefault.Checked = Step.UseNormalizationDefault;
            txtNormalizationDefault.Enabled = Step.UseNormalizationDefault;
            if (Step.UseNormalizationDefault && !String.IsNullOrEmpty(Step.NormalizationDefault))
            {
                txtNormalizationDefault.Text = Step.NormalizationDefault;
            }
        }

        #region Normalization

        private void zRefreshNormalizationRules()
        {
            if (m_NormalizationRules != null)
            {
                olvDataNormalization.SetObjects(m_NormalizationRules);
                olvColumnComparative.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                olvColumnCaseSensitive.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                olvColumnTrim.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                olvColumnReplaceWholeOriginalValue.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void zRefreshNormalizationRule(GetValueNormalizationRule rule)
        {
            olvDataNormalization.RefreshObject(rule);
        }

        private void btnAddNormalizationRule_Click(object sender, EventArgs e)
        {
            m_NormalizationRules.Add(new GetValueNormalizationRule()
            {
                 Comparative = Comparative.Equals,
                 OriginalValue = "Original value here...",
                 ReplacementValue = "Replacement value here...",
                 CaseSensitive = false,
                 Trim = true,
                 ReplaceWholeOriginalValue = true
            });
            m_AddNormalizationRuleMode = true;
            zRefreshNormalizationRules();
            olvDataNormalization.EditSubItem(olvDataNormalization.GetItem(m_NormalizationRules.Count - 1), 0);
        }

        private void btnSuggestValues_Click(object sender, EventArgs e)
        {
            using (GetValueSuggestor frm = new GetValueSuggestor(this.StepEditContext, 
                m_ElementIdentifier,
                getValueSelector.ElementValueMode,
                getValueSelector.AttributeName))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    foreach (string value in frm.Results)
                    {
                        m_NormalizationRules.Add(new GetValueNormalizationRule()
                        {
                            Comparative = Comparative.Equals,
                            OriginalValue = value,
                            ReplacementValue = "Replacement value here...",
                            CaseSensitive = false,
                            Trim = true,
                            ReplaceWholeOriginalValue = true
                        });
                    }
                    zRefreshNormalizationRules();
                }
            }
        }

        private void olvDataNormalization_CellEditStarting(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (e.Column == olvColumnComparative)
            {
                ComboBox cb = new ComboBox();
                cb.Bounds = e.CellBounds;
                cb.Font = ((BrightIdeasSoftware.ObjectListView)sender).Font;
                cb.DropDownStyle = ComboBoxStyle.DropDownList;
                e.Control = cb;

                //DataBinding with enum source causes issue where cb.Items is empty, so items are added manually.
                foreach (Comparative comparative in Enum.GetValues(typeof(Comparative))) 
                {
                    if (!new Comparative[] //Only support string comparatives for now, until full expressions are supported.
                    {
                        Comparative.GreaterThan,
                        Comparative.GreaterThanOrEquals,
                        Comparative.LessThan,
                        Comparative.LessThanOrEquals
                    }.Contains(comparative))
                    {
                        cb.Items.Add(comparative);
                    }
                }
                cb.SelectedItem = ((GetValueNormalizationRule)e.RowObject).Comparative;
            }
        }

        private void olvDataNormalization_CellEditFinishing(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (e.Column.IsEditable)
            {
                if (!e.Cancel)
                {
                    GetValueNormalizationRule rule = (GetValueNormalizationRule)e.RowObject;
                    if (e.Column == olvColumnComparative)
                    {
                        ComboBox cb = (ComboBox)e.Control;
                        rule.Comparative = (Comparative)cb.SelectedItem;
                    }
                    if (e.Column == olvColumnOriginal)
                    {
                        rule.OriginalValue = e.NewValue.ToString();
                    }
                    if (e.Column == olvColumnReplacement)
                    {
                        rule.ReplacementValue = e.NewValue.ToString();
                    }
                    if (e.Column == olvColumnCaseSensitive)
                    {
                        rule.CaseSensitive = (bool)e.NewValue;
                    }
                    if (e.Column == olvColumnTrim)
                    {
                        rule.Trim = (bool)e.NewValue;
                    }
                    if (e.Column == olvColumnReplaceWholeOriginalValue)
                    {
                        rule.ReplaceWholeOriginalValue = (bool)e.NewValue;
                    }
                    zRefreshNormalizationRule(rule);
                    e.Cancel = true;
                }
                else if (m_AddNormalizationRuleMode)
                {
                    m_NormalizationRules.RemoveAt(e.ListViewItem.Index);
                    zRefreshNormalizationRules();
                }
                m_AddNormalizationRuleMode = false;
            }
        }

        private void olvDataNormalization_HyperlinkClicked(object sender, BrightIdeasSoftware.HyperlinkClickedEventArgs e)
        {
            if (e.Column == olvColumnDelete)
            {
                m_NormalizationRules.Remove((GetValueNormalizationRule)e.Model);
                zRefreshNormalizationRules();
            }
            e.Handled = true;
        }

        private void cbUseNormalizationDefault_CheckedChanged(object sender, EventArgs e)
        {
            txtNormalizationDefault.Enabled = cbUseNormalizationDefault.Checked;
        }

        #endregion

        public override ValidationResult PerformValidation()
        {
            ValidationResult result = base.PerformValidation();
            if (String.IsNullOrWhiteSpace(cbVariableName.Text))
            {
                result.Append(ValidationResult.WithFailure("Please enter a state variable name."));
            }
            return result;
        }

        public override void Save()
        {
            base.Save();

            Step.StateVariable = cbVariableName.Text;
            Step.PersistenceMode = cbPersistVariable.Checked ? PersistenceMode.Persisted : PersistenceMode.None;
            Step.Mode = getValueSelector.ElementValueMode;
            Step.AttributeName = getValueSelector.AttributeName;
            Step.XMLFieldOutputMode = rbXMLAttribute.Checked 
                ? XMLFieldOutputMode.Attribute 
                : rbXMLElement.Checked 
                    ? XMLFieldOutputMode.Element 
                    : XMLFieldOutputMode.None;
            Step.NormalizationRules.Clear();
            Step.NormalizationRules.AddRange(m_NormalizationRules);
            Step.UseNormalizationDefault = cbUseNormalizationDefault.Checked;
            Step.NormalizationDefault = cbUseNormalizationDefault.Checked ? txtNormalizationDefault.Text : null;
        }
    }
}
