using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.WebHawk.Controller.Model.Data;

namespace UBoat.WebHawk.UI.StepEditors
{
    public partial class OutputValueEditor : UserControl
    {
        public string Value
        {
            get
            {
                return txtOutputValue.Text;
            }
            set
            {
                txtOutputValue.Text = value;
            }
        }
        public bool TrimVariableValueWhitespace
        {
            get
            {
                return cbTrimVariableValueWhitespace.Checked;
            }
            set
            {
                cbTrimVariableValueWhitespace.Checked = value;
            }
        }

        public OutputValueEditor()
        {
            InitializeComponent();
        }

        public OutputValueEditor(List<StateVariableInfo> stateVariableInfos, string value, bool trimVariableValueWhitespace) 
            : this()
        {
            SetContext(stateVariableInfos, value, trimVariableValueWhitespace);
        }

        public void SetContext(List<StateVariableInfo> stateVariableInfos, string value, bool trimVariableValueWhitespace)
        {
            cbVariableList.DataSource = stateVariableInfos.Primitives();
            cbTrimVariableValueWhitespace.Checked = trimVariableValueWhitespace;
            if (value != null)
            {
                txtOutputValue.Text = value;
            }
        }

        private void btnInsertVariable_Click(object sender, EventArgs e)
        {
            int selectionStart = txtOutputValue.SelectionStart;
            string variableName = Convert.ToString(cbVariableList.SelectedItem);
            txtOutputValue.Text = txtOutputValue.Text.Insert(selectionStart, String.Format("{{{0}}}", variableName));
            txtOutputValue.SelectionStart = selectionStart + variableName.Length + 2;
            txtOutputValue.Focus();
        }
    }
}
