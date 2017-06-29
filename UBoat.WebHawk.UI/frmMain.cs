using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.WebHawk.Controller;
using UBoat.WebHawk.Controller.Integration.SequenceTranslators;
using UBoat.WebHawk.Controller.Model.Scheduling;
using UBoat.WebHawk.Controller.Model.Automation;
using UBoat.WebHawk.UI.Wizards;
using UBoat.WebHawk.UI.Scheduler;
using UBoat.Utils.Controls;
using UBoat.WebHawk.Controller.Data;

namespace UBoat.WebHawk.UI
{
    /// <summary>
    /// Main application form, contains Sequence & Scheduled Task lists, and tab container
    /// </summary>
    public partial class frmMain : Form
    {
        #region Private Members

        private bool m_Minimizing;
        private readonly object m_Lock;

        #endregion

        #region Constructors

        public frmMain()
        {
            InitializeComponent();
            m_Lock = new object();

            //Sequences
            olvColumnSequenceName.ImageGetter = (obj) => 0;
            imageListSequences.Images.AddRange(new Image[]
            {
                Properties.Resources.Sequence_small
            });

            //Scheduled Tasks
            olvColumnTaskName.ImageGetter = (obj) => 0;
            olvColumnTaskLastRunStart.AspectGetter = olvColumnTaskLastRunStart_AspectGetter;
            olvColumnTaskLastRunEnd.AspectGetter = olvColumnTaskLastRunEnd_AspectGetter;
            olvColumnTaskLastRunStatus.AspectGetter = olvColumnTaskLastRunStatus_AspectGetter;
            olvColumnTaskNextScheduledRunTime.AspectGetter = olvColumnTaskNextScheduledRunTime_AspectGetter;
            imageListScheduledTasks.Images.AddRange(new Image[]
            {
                Properties.Resources.schedule_icon_small
            });
        }

        #endregion

        #region olvScheduledTasks Delegates

        private void olvScheduledTasks_CellRightClick(object sender, BrightIdeasSoftware.CellRightClickEventArgs e)
        {
            if (e.Model != null)
            {
                scheduledTasksMenu.Tag = e.Model;

                ScheduledTask scheduledTask = (ScheduledTask)e.Model;
                taskDisableToolStripMenuItem.Text = scheduledTask.Enabled ? "Disable..." : "Enable...";
                taskDisableToolStripMenuItem.Image = scheduledTask.Enabled ? Properties.Resources.RedCircle : Properties.Resources.GreenCircle;
                taskRunNowToolStripMenuItem.Enabled = scheduledTask.Enabled;
                e.MenuStrip = scheduledTasksMenu;
            }
        }

        private object olvColumnTaskLastRunStart_AspectGetter(object rowObject)
        {
            ScheduledTask scheduledTask = (ScheduledTask)rowObject;
            if (scheduledTask.LastRunStatistics != null)
            {
                DateTime? lastRunStartTimeUtc = scheduledTask.LastRunStatistics.StartTimeUtc;
                if (lastRunStartTimeUtc.HasValue)
                {
                    return lastRunStartTimeUtc.Value.ToLocalTime();
                }
            }
            return null;
        }

        private object olvColumnTaskLastRunEnd_AspectGetter(object rowObject)
        {
            ScheduledTask scheduledTask = (ScheduledTask)rowObject;
            if (scheduledTask.LastRunStatistics != null)
            {
                DateTime? lastRunEndTimeUtc = scheduledTask.LastRunStatistics.EndTimeUtc;
                if (lastRunEndTimeUtc.HasValue)
                {
                    return lastRunEndTimeUtc.Value.ToLocalTime();
                }
            }
            return null;
        }

