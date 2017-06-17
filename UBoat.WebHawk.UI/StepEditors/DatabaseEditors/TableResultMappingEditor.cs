using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.WebHawk.Controller.Model.Database;
using UBoat.Utils.Validation;
using UBoat.WebHawk.Controller.Model.Data;

namespace UBoat.WebHawk.UI.StepEditors.DatabaseEditors
{
    public partial class TableResultMappingEditor : TableResultMappingEditorBase
    {
        private List<TableResultMap> m_TableResultMapping;
        private bool m_AddTableResultMode;

        public override string Title
        {
            get
            {
                return "Table Result";
            }
        }

        public TableResultMappingEditor() 
        {
            InitializeComponent();

            olvColumnTableResultDelete.AspectGetter = (obj) => "Delete";
        }

        public TableResultMappingEditor(StepEditContext context, TableResultMapping mapping)
            : this()
        {
            this.SetContext(context, mapping);
        }

        public override void SetContext(StepEditContext context, TableResultMapping mapping)
        {
            base.SetContext(context, mapping);

            txtObjectClassName.Text = mapping.ObjectSetClassName;
            cbListName.BindEditableStateVariables(context.StateVariables.Lists(), mapping.ObjectSetListName, true);
            cbPersistList.Checked = mapping.PersistenceMode == PersistenceMode.Persisted;
            cbIncludeInXML.Checked = mapping.IncludeInXML;

            m_TableResultMapping = mapping.TableMapping.Select(trm => trm.Clone()).ToList();
            zRefreshTableResults();
        }

        #region Table Results

        private void zRefreshTableResults()
        {
            if (m_TableResultMapping != null)
            {
                olvTableResults.SetObjects(m_TableResultMapping);
            }
        }

        private void zRefreshTableResult(TableResultMap tableResultMap)
        {
            olvTableResults.RefreshObject(tableResultMap);
        }

        private void btnAddTableResult_Click(object sender, EventArgs e)
        {
            m_TableResultMapping.Add(new TableResultMap()
            {
                ColumnName = "NewColumn",
                StateVariable = "NewVariable",
                XMLFieldOutputMode = XMLFieldOutputMode.Attribute,
                PersistenceMode = PersistenceMode.None
            });
            m_AddTableResultMode = true;
            zRefreshTableResults();
            olvTableResults.EditSubItem(olvTableResults.GetItem(m_TableResultMapping.Count - 1), 0);
        }

        private void olvTableResults_CellEditStarting(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            TableResultMap tableResultMap = (TableResultMap)e.RowObject;
            if (e.Column == olvColumnTableResultStateVariable)
            {
                ComboBox cb = e.AttachEditCombobox(ComboBoxStyle.DropDown);
                cb.BindEditableStateVariables(this.StepEditContext.StateVariables.Primitives(), tableResultMap.StateVariable);
            }
            if (e.Column == olvColumnTableResultXMLOutputMode)
            {
                ComboBox cb = e.AttachEditCombobox(ComboBoxStyle.DropDownList, Enum.GetValues(typeof(XMLFieldOutputMode)), false);
                cb.SelectedItem = tableResultMap.XMLFieldOutputMode;
            }
            if (e.Column == olvColumnTableResultPersistenceMode)
            {
                CheckBox cb = e.AttachEditControl<CheckBox>();
                cb.Checked = tableResultMap.PersistenceMode == PersistenceMode.Persisted;
            }
        }

        private void olvTableResults_CellEditFinishing(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (e.Column.IsEditable)
            {
                if (!e.Cancel)
                {
                    TableResultMap tableResultMap = (TableResultMap)e.RowObject;
                    if (e.Column == olvColumnTableResultColumnName)
                    {
                        tableResultMap.ColumnName = e.NewValue.ToString();
                    }
                    if (e.Column == olvColumnTableResultStateVariable)
                    {
                        tableResultMap.StateVariable = e.GetEditControl<ComboBox>().Text;
                    }
                    if (e.Column == olvColumnTableResultXMLOutputMode)
                    {
                        tableResultMap.XMLFieldOutputMode = (XMLFieldOutputMode)e.GetEditControl<ComboBox>().SelectedItem;
                    }
                    if (e.Column == olvColumnTableResultPersistenceMode)
                    {
                        tableResultMap.PersistenceMode = e.GetEditControl<CheckBox>().Checked ? PersistenceMode.Persisted : PersistenceMode.None;
                    }
                    zRefreshTableResult(tableResultMap);
                    e.Cancel = true;
                }
                else if (m_AddTableResultMode)
                {
                    m_TableResultMapping.RemoveAt(e.ListViewItem.Index);
                    zRefreshTableResults();
                }
                m_AddTableResultMode = false;
            }
        }

        private void olvTableResults_HyperlinkClicked(object sender, BrightIdeasSoftware.HyperlinkClickedEventArgs e)
        {
            if (e.Column == olvColumnTableResultDelete)
            {
                m_TableResultMapping.Remove((TableResultMap)e.Model);
                zRefreshTableResults();
            }
        }

        #endregion

        public override ValidationResult PerformValidation()
        {
            ValidationResult result = base.PerformValidation();
            return result;
        }

        public override void Save()
        {
            base.Save();

            this.Target.ObjectSetClassName = !String.IsNullOrWhiteSpace(txtObjectClassName.Text) ? txtObjectClassName.Text : null;
            this.Target.ObjectSetListName = !String.IsNullOrWhiteSpace(cbListName.Text) ? cbListName.Text : null;
            this.Target.PersistenceMode = cbPersistList.Checked ? PersistenceMode.Persisted : PersistenceMode.None;
            this.Target.IncludeInXML = cbIncludeInXML.Checked;

            this.Target.TableMapping.Clear();
            this.Target.TableMapping.AddRange(m_TableResultMapping);
        }
    }

    /// <summary>
    /// BULLSHIT intermediate base class becuase the winforms designer can't load anything whos immediate base class is generic... FUCK!
    /// Just pretend this isn't here and go on with your day.
    /// http://stackoverflow.com/questions/13345551/why-do-base-windows-forms-form-class-with-generic-types-stop-the-designer-loadin
    /// </summary>
    public class TableResultMappingEditorBase : StepEditor<TableResultMapping>
    {
    }
}
