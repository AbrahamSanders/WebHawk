using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace UBoat.WebHawk.Controller.Notification
{
    public partial class frmPopup : Form
    {
        public frmPopup(string message)
        {
            InitializeComponent();
            rtbMessage.Text = message;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmPopup_Load(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void rtbMessage_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
    }
}