        private object olvColumnTaskLastRunStatus_AspectGetter(object rowObject)
        {
            ScheduledTask scheduledTask = (ScheduledTask)rowObject;
            if (scheduledTask.LastRunStatistics != null)
            {
                ScheduledTaskStatus? lastRunStatus = scheduledTask.LastRunStatistics.Status;
                if (lastRunStatus.HasValue)
                {
                    if (lastRunStatus.Value == ScheduledTaskStatus.Running)
                    {
                        return "Running...";
                    }
                    else
                    {
                        return lastRunStatus.Value.ToString();
                    }
                }
            }
            return null;
        }

        private object olvColumnTaskNextScheduledRunTime_AspectGetter(object rowObject)
        {
            ScheduledTask scheduledTask = (ScheduledTask)rowObject;
            if (scheduledTask.NextScheduledRunTimeUtc.HasValue)
            {
                return scheduledTask.NextScheduledRunTimeUtc.Value.ToLocalTime();
            }
            return null;
        }
        
        #endregion

        #region General Workflow

        private void frmMain_Load(object sender, EventArgs e)
        {
            zRefreshSequences();
            zRefreshScheduledTasks();

            WebHawkAppContext.Scheduler.TaskStart += Scheduler_TaskStart;
            WebHawkAppContext.Scheduler.TaskComplete += Scheduler_TaskComplete;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !zCloseAllSequences();

            if (!e.Cancel)
            {
                WebHawkAppContext.Scheduler.TaskStart -= Scheduler_TaskStart;
                WebHawkAppContext.Scheduler.TaskComplete -= Scheduler_TaskComplete;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            //TODO: figure out how to close the form and reopen it without losing the open sequences.
            //      until this is done, minimize to tray will be disabled.

            //if (this.WindowState == FormWindowState.Minimized)
            //{
            //    m_Minimizing = true;
            //    this.Close();
            //}
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmSettings frm = new frmSettings())
            {
                frm.ShowDialog();
            }
        }

        void Scheduler_TaskStart(object sender, Controller.Scheduling.TaskEventArgs e)
        {
            lock (m_Lock) //In case multiple tasks start at the same time, refresh the grid one task at a time.
            {
                zRefreshScheduledTasks();
            }
        }

        void Scheduler_TaskComplete(object sender, Controller.Scheduling.TaskEventArgs e)
        {
            lock (m_Lock) //In case multiple tasks end at the same time, refresh the grid one task at a time.
            {
                zRefreshScheduledTasks();
            }
        }

        void recorder_SequenceChanged(object sender, EventArgs e)
        {
            SequenceRecorder recorder = (SequenceRecorder)sender;
            if (recorder == zGetSequenceRecorder(tabControl1.SelectedTab))
            {
                toolStripButtonSave.Enabled = true;
            }
        }
        void recorder_ExecutionStart(object sender, EventArgs e)
        {
            SequenceRecorder recorder = (SequenceRecorder)sender;

            //Maybe we want a better way of doing this. 
            //We need to get the tab to get the sequenceId because as of now the SequenceRecorder and AutomationEngine 
            //are not aware the sequence itself, only the sequence steps.
            try
            {
                //Only load persisted state variables if the sequence is executing from the beginning
                //to avoid messing up data conditions for resumed executions.
                if (recorder.AutomationEngine.CurrentPosition == 1)
                { 
                    TabPage page = recorder.Parent as TabPage;
                    if (page != null)
                    {
                        Sequence sequence = (Sequence)page.Tag;
                        Dictionary<string, IStateVariable> persistedData = WebHawkAppContext.AutomationController.GetSequencePersistedData(sequence.SequenceId);
                        recorder.AutomationEngine.DataContext.LoadPersistedVariables(persistedData);
                    }
                }
            }
            catch (Exception ex)
            {
                //Log / Do Something here...
            }

            if (recorder == zGetSequenceRecorder(tabControl1.SelectedTab))
            {
                toolStripButtonRun.Enabled = false;
                toolStripButtonStop.Enabled = true;
            }
        }
        void recorder_ExecutionStop(object sender, EventArgs e)
        {
            SequenceRecorder recorder = (SequenceRecorder)sender;

            //Maybe we want a better way of doing this. 
            //We need to get the tab to get the sequenceId because as of now the SequenceRecorder and AutomationEngine 
            //are not aware the sequence itself, only the sequence steps.
            try
            {
                TabPage page = recorder.Parent as TabPage;
                if (page != null)
                {
                    Sequence sequence = (Sequence)page.Tag;
                    Dictionary<string, IStateVariable> persistedData = recorder.AutomationEngine.DataContext.GetPersistedVariables();
                    WebHawkAppContext.AutomationController.SetSequencePersistedData(sequence.SequenceId, persistedData);
                }
            }
            catch (Exception ex)
            {
                //Log / Do Something here...
            }

            if (recorder == zGetSequenceRecorder(tabControl1.SelectedTab))
            {
                toolStripButtonRun.Enabled = true;
                toolStripButtonStop.Enabled = false;
            }
        }

