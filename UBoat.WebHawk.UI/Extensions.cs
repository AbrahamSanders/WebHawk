using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightIdeasSoftware;
using UBoat.WebHawk.Controller.Model.Data;
using System.Windows.Forms;
using System.Collections;

namespace UBoat.WebHawk.UI
{
    public static class Extensions
    {
        #region ObjectListView UI Extensions

        public static T AttachEditControl<T>(this CellEditEventArgs e) where T : Control, new()
        {
            T control = new T();
            control.Bounds = e.CellBounds;
            control.Font = e.Column.ListView.Font;
            e.Control = control;
            return control;
        }

        public static ComboBox AttachEditCombobox(this CellEditEventArgs e, ComboBoxStyle style, IEnumerable dataSource = null, bool useDataBinding = true)
        {
            ComboBox cb = AttachEditControl<ComboBox>(e);
            cb.DropDownStyle = style;

            if (dataSource != null)
            {
                if (useDataBinding)
                {
                    cb.DataSource = dataSource;
                }
                else
                {
                    foreach (object obj in dataSource)
                    {
                        cb.Items.Add(obj);
                    }
                }
            }

            return cb;
        }

        public static T GetEditControl<T>(this CellEditEventArgs e) where T : Control
        {
            return (T)e.Control;
        }

        #endregion

        #region TreeListView UI Extensions

        public static void ExpandToObject(this TreeListView tlv, object obj)
        {
            object parent = tlv.GetParent(obj);
            if (parent != null && !tlv.IsExpanded(parent))
            {
                ExpandToObject(tlv, parent);
                tlv.Expand(parent);
            }
        }

        public static bool IsAncestor(this TreeListView tlv, object subject, object ancestorCandidate)
        {
            if (subject == null || ancestorCandidate == null)
            {
                return false;
            }

            object subjectParent = tlv.GetParent(subject);
            if (subjectParent == ancestorCandidate)
            {
                return true;
            }

            return IsAncestor(tlv, subjectParent, ancestorCandidate);
        }

        #endregion

        #region StateVariableInfo UI Extensions

        public static List<string> Primitives(this List<StateVariableInfo> stateVariables)
        {
            return stateVariables
                .Where(sv => sv.DataType != DataType.List && sv.DataType != DataType.Object)
                .Select(sv => sv.StateVariableName)
                .ToList();
        }
        public static List<string> Lists(this List<StateVariableInfo> stateVariables)
        {
            return stateVariables
                .Where(sv => sv.DataType == DataType.List)
                .Select(sv => sv.StateVariableName)
                .ToList();
        }
        public static List<string> Objects(this List<StateVariableInfo> stateVariables)
        {
            return stateVariables
                .Where(sv => sv.DataType == DataType.Object)
                .Select(sv => sv.StateVariableName)
                .ToList();
        }

        #endregion

        #region Combobox Extensions

        public static void BindEditableStateVariables(this ComboBox cb, List<string> stateVariables, string selectedStateVariable, bool insertEmptySelected = false)
        {
            if (insertEmptySelected && selectedStateVariable == null)
            {
                selectedStateVariable = String.Empty;
            }
            else if (!insertEmptySelected && selectedStateVariable == String.Empty)
            {
                selectedStateVariable = null;
            }

            if (selectedStateVariable != null && !stateVariables.Contains(selectedStateVariable))
            {
                stateVariables.Insert(0, selectedStateVariable);
            }
            cb.DataSource = stateVariables;
            cb.Text = selectedStateVariable;
        }

        #endregion
    }
}
