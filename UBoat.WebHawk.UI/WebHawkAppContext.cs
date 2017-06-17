using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.Utils;
using UBoat.Utils.Threading;
using UBoat.WebHawk.Controller.Automation;
using UBoat.WebHawk.Controller.Settings;
using scheduling = UBoat.WebHawk.Controller.Scheduling;

namespace UBoat.WebHawk.UI
{
    public class WebHawkAppContext : ApplicationContext
    {
        private NotifyIcon m_Notify;
        private frmMain m_MainForm;
        
        public static AutomationController AutomationController { get; private set; }
        public static SettingsController SettingsController { get; private set; }
        public static scheduling.SchedulingController SchedulingController { get; private set; }
        public static scheduling.Scheduler Scheduler { get; private set; }

        public WebHawkAppContext(bool startMinimized)
        {
            //Initialize Controller & Scheduler
            zCheckIEBrowserMode();

            //Instantiate m_MainForm here. This sets the SynchronizationContext.Current value needed to start the scheduler.
            //When the scheduler is split out of this executable process (to a service or agent application), we won't need to worry about this.
            m_MainForm = new frmMain();
            this.MainForm = m_MainForm;

            string connectionString = ConfigurationManager.ConnectionStrings["WebHawkDb"].ConnectionString;
            AutomationController = new AutomationController(connectionString);
            SettingsController = new SettingsController(connectionString);
            SchedulingController = new scheduling.SchedulingController(connectionString);
            Scheduler = new scheduling.Scheduler(connectionString, new ThreadSynchronizer());
            Scheduler.Start();

            //Set up tray icon
            m_Notify = new NotifyIcon();
            m_Notify.Icon = (System.Drawing.Icon)Properties.Resources.ResourceManager.GetObject("Icon1");
            m_Notify.Text = "Double-click to open.";
            m_Notify.MouseDoubleClick += new MouseEventHandler(m_Notify_MouseDoubleClick);
            m_Notify.Visible = true;
            
            //Show frmMain
            if (startMinimized)
            {
                m_MainForm.WindowState = FormWindowState.Minimized;
            }
            else
            {
                m_MainForm.Show();
            }
        }

        private void m_Notify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (m_MainForm != null)
            {
                if (m_MainForm.WindowState == FormWindowState.Minimized)
                {
                    m_MainForm.WindowState = FormWindowState.Normal;
                    //TODO: figure out how to close the form and reopen it without losing the open sequences.
                    //      until this is done, minimize to tray will be disabled.

                    //m_MainForm.Dispose();
                    //m_MainForm = new frmMain();
                    //m_MainForm.Show();
                }
            }
        }

        private void zCheckIEBrowserMode()
        {
            IEBrowserMode? installedIEVersion = RegistryUtils.GetInstalledIEBrowserVersion();
            if (installedIEVersion == null)
            {
                MessageBox.Show("Could not determine installed IE version. If the application browser emulation mode is not synchronized with the installed IE version, some unexpected behavior can occur.",
                    "Browser Detection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            IEBrowserMode? applicationIEBrowserMode = RegistryUtils.GetApplicationIEBrowserMode();
            if (applicationIEBrowserMode != installedIEVersion)
            {
                RegistryUtils.SetApplicationIEBrowserMode(installedIEVersion.Value);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (WebHawkAppContext.Scheduler != null)
            {
                WebHawkAppContext.Scheduler.Dispose();
            }
            
            WebHawkAppContext.AutomationController = null;
            WebHawkAppContext.SettingsController = null;
            WebHawkAppContext.SchedulingController = null;
            WebHawkAppContext.Scheduler = null;

            base.Dispose(disposing);
        }
    }
}
