using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabProto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            tabPage1.Text = cbNull.Checked ? null : txtTitle.Text;
        }

        private void cbNull_CheckedChanged(object sender, EventArgs e)
        {
            tabPage1.Text = cbNull.Checked ? null : txtTitle.Text;
        }

        private void cbCloseButton_CheckedChanged(object sender, EventArgs e)
        {
            tabPage1.HasCloseButton = cbCloseButton.Checked;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbCloseButton.Checked = tabPage1.HasCloseButton;
            txtTitle.Text = tabPage1.Text;
        }
    }
}