        private void zRefreshScheduledTasks()
        {
            olvScheduledTasks.SetObjects(WebHawkAppContext.SchedulingController.GetAllScheduledTasks());
        }

        private void zRefreshSequences()
        {
            olvSequences.SetObjects(WebHawkAppContext.AutomationController.GetAllSequences());
        }

        private void tabControl1_TabPageClosing(object sender, Utils.Controls.TabControlExPageClosingEventArgs e)
        {
            zCloseSequence(tabControl1.TabPages[e.TabIndex]);
            zRefreshSequences();
            e.Cancel = true; //zCloseSequence will take care of closing the tab
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tp = (TabPage)tabMenu.Tag;
            tabControl1.CloseTab(tp);
        }

        private void closeAllButThisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tp = (TabPage)tabMenu.Tag;
            foreach (TabPage page in tabControl1.TabPages)
            {
                if (page != tpSequences && page != tpScheduledTasks && page != tp)
                {
                    tabControl1.CloseTab(page);
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tpSequences || tabControl1.SelectedTab == tpScheduledTasks)
            {
                toolStripButtonRun.Enabled = false;
                toolStripButtonStop.Enabled = false;
                toolStripButtonXML.Enabled = false;
                toolStripButtonXSLT.Enabled = false;
                toolStripButtonSave.Enabled = false;
                toolStripButtonDelete.Enabled = false;
            }
            else
            {
                SequenceRecorder recorder = zGetSequenceRecorder(tabControl1.SelectedTab);
                toolStripButtonRun.Enabled = !recorder.IsExecuting;
                toolStripButtonStop.Enabled = recorder.IsExecuting;
                toolStripButtonXML.Enabled = true;
                toolStripButtonXSLT.Enabled = true;
                toolStripButtonSave.Enabled = recorder.IsDirty;
                toolStripButtonDelete.Enabled = true;
            }
        }

        private string zGetSequenceTabKey(Sequence sequence)
        {
            return String.Format("Sequence{0}", sequence.SequenceId);
        }

        #endregion

        #region Sequence Menu Operations

        private void olvSequences_CellRightClick(object sender, BrightIdeasSoftware.CellRightClickEventArgs e)
        {
            if (e.Model != null)
            {
                sequencesMenu.Tag = e.Model;
                e.MenuStrip = sequencesMenu;
            }
        }

