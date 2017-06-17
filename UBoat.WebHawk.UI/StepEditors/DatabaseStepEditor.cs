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
using UBoat.Utils.DataAccess;
using UBoat.WebHawk.Controller.Model.Database;
using UBoat.WebHawk.Controller.Model.Data;
using UBoat.Utils.Validation;
using UBoat.WebHawk.UI.StepEditors.DatabaseEditors;

namespace UBoat.WebHawk.UI.StepEditors
{
    public partial class DatabaseStepEditor : StepEditor
    {
        private List<InputParameterMap> m_InputParameterMapping;
        private List<OutputParameterMap> m_OutputParameterMapping;
        private bool m_AddParameterMode;

        private ResultMapping m_ResultMapping;
        private StepEditor m_ResultMappingEditor;

        protected DatabaseStep Step
        {
            get
            {
                return (DatabaseStep)StepEditContext.Step;
            }
        }

        public DatabaseStepEditor()
        {
            InitializeComponent();
            this.Disposed += DatabaseStepEditor_Disposed;

            olvColumnInputParameterDelete.AspectGetter = (obj) => "Delete";
            olvColumnOutputParameterDelete.AspectGetter = (obj) => "Delete";
            cbConnectionType.DataSource = Enum.GetValues(typeof(DataAccessType));
            cbCommandType.DataSource = Enum.GetValues(typeof(UBoat.Utils.DataAccess.CommandType));
            cbResultType.DisplayMember = "Key";
            cbResultType.ValueMember = "Value";
            cbResultType.DataSource = new BindingSource(new Dictionary<string, Type>()
            {
                { "None", null },
                { "Scalar", typeof(ScalarResultMapping) },
                { "Table", typeof(TableResultMapping) }
            }, null);
        }

        public DatabaseStepEditor(StepEditContext context)
            : this()
        {
            this.SetContext(context);
        }

        public override void SetContext(StepEditContext context)
        {
            base.SetContext(context);

            cbConnectionType.SelectedItem = Step.ConnectionType;
            txtConnectionString.Text = Step.ConnectionString;
            cbCommandType.SelectedItem = Step.CommandType;
            commandEditor.SetContext(StepEditContext.StateVariables, Step.Command, Step.TrimVariableValueWhitespace);

            m_InputParameterMapping = Step.InputParameterMapping.Select(pm => pm.Clone()).ToList();
            zRefreshInputParameters();

            m_OutputParameterMapping = Step.OutputParameterMapping.Select(pm => pm.Clone()).ToList();
            zRefreshOutputParameters();

            m_ResultMapping = Step.ResultMapping;
            if (m_ResultMapping != null)
            {
                cbResultType.SelectedValue = m_ResultMapping.GetType();
            }
        }

        #region Connection String Editor

        private void btnBuildConnectionString_Click(object sender, EventArgs e)
        {
            using (ConnectionStringEditor connStringEditor = new ConnectionStringEditor((DataAccessType)cbConnectionType.SelectedItem, txtConnectionString.Text))
            {
                if (connStringEditor.ShowDialog() == DialogResult.OK)
                {
                    txtConnectionString.Text = connStringEditor.ConnectionString;
                }
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            bool success;
            string message;
            using (IDataAccess dataAccess = DataAccessFactory.CreateDataAccess((DataAccessType)cbConnectionType.SelectedItem, txtConnectionString.Text))
            {
                success = dataAccess.TestConnection(out message);
            }
            MessageBox.Show(message, "Test Connection", MessageBoxButtons.OK, success 
                ? MessageBoxIcon.Information 
                : MessageBoxIcon.Warning);
        }

        #endregion

        #region Command

        private void cbCommandType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnFindStoredProcedure.Visible = ((UBoat.Utils.DataAccess.CommandType)cbCommandType.SelectedItem) == Utils.DataAccess.CommandType.StoredProcedure;
        }

        private void btnFindStoredProcedure_Click(object sender, EventArgs e)
        {
            using (IDataAccess dataAccess = DataAccessFactory.CreateDataAccess((DataAccessType)cbConnectionType.SelectedItem, txtConnectionString.Text))
            {
                //DataTable table = dataAccess.GetMetadata(DataAccessMetadataType.Procedures);
                //Form form = new Form();
                //DataGridView dgv = new DataGridView();
                //dgv.DataSource = table;
                //dgv.Dock = DockStyle.Fill;
                //form.Controls.Add(dgv);
                //form.Show();
            }
        }

        #endregion

        #region Input Parameters

        private void zRefreshInputParameters()
        {
            if (m_InputParameterMapping != null)
            {
                olvInputParameters.SetObjects(m_InputParameterMapping);
            }
        }

        private void zRefreshInputParameter(InputParameterMap parameterMap)
        {
            olvInputParameters.RefreshObject(parameterMap);
        }

