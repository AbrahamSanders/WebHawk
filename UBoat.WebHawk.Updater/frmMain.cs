using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using UBoat.Utils.Threading;

namespace UBoat.WebHawk.Updater
{
    public partial class frmMain : Form
    {
        Thread m_Worker;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            m_Worker = new Thread(zDoUpdate);
            m_Worker.IsBackground = true;
            m_Worker.Start();
        }

        private void zDoUpdate()
        {
            zUpdateStatus("Determining latest version...", 10);
            string latestVersion = VersionSync.GetLatestVersion();
            zUpdateStatus("Determining current version...", 20);
            string currentVersion = VersionSync.GetCurrentVersion();

            if (currentVersion == latestVersion)
            {
                zUpdateStatus("Current version is latest version.", 100);
                Thread.Sleep(1000);
                zDone();
                return;
            }

            zUpdateStatus("Downloading latest version...", 30);
        }

        private void zUpdateStatus(string status, int pbValue)
        {
            ThreadingUtils.InvokeControlAction(lblStatus, lbl => lbl.Text = status);
            ThreadingUtils.InvokeControlAction(pbStatus, pb => pb.Value = pbValue);
        }

        private void zDone()
        {
            ThreadingUtils.InvokeControlAction(this, frm => frm.Close());
        }
    }
}
