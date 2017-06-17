using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UBoat.WebHawk.Controller.Settings;

namespace UBoat.WebHawk.UI
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            WebHawkAppContext.SettingsController.SetSettingValue(WebHawkSettings.StartWithWindows, cbStartWithWindows.Checked.ToString());

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            bool startWithWindows;
            if (WebHawkAppContext.SettingsController.TryGetSettingValue<bool>(WebHawkSettings.StartWithWindows, out startWithWindows))
            {
                cbStartWithWindows.Checked = startWithWindows;
            }
        }
    }
}