        private void btnAddInputParameter_Click(object sender, EventArgs e)
        {
            m_InputParameterMapping.Add(new InputParameterMap()
            {
                ParameterName = "@NewParameter",
                ParameterValue = "Value here...",
                TrimVariableValueWhitespace = true
            });
            m_AddParameterMode = true;
            zRefreshInputParameters();
            olvInputParameters.EditSubItem(olvInputParameters.GetItem(m_InputParameterMapping.Count - 1), 0);
        }

        private void olvInputParameters_CellEditStarting(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (e.Column == olvColumnInputParameterValue)
            {
                InputParameterMap parameterMap = (InputParameterMap)e.RowObject;
                OLVOutputValueEditor olvOutputValueEditor = e.AttachEditControl<OLVOutputValueEditor>();
                olvOutputValueEditor.SetContext(StepEditContext.StateVariables, parameterMap.ParameterValue, parameterMap.TrimVariableValueWhitespace);
            }
        }

        private void olvInputParameters_CellEditFinishing(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (e.Column.IsEditable)
            {
                if (!e.Cancel)
                {
                    InputParameterMap parameterMap = (InputParameterMap)e.RowObject;
                    if (e.Column == olvColumnInputParameterName)
                    {
                        parameterMap.ParameterName = e.NewValue.ToString();
                    }
                    if (e.Column == olvColumnInputParameterValue)
                    {
                        OLVOutputValueEditor olvOutputValueEditor = e.GetEditControl<OLVOutputValueEditor>();
                        parameterMap.ParameterValue = olvOutputValueEditor.Value;
                        parameterMap.TrimVariableValueWhitespace = olvOutputValueEditor.TrimVariableValueWhitespace;
                    }
                    if (e.Column == olvColumnInputParameterTrim)
                    {
                        parameterMap.TrimVariableValueWhitespace = (bool)e.NewValue;
                    }
                    zRefreshInputParameter(parameterMap);
                    e.Cancel = true;
                }
                else if (m_AddParameterMode)
                {
                    m_InputParameterMapping.RemoveAt(e.ListViewItem.Index);
                    zRefreshInputParameters();
                }
                m_AddParameterMode = false;
            }
        }

        private void olvInputParameters_HyperlinkClicked(object sender, BrightIdeasSoftware.HyperlinkClickedEventArgs e)
        {
            if (e.Column == olvColumnInputParameterDelete)
            {
                m_InputParameterMapping.Remove((InputParameterMap)e.Model);
                zRefreshInputParameters();
            }
            e.Handled = true;
        }

        private void btnDetectInputParameters_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Output Parameters

        private void zRefreshOutputParameters()
        {
            if (m_OutputParameterMapping != null)
            {
                olvOutputParameters.SetObjects(m_OutputParameterMapping);
            }
        }

        private void zRefreshOutputParameter(OutputParameterMap parameterMap)
        {
            olvOutputParameters.RefreshObject(parameterMap);
        }

        private void btnAddOutputParameter_Click(object sender, EventArgs e)
        {
            m_OutputParameterMapping.Add(new OutputParameterMap()
            {
                ParameterType = OutputParameterType.Output,
                ParameterName = "@NewParameter",
                StateVariable = "NewVariable",
                XMLFieldOutputMode = XMLFieldOutputMode.Attribute,
                PersistenceMode = PersistenceMode.None
            });
            m_AddParameterMode = true;
            zRefreshOutputParameters();
            olvOutputParameters.EditSubItem(olvOutputParameters.GetItem(m_OutputParameterMapping.Count - 1), 0);
        }

        private void olvOutputParameters_CellEditStarting(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            OutputParameterMap parameterMap = (OutputParameterMap)e.RowObject;
            if (e.Column == olvColumnOutputParameterType)
            {
                ComboBox cb = e.AttachEditCombobox(ComboBoxStyle.DropDownList, Enum.GetValues(typeof(OutputParameterType)), false);
                cb.SelectedItem = parameterMap.ParameterType;
            }
            if (e.Column == olvColumnInputParameterName && parameterMap.ParameterType == OutputParameterType.Return)
            {
                e.Control.Enabled = false;
            }
            if (e.Column == olvColumnOutputParameterStateVariable)
            {
                ComboBox cb = e.AttachEditCombobox(ComboBoxStyle.DropDown);
                cb.BindEditableStateVariables(this.StepEditContext.StateVariables.Primitives(), parameterMap.StateVariable);
            }
            if (e.Column == olvColumnOutputParameterXMLOutputMode)
            {
                ComboBox cb = e.AttachEditCombobox(ComboBoxStyle.DropDownList, Enum.GetValues(typeof(XMLFieldOutputMode)), false);
                cb.SelectedItem = parameterMap.XMLFieldOutputMode;
            }
            if (e.Column == olvColumnOutputParameterPersistenceMode)
            {
                CheckBox cb = e.AttachEditControl<CheckBox>();
                cb.Checked = parameterMap.PersistenceMode == PersistenceMode.Persisted;
            }
        }

