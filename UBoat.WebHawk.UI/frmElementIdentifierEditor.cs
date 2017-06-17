using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.Utils.DOM;

namespace UBoat.WebHawk.UI
{
    public partial class frmElementIdentifierEditor : Form
    {
        public frmElementIdentifierEditor()
        {
            InitializeComponent();
        }

        public frmElementIdentifierEditor(ElementIdentifier elementIdentifier) 
            : this()
        {
            elementIdentifierEditor1.SetElementIdentifier(elementIdentifier);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            elementIdentifierEditor1.Save();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
