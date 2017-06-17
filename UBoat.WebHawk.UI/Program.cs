using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace UBoat.WebHawk.UI
{
    static class Program
    {
        static Mutex m_Mutex = new Mutex(true, "{1CBA7A00-1EE8-4347-9D40-ED78F1FE79E3}");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (m_Mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                bool startMinimized = args.Any(arg => arg.ToLower() == "/m");
                WebHawkAppContext appCtx = new WebHawkAppContext(startMinimized);
                Application.Run(appCtx);
            }
            else
            {
                MessageBox.Show("Another instance of Web Hawk is already running.", "Web Hawk", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
