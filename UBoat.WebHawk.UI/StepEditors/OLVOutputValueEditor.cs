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
    public partial class OLVOutputValueEditor : UserControl
    {
        private List<StateVariableInfo> m_StateVariableInfos;

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

        public bool TrimVariableValueWhitespace { get; set; }

        public OLVOutputValueEditor()
        {
            InitializeComponent();
        }

        public OLVOutputValueEditor(List<StateVariableInfo> stateVariableInfos, string value, bool trimVariableValueWhitespace) 
            : this()
        {
            SetContext(stateVariableInfos, value, trimVariableValueWhitespace);
        }

        public void SetContext(List<StateVariableInfo> stateVariableInfos, string value, bool trimVariableValueWhitespace)
        {
            m_StateVariableInfos = stateVariableInfos;
            this.TrimVariableValueWhitespace = trimVariableValueWhitespace;
            if (value != null)
            {
                txtOutputValue.Text = value;
            }
        }

        private void btnInsertVariable_Click(object sender, EventArgs e)
        {
            using (OLVOutputValueEditorPopup popup = new OLVOutputValueEditorPopup(m_StateVariableInfos, this.Value, this.TrimVariableValueWhitespace))
            {
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    this.TrimVariableValueWhitespace = popup.OutputValueEditor.TrimVariableValueWhitespace;
                    this.Value = popup.OutputValueEditor.Value;
                }
            }
        }
    }
}
