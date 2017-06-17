using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.WebHawk.Controller.Model.Data;

namespace UBoat.WebHawk.UI.StepEditors
{
    public partial class OLVOutputValueEditorPopup : Form
    {
        public OutputValueEditor OutputValueEditor
        {
            get
            {
                return outputValueEditor1;
            }
        }

        public OLVOutputValueEditorPopup()
        {
            InitializeComponent();
        }

        public OLVOutputValueEditorPopup(List<StateVariableInfo> stateVariableInfos, string value, bool trimVariableValueWhitespace) 
            : this()
        {
            SetContext(stateVariableInfos, value, trimVariableValueWhitespace);
        }

        public void SetContext(List<StateVariableInfo> stateVariableInfos, string value, bool trimVariableValueWhitespace)
        {
            outputValueEditor1.SetContext(stateVariableInfos, value, trimVariableValueWhitespace);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