        private void olvOutputParameters_CellEditFinishing(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (e.Column.IsEditable)
            {
                if (!e.Cancel)
                {
                    OutputParameterMap parameterMap = (OutputParameterMap)e.RowObject;
                    if (e.Column == olvColumnOutputParameterType)
                    {
                        parameterMap.ParameterType = (OutputParameterType)e.GetEditControl<ComboBox>().SelectedItem;
                        if (parameterMap.ParameterType == OutputParameterType.Return)
                        {
                            parameterMap.ParameterName = null;
                        }
                    }
                    if (e.Column == olvColumnOutputParameterName)
                    {
                        parameterMap.ParameterName = e.NewValue.ToString();
                    }
                    if (e.Column == olvColumnOutputParameterStateVariable)
                    {
                        parameterMap.StateVariable = e.GetEditControl<ComboBox>().Text;
                    }
                    if (e.Column == olvColumnOutputParameterXMLOutputMode)
                    {
                        parameterMap.XMLFieldOutputMode = (XMLFieldOutputMode)e.GetEditControl<ComboBox>().SelectedItem;
                    }
                    if (e.Column == olvColumnOutputParameterPersistenceMode)
                    {
                        parameterMap.PersistenceMode = e.GetEditControl<CheckBox>().Checked ? PersistenceMode.Persisted : PersistenceMode.None;
                    }
                    zRefreshOutputParameter(parameterMap);
                    e.Cancel = true;
                }
                else if (m_AddParameterMode)
                {
                    m_OutputParameterMapping.RemoveAt(e.ListViewItem.Index);
                    zRefreshOutputParameters();
                }
                m_AddParameterMode = false;
            }
        }

        private void olvOutputParameters_HyperlinkClicked(object sender, BrightIdeasSoftware.HyperlinkClickedEventArgs e)
        {
            if (e.Column == olvColumnOutputParameterDelete)
            {
                m_OutputParameterMapping.Remove((OutputParameterMap)e.Model);
                zRefreshOutputParameters();
            }
            e.Handled = true;
        }

        private void btnDetectOutputParameters_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Result Mapping

        private void cbResultType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Type selectedItem = (Type)cbResultType.SelectedValue;
            if (selectedItem == null && m_ResultMapping != null)
            {
                m_ResultMapping = null;
            }
            if (selectedItem == typeof(ScalarResultMapping) && !(m_ResultMapping is ScalarResultMapping))
            {
                m_ResultMapping = new ScalarResultMapping()
                {
                    StateVariable = "NewVariable",
                    XMLFieldOutputMode = XMLFieldOutputMode.Attribute
                };
            }
            if (selectedItem == typeof(TableResultMapping) && !(m_ResultMapping is TableResultMapping))
            {
                m_ResultMapping = new TableResultMapping()
                {
                    IncludeInXML = true
                };
            }

            zUpdateResultMappingEditor();
        }

        private void zUpdateResultMappingEditor()
        {
            zClearResultMappingEditor();
            if (m_ResultMapping != null)
            {
                gbResultMappingEditor.Visible = true;
                m_ResultMappingEditor = ResultMappingEditorFactory.GetResultMappingEditor(this.StepEditContext, m_ResultMapping);
                m_ResultMappingEditor.Dock = DockStyle.Fill;
                gbResultMappingEditor.Controls.Add(m_ResultMappingEditor);
                gbResultMappingEditor.Text = m_ResultMappingEditor.Title;
            }
        }

        private void zClearResultMappingEditor()
        {
            gbResultMappingEditor.Visible = false;
            if (m_ResultMappingEditor != null)
            {
                m_ResultMappingEditor.Dispose();
                gbResultMappingEditor.Controls.Clear();
                m_ResultMappingEditor = null;
            }
        }

        #endregion

        public override ValidationResult PerformValidation()
        {
            ValidationResult result = base.PerformValidation();
            if (m_ResultMappingEditor != null)
            {
                result.Append(m_ResultMappingEditor.PerformValidation());
            }
            return result;
        }

        public override void Save()
        {
            base.Save();

            Step.ConnectionType = (DataAccessType)cbConnectionType.SelectedItem;
            Step.ConnectionString = txtConnectionString.Text;
            Step.CommandType = (UBoat.Utils.DataAccess.CommandType)cbCommandType.SelectedItem;
            Step.Command = commandEditor.Value;
            Step.TrimVariableValueWhitespace = commandEditor.TrimVariableValueWhitespace;
            Step.InputParameterMapping.Clear();
            Step.InputParameterMapping.AddRange(m_InputParameterMapping);
            Step.OutputParameterMapping.Clear();
            Step.OutputParameterMapping.AddRange(m_OutputParameterMapping);
            if (m_ResultMappingEditor != null)
            {
                m_ResultMappingEditor.Save();
            }
            Step.ResultMapping = m_ResultMapping;
        }

        void DatabaseStepEditor_Disposed(object sender, EventArgs e)
        {
            zClearResultMappingEditor();
        }
    }
}
