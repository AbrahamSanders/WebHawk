using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using UBoat.WebHawk.Controller.Model;
using UBoat.Utils;
using UBoat.Utils.Threading;

namespace UBoat.WebHawk.Controller.Automation
{
    internal partial class frmAutomation : Form
    {
        public WebBrowser Browser
        {
            get
            {
                return wbAutomation;
            }
        }

        public frmAutomation()
        {
            InitializeComponent();
        }
    }
}
