using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.WebHawk.Controller.Model.Scheduling;

namespace UBoat.WebHawk.UI.Wizards
{
    public partial class Wizard : UserControl
    {
        private List<WizardPage> m_WizardPages;
        private int m_CurrentPageIndex;
        private ScheduledTask m_Task;
        private bool m_IsUpdateMode;

        public Wizard()
            : this(null) { }

        public Wizard(ScheduledTask task)
        {
            InitializeComponent();
            if (task == null)
            {
                m_Task = SetupTask();
            }
            else
            {
                m_Task = task;
                m_IsUpdateMode = true;
            }
            zInitializeWizard();
        }

        private void zInitializeWizard()
        {
            m_WizardPages = GetWizardPages();

            foreach (WizardPage page in m_WizardPages)
            {
                page.Task = m_Task;
                page.IsUpdateMode = m_IsUpdateMode;
                page.EnableNext += page_EnableNext;
                page.DisableNext += page_DisableNext;
                page.Dock = DockStyle.Fill;
                pageContainerPanel.Controls.Add(page);
            }
            
            m_CurrentPageIndex = 0;
            zShowPage(m_CurrentPageIndex, true);
        }

        protected virtual ScheduledTask SetupTask()
        {
            throw new NotImplementedException();
        }

        protected virtual List<WizardPage> GetWizardPages()
        {
            throw new NotImplementedException();
        }

        private void zShowPage(int pageIndex, bool initPage)
        {
            WizardPage page = m_WizardPages[pageIndex];
            page.OnShow(initPage);
            page.BringToFront();
        }

        void page_EnableNext(object sender, EventArgs e)
        {
            btnNext.Enabled = true;
        }

        void page_DisableNext(object sender, EventArgs e)
        {
            btnNext.Enabled = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            m_WizardPages[m_CurrentPageIndex].OnNext();

            if (m_CurrentPageIndex < m_WizardPages.Count - 1)
            {
                m_CurrentPageIndex++;
                zShowPage(m_CurrentPageIndex, true);
                btnBack.Enabled = true;
                if (m_CurrentPageIndex == m_WizardPages.Count - 1)
                {
                    btnNext.Text = "Finish";
                }
            }
            else
            {
                if (m_IsUpdateMode)
                {
                    //WebHawkAppContext.Controller.UpdateTask(m_Task);
                }
                else
                {
                    //WebHawkAppContext.Controller.AddTask(m_Task);
                }
                zOnWizardFinished(EventArgs.Empty);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            m_CurrentPageIndex--;
            zShowPage(m_CurrentPageIndex, false);
            if (m_CurrentPageIndex == 0)
            {
                btnBack.Enabled = false;
            }
            btnNext.Text = "Next >";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            zOnWizardFinished(EventArgs.Empty);
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                if (m_WizardPages != null)
                {
                    foreach (WizardPage wp in m_WizardPages)
                    {
                        wp.Dispose();
                    }
                    m_WizardPages.Clear();
                    m_WizardPages = null;
                }
                m_Task = null;
            }
            base.Dispose(disposing);
        }

        public event EventHandler WizardFinished;
        protected void zOnWizardFinished(EventArgs e)
        {
            EventHandler evnt = WizardFinished;
            if (evnt != null)
            {
                evnt(this, e);
            }
        }
    }
}