        private void newSequenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sequence newSequence = new Sequence()
            {
                Name = "New Sequence",
                SequenceType = SequenceType.Custom
            };
            SequenceDetail newSequenceDetail = new SequenceDetail(newSequence);
            frmSequenceProperties frm = new frmSequenceProperties(newSequenceDetail, true);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                WebHawkAppContext.AutomationController.SaveSequence(newSequenceDetail);
                zRefreshSequences();
                zDesignSequence(newSequence);
            }
        }

        private void sequencePropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zEditSequenceProperties((Sequence)sequencesMenu.Tag);
        }

        private void sequenceCloneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zCloneSequence((Sequence)sequencesMenu.Tag);
        }

        private void sequenceDesignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zDesignSequence((Sequence)sequencesMenu.Tag);
        }

        private void sequenceDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zDeleteSequence((Sequence)sequencesMenu.Tag);
        }

        private void toolStripButtonRun_Click(object sender, EventArgs e)
        {
            zRunSequence((Sequence)tabControl1.SelectedTab.Tag);
        }

        private void toolStripButtonStop_Click(object sender, EventArgs e)
        {
            zStopSequence((Sequence)tabControl1.SelectedTab.Tag);
        }

        private void toolStripButtonXML_Click(object sender, EventArgs e)
        {
            zGetXML((Sequence)tabControl1.SelectedTab.Tag);
        }

        private void toolStripButtonXSLT_Click(object sender, EventArgs e)
        {
            zGetXSLT((Sequence)tabControl1.SelectedTab.Tag);
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            zSaveSequence((Sequence)tabControl1.SelectedTab.Tag);
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            zDeleteSequence((Sequence)tabControl1.SelectedTab.Tag);
        }

        #endregion

        #region Scheduled Task Menu Operations

        private void newScheduledTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScheduledTask newScheduledTask = new ScheduledTask()
            {
                TaskName = "New Scheduled Task",
                Enabled = true
            };
            frmScheduledTaskProperties frm = new frmScheduledTaskProperties(newScheduledTask, true);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                WebHawkAppContext.SchedulingController.SaveScheduledTask(newScheduledTask);
                WebHawkAppContext.Scheduler.ScheduleTask(newScheduledTask);
                zRefreshScheduledTasks();
            }
        }

        private void taskRunNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zRunScheduledTaskNow((ScheduledTask)scheduledTasksMenu.Tag);
        }

        private void taskPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zEditScheduledTaskProperties((ScheduledTask)scheduledTasksMenu.Tag);
        }

        private void taskDisableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zDisableScheduledTask((ScheduledTask)scheduledTasksMenu.Tag);
        }

        private void taskDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zDeleteScheduledTask((ScheduledTask)scheduledTasksMenu.Tag);
        }

        #endregion

        #region Keyboard Shortcuts

        #endregion

        #region Sequence Operations

        private bool zCloseAllSequences()
        {
            foreach (TabPage page in tabControl1.TabPages)
            {
                if (page != tpSequences && page != tpScheduledTasks)
                {
                    bool success = zCloseSequence(page);
                    if (!success)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool zCloseSequence(Sequence sequence, bool suppressSaveDialog = false)
        {
            string sequenceTabKey = zGetSequenceTabKey(sequence);
            if (tabControl1.TabPages.ContainsKey(sequenceTabKey))
            {
                TabPage page = tabControl1.TabPages[sequenceTabKey];
                return zCloseSequence(page, suppressSaveDialog);
            }
            return false;
        }
        private bool zCloseSequence(TabPage page, bool suppressSaveDialog = false)
        {
            if (page != null && page != tpSequences && page != tpScheduledTasks)
            {
                SequenceRecorder recorder = zGetSequenceRecorder(page);
                if (!suppressSaveDialog)
                {
                    Sequence sequence = (Sequence)page.Tag;
                    if (recorder.IsDirty)
                    {
                        DialogResult result = MessageBox.Show(
                            String.Format("Save changes to \"{0}\"?", sequence.Name),
                            "Save",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button1);
                        switch (result)
                        {
                            case DialogResult.Yes:
                                if (!zSaveSequence(sequence))
                                {
                                    return false;
                                }
                                break;
                            case DialogResult.Cancel:
                                return false;
                        }
                    }
                }
                if (recorder != null)
                {
                    recorder.SequenceChanged -= recorder_SequenceChanged;
                    recorder.ExecutionStart -= recorder_ExecutionStart;
                    recorder.ExecutionStop -= recorder_ExecutionStop;
                }
                page.ContextMenuStrip = null;

                int tabIndex = tabControl1.TabPages.IndexOf(page);
                tabControl1.TabPages.RemoveAt(tabIndex);
                page.Dispose();

                tabIndex = tabIndex < tabControl1.TabCount 
                    ? tabIndex 
                    : tabControl1.TabCount > 2 
                        ? tabControl1.TabCount - 1 
                        : 0;

                tabControl1.SelectedIndex = tabIndex;
                return true;
            }
            return false;
        }

        private SequenceRecorder zGetSequenceRecorder(Sequence sequence)
        {
            if (sequence != null)
            {
                string sequenceTabKey = zGetSequenceTabKey(sequence);
                if (tabControl1.TabPages.ContainsKey(sequenceTabKey))
                {
                    TabPage page = tabControl1.TabPages[sequenceTabKey];
                    return zGetSequenceRecorder(page);
                }
            }
            return null;
        }
        private SequenceRecorder zGetSequenceRecorder(TabPage page)
        {
            return page.Controls.OfType<SequenceRecorder>().FirstOrDefault();
        }

        private void zRunSequence(Sequence sequence)
        {
            SequenceRecorder recorder = zGetSequenceRecorder(sequence);
            if (recorder != null)
            {
                recorder.ExecuteSequence();
            }
        }

        private void zStopSequence(Sequence sequence)
        {
            SequenceRecorder recorder = zGetSequenceRecorder(sequence);
            if (recorder != null)
            {
                recorder.StopExecution();
            }
        }

        private void zGetXML(Sequence sequence)
        {
            SequenceRecorder recorder = zGetSequenceRecorder(sequence);
            if (recorder != null && recorder.AutomationEngine != null && recorder.AutomationEngine.DataContext != null)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "XML Files (*.xml)|*.xml";
                dlg.FileName = String.Format("{0}.xml", sequence.Name);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string xml = recorder.AutomationEngine.DataContext.ToXml();
                    File.WriteAllText(dlg.FileName, xml);
                    MessageBox.Show(String.Format("XML from sequence \"{0}\" successfully saved to \"{1}\".", sequence.Name, dlg.FileName),
                        "Saved",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void zGetXSLT(Sequence sequence)
        {
            if (sequence != null)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "XSLT Files (*.xslt)|*.xslt";
                dlg.FileName = String.Format("{0}.xslt", sequence.Name);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    SequenceDetail sequenceDetail = WebHawkAppContext.AutomationController.GetSequenceDetail(sequence.SequenceId);
                    ISequenceTranslator translator = SequenceTranslatorFactory.GetSequenceTranslator(SequenceTranslationType.XSLT);
                    string xslt = translator.Translate(sequenceDetail.SequenceSteps).ToString();
                    File.WriteAllText(dlg.FileName, xslt);
                    MessageBox.Show(String.Format("XSLT translation of sequence \"{0}\" successfully saved to \"{1}\".", sequence.Name, dlg.FileName),
                        "Saved",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void zEditSequenceProperties(Sequence sequence)
        {
            if (sequence != null)
            {
                SequenceDetail sequenceDetail = WebHawkAppContext.AutomationController.GetSequenceDetail(sequence.SequenceId);
                frmSequenceProperties frm = new frmSequenceProperties(sequenceDetail, false);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    WebHawkAppContext.AutomationController.SaveSequence(sequenceDetail);
                    zRefreshSequences();
                }
            }
        }

        private void zDesignSequence(Sequence sequence)
        {
            if (sequence != null)
            {
                string sequenceTabKey = zGetSequenceTabKey(sequence);
                if (tabControl1.TabPages.ContainsKey(sequenceTabKey))
                {
                    tabControl1.SelectTab(sequenceTabKey);
                }
                else
                {
                    SequenceDetail sequenceDetail = WebHawkAppContext.AutomationController.GetSequenceDetail(sequence.SequenceId);

                    TabPageEx tpEditSequence = new TabPageEx(sequence.Name);
                    tpEditSequence.Name = sequenceTabKey;
                    tpEditSequence.Tag = sequence;
                    tpEditSequence.ContextMenuStrip = tabMenu;
                    SequenceRecorder recorder = new SequenceRecorder(sequenceDetail.SequenceSteps);
                    recorder.Dock = DockStyle.Fill;
                    tpEditSequence.Controls.Add(recorder);

                    recorder.SequenceChanged += recorder_SequenceChanged;
                    recorder.ExecutionStart += recorder_ExecutionStart;
                    recorder.ExecutionStop += recorder_ExecutionStop;

                    tabControl1.TabPages.Add(tpEditSequence);
                    tabControl1.SelectedTab = tpEditSequence;

                    recorder.ExecuteSequence(1);
                }
            }
        }

        private bool zSaveSequence(Sequence sequence)
        {
            if (sequence != null)
            {
                SequenceRecorder recorder = zGetSequenceRecorder(sequence);

                SequenceDetail sequenceDetail = new SequenceDetail(sequence, recorder.SequenceSteps);
                WebHawkAppContext.AutomationController.SaveSequence(sequenceDetail);
                recorder.ResetIsDirtyFlag();
                
                if (recorder == zGetSequenceRecorder(tabControl1.SelectedTab))
                {
                    toolStripButtonSave.Enabled = false;
                }
                zRefreshSequences();
                return true;
            }
            return false;
        }

        private void zDeleteSequence(Sequence sequence)
        {
            if (sequence != null)
            {
                if (MessageBox.Show(String.Format("Are you sure you want to delete \"{0}\"?", sequence.Name),
                    "Delete Sequence",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    zCloseSequence(sequence, true);
                    WebHawkAppContext.AutomationController.DeleteSequence(sequence);
                    zRefreshSequences();
                }
            }
        }

        private void zCloneSequence(Sequence sequence)
        {
            if (sequence != null)
            {
                SequenceDetail sequenceDetail = WebHawkAppContext.AutomationController.GetSequenceDetail(sequence.SequenceId);
                frmCloneSequence frm = new frmCloneSequence(sequenceDetail.Sequence.Name);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    sequenceDetail.Sequence.SequenceId = default(long);
                    sequenceDetail.Sequence.Name = frm.NewName;
                    WebHawkAppContext.AutomationController.SaveSequence(sequenceDetail);
                    zRefreshSequences();
                }
            }
        }

        #endregion

        #region Scheduled Task Operations

        private void zRunScheduledTaskNow(ScheduledTask task)
        {
            if (task != null)
            {
                WebHawkAppContext.Scheduler.RunTask(task);
            }
        }

        private void zEditScheduledTaskProperties(ScheduledTask task)
        {
            if (task != null)
            {
                frmScheduledTaskProperties frm = new frmScheduledTaskProperties(task, false);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    WebHawkAppContext.SchedulingController.SaveScheduledTask(task);
                    WebHawkAppContext.Scheduler.ScheduleTask(task);
                    zRefreshScheduledTasks();
                }
            }
        }

        private void zDisableScheduledTask(ScheduledTask task)
        {
            if (task != null)
            {
                bool cancelAction = false;
                if (task.Enabled)
                {
                    DialogResult result = MessageBox.Show(
                        String.Format("Are you sure you want to disable the scheduled task \"{0}\"?", task.TaskName),
                        "Disable Scheduled Task",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    cancelAction = result != DialogResult.Yes;
                }

                if (!cancelAction)
                {
                    task.Enabled = !task.Enabled;
                    WebHawkAppContext.SchedulingController.SaveScheduledTask(task);
                    WebHawkAppContext.Scheduler.ScheduleTask(task);
                    zRefreshScheduledTasks();
                }
            }
        }

        private void zDeleteScheduledTask(ScheduledTask task)
        {
            if (task != null)
            {
                if (MessageBox.Show(String.Format("Are you sure you want to delete \"{0}\"?", task.TaskName),
                    "Delete Scheduled Task",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    WebHawkAppContext.Scheduler.RemoveTask(task);
                    WebHawkAppContext.SchedulingController.DeleteScheduledTask(task);
                    zRefreshScheduledTasks();
                }
            }
        }

        #endregion
    }
}
