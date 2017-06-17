namespace UBoat.WebHawk.UI
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSequenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newScheduledTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabControl1 = new UBoat.Utils.Controls.TabControlEx();
            this.tpSequences = new UBoat.Utils.Controls.TabPageEx();
            this.olvSequences = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnSequenceName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnSequenceType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnSequenceStepCount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageListSequences = new System.Windows.Forms.ImageList(this.components);
            this.tpScheduledTasks = new UBoat.Utils.Controls.TabPageEx();
            this.olvScheduledTasks = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnTaskName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnTaskSequence = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnTaskLastRunStart = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnTaskLastRunEnd = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnTaskLastRunStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnTaskLastRunError = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnTaskNextScheduledRunTime = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnTaskEnabled = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageListScheduledTasks = new System.Windows.Forms.ImageList(this.components);
            this.sequencesMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sequenceDesignToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sequencePropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sequenceCloneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sequenceDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonRun = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonXML = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonXSLT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.scheduledTasksMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.taskRunNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskDisableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.taskDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllButThisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpSequences.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvSequences)).BeginInit();
            this.tpScheduledTasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvScheduledTasks)).BeginInit();
            this.sequencesMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.scheduledTasksMenu.SuspendLayout();
            this.tabMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1227, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSequenceToolStripMenuItem,
            this.newScheduledTaskToolStripMenuItem,
            this.toolStripSeparator1,
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // newSequenceToolStripMenuItem
            // 
            this.newSequenceToolStripMenuItem.Name = "newSequenceToolStripMenuItem";
            this.newSequenceToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.newSequenceToolStripMenuItem.Text = "New Sequence";
            this.newSequenceToolStripMenuItem.Click += new System.EventHandler(this.newSequenceToolStripMenuItem_Click);
            // 
            // newScheduledTaskToolStripMenuItem
            // 
            this.newScheduledTaskToolStripMenuItem.Name = "newScheduledTaskToolStripMenuItem";
            this.newScheduledTaskToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.newScheduledTaskToolStripMenuItem.Text = "New Scheduled Task";
            this.newScheduledTaskToolStripMenuItem.Click += new System.EventHandler(this.newScheduledTaskToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 728);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1227, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpSequences);
            this.tabControl1.Controls.Add(this.tpScheduledTasks);
            this.tabControl1.ItemSize = new System.Drawing.Size(58, 24);
            this.tabControl1.Location = new System.Drawing.Point(0, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1227, 673);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.TabPageClosing += new System.EventHandler<UBoat.Utils.Controls.TabControlExPageClosingEventArgs>(this.tabControl1_TabPageClosing);
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tpSequences
            // 
            this.tpSequences.Controls.Add(this.olvSequences);
            this.tpSequences.HasCloseButton = false;
            this.tpSequences.ImageIndex = 0;
            this.tpSequences.Location = new System.Drawing.Point(4, 28);
            this.tpSequences.Name = "tpSequences";
            this.tpSequences.Padding = new System.Windows.Forms.Padding(3);
            this.tpSequences.Size = new System.Drawing.Size(1219, 641);
            this.tpSequences.TabIndex = 0;
            this.tpSequences.Text = "Sequences";
            this.tpSequences.UseVisualStyleBackColor = true;
            // 
            // olvSequences
            // 
            this.olvSequences.AllColumns.Add(this.olvColumnSequenceName);
            this.olvSequences.AllColumns.Add(this.olvColumnSequenceType);
            this.olvSequences.AllColumns.Add(this.olvColumnSequenceStepCount);
            this.olvSequences.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvSequences.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnSequenceName,
            this.olvColumnSequenceType,
            this.olvColumnSequenceStepCount});
            this.olvSequences.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvSequences.EmptyListMsg = "You have not created any Sequences.";
            this.olvSequences.EmptyListMsgFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvSequences.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvSequences.FullRowSelect = true;
            this.olvSequences.Location = new System.Drawing.Point(8, 6);
            this.olvSequences.MultiSelect = false;
            this.olvSequences.Name = "olvSequences";
            this.olvSequences.ShowGroups = false;
            this.olvSequences.Size = new System.Drawing.Size(1203, 628);
            this.olvSequences.SmallImageList = this.imageListSequences;
            this.olvSequences.TabIndex = 0;
            this.olvSequences.UseCompatibleStateImageBehavior = false;
            this.olvSequences.UseHotItem = true;
            this.olvSequences.UseHyperlinks = true;
            this.olvSequences.View = System.Windows.Forms.View.Details;
            this.olvSequences.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.olvSequences_CellRightClick);
            // 
            // olvColumnSequenceName
            // 
            this.olvColumnSequenceName.AspectName = "Name";
            this.olvColumnSequenceName.IsEditable = false;
            this.olvColumnSequenceName.Text = "Sequence Name";
            this.olvColumnSequenceName.Width = 250;
            // 
            // olvColumnSequenceType
            // 
            this.olvColumnSequenceType.AspectName = "SequenceType";
            this.olvColumnSequenceType.IsEditable = false;
            this.olvColumnSequenceType.Text = "Sequence Type";
            this.olvColumnSequenceType.Width = 150;
            // 
            // olvColumnSequenceStepCount
            // 
            this.olvColumnSequenceStepCount.AspectName = "StepCount";
            this.olvColumnSequenceStepCount.IsEditable = false;
            this.olvColumnSequenceStepCount.Text = "Step Count";
            this.olvColumnSequenceStepCount.Width = 100;
            // 
            // imageListSequences
            // 
            this.imageListSequences.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListSequences.ImageSize = new System.Drawing.Size(22, 26);
            this.imageListSequences.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tpScheduledTasks
            // 
            this.tpScheduledTasks.Controls.Add(this.olvScheduledTasks);
            this.tpScheduledTasks.HasCloseButton = false;
            this.tpScheduledTasks.Location = new System.Drawing.Point(4, 28);
            this.tpScheduledTasks.Name = "tpScheduledTasks";
            this.tpScheduledTasks.Padding = new System.Windows.Forms.Padding(3);
            this.tpScheduledTasks.Size = new System.Drawing.Size(1219, 641);
            this.tpScheduledTasks.TabIndex = 1;
            this.tpScheduledTasks.Text = "Scheduled Tasks";
            this.tpScheduledTasks.UseVisualStyleBackColor = true;
            // 
            // olvScheduledTasks
            // 
            this.olvScheduledTasks.AllColumns.Add(this.olvColumnTaskName);
            this.olvScheduledTasks.AllColumns.Add(this.olvColumnTaskSequence);
            this.olvScheduledTasks.AllColumns.Add(this.olvColumnTaskLastRunStart);
            this.olvScheduledTasks.AllColumns.Add(this.olvColumnTaskLastRunEnd);
            this.olvScheduledTasks.AllColumns.Add(this.olvColumnTaskLastRunStatus);
            this.olvScheduledTasks.AllColumns.Add(this.olvColumnTaskLastRunError);
            this.olvScheduledTasks.AllColumns.Add(this.olvColumnTaskNextScheduledRunTime);
            this.olvScheduledTasks.AllColumns.Add(this.olvColumnTaskEnabled);
            this.olvScheduledTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvScheduledTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnTaskName,
            this.olvColumnTaskSequence,
            this.olvColumnTaskLastRunStart,
            this.olvColumnTaskLastRunEnd,
            this.olvColumnTaskLastRunStatus,
            this.olvColumnTaskLastRunError,
            this.olvColumnTaskNextScheduledRunTime,
            this.olvColumnTaskEnabled});
            this.olvScheduledTasks.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvScheduledTasks.EmptyListMsg = "You have not created any Scheduled Tasks.";
            this.olvScheduledTasks.EmptyListMsgFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvScheduledTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvScheduledTasks.FullRowSelect = true;
            this.olvScheduledTasks.Location = new System.Drawing.Point(8, 6);
            this.olvScheduledTasks.MultiSelect = false;
            this.olvScheduledTasks.Name = "olvScheduledTasks";
            this.olvScheduledTasks.ShowGroups = false;
            this.olvScheduledTasks.Size = new System.Drawing.Size(1203, 628);
            this.olvScheduledTasks.SmallImageList = this.imageListScheduledTasks;
            this.olvScheduledTasks.TabIndex = 1;
            this.olvScheduledTasks.UseCompatibleStateImageBehavior = false;
            this.olvScheduledTasks.UseHotItem = true;
            this.olvScheduledTasks.UseHyperlinks = true;
            this.olvScheduledTasks.View = System.Windows.Forms.View.Details;
            this.olvScheduledTasks.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.olvScheduledTasks_CellRightClick);
            // 
            // olvColumnTaskName
            // 
            this.olvColumnTaskName.AspectName = "TaskName";
            this.olvColumnTaskName.IsEditable = false;
            this.olvColumnTaskName.Text = "Task Name";
            this.olvColumnTaskName.Width = 178;
            // 
            // olvColumnTaskSequence
            // 
            this.olvColumnTaskSequence.AspectName = "TaskSequence.Name";
            this.olvColumnTaskSequence.IsEditable = false;
            this.olvColumnTaskSequence.Text = "Sequence";
            this.olvColumnTaskSequence.Width = 154;
            // 
            // olvColumnTaskLastRunStart
            // 
            this.olvColumnTaskLastRunStart.AspectName = "";
            this.olvColumnTaskLastRunStart.IsEditable = false;
            this.olvColumnTaskLastRunStart.Text = "Last Run Start";
            this.olvColumnTaskLastRunStart.Width = 175;
            // 
            // olvColumnTaskLastRunEnd
            // 
            this.olvColumnTaskLastRunEnd.IsEditable = false;
            this.olvColumnTaskLastRunEnd.Text = "Last Run End";
            this.olvColumnTaskLastRunEnd.Width = 168;
            // 
            // olvColumnTaskLastRunStatus
            // 
            this.olvColumnTaskLastRunStatus.IsEditable = false;
            this.olvColumnTaskLastRunStatus.Text = "Last Run Status";
            this.olvColumnTaskLastRunStatus.Width = 141;
            // 
            // olvColumnTaskLastRunError
            // 
            this.olvColumnTaskLastRunError.AspectName = "LastRunStatistics.Error";
            this.olvColumnTaskLastRunError.IsEditable = false;
            this.olvColumnTaskLastRunError.Text = "Last Run Error";
            this.olvColumnTaskLastRunError.Width = 153;
            // 
            // olvColumnTaskNextScheduledRunTime
            // 
            this.olvColumnTaskNextScheduledRunTime.IsEditable = false;
            this.olvColumnTaskNextScheduledRunTime.Text = "Next Run";
            this.olvColumnTaskNextScheduledRunTime.Width = 157;
            // 
            // olvColumnTaskEnabled
            // 
            this.olvColumnTaskEnabled.AspectName = "Enabled";
            this.olvColumnTaskEnabled.Text = "Enabled";
            this.olvColumnTaskEnabled.Width = 70;
            // 
            // imageListScheduledTasks
            // 
            this.imageListScheduledTasks.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListScheduledTasks.ImageSize = new System.Drawing.Size(30, 23);
            this.imageListScheduledTasks.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // sequencesMenu
            // 
            this.sequencesMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sequenceDesignToolStripMenuItem,
            this.sequencePropertiesToolStripMenuItem,
            this.sequenceCloneToolStripMenuItem,
            this.toolStripSeparator2,
            this.sequenceDeleteToolStripMenuItem});
            this.sequencesMenu.Name = "sequencesMenu";
            this.sequencesMenu.Size = new System.Drawing.Size(137, 98);
            // 
            // sequenceDesignToolStripMenuItem
            // 
            this.sequenceDesignToolStripMenuItem.Image = global::UBoat.WebHawk.UI.Properties.Resources.Edit2;
            this.sequenceDesignToolStripMenuItem.Name = "sequenceDesignToolStripMenuItem";
            this.sequenceDesignToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.sequenceDesignToolStripMenuItem.Text = "Design...";
            this.sequenceDesignToolStripMenuItem.Click += new System.EventHandler(this.sequenceDesignToolStripMenuItem_Click);
            // 
            // sequencePropertiesToolStripMenuItem
            // 
            this.sequencePropertiesToolStripMenuItem.Image = global::UBoat.WebHawk.UI.Properties.Resources.Document;
            this.sequencePropertiesToolStripMenuItem.Name = "sequencePropertiesToolStripMenuItem";
            this.sequencePropertiesToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.sequencePropertiesToolStripMenuItem.Text = "Properties...";
            this.sequencePropertiesToolStripMenuItem.Click += new System.EventHandler(this.sequencePropertiesToolStripMenuItem_Click);
            // 
            // sequenceCloneToolStripMenuItem
            // 
            this.sequenceCloneToolStripMenuItem.Image = global::UBoat.WebHawk.UI.Properties.Resources.CloneIconSmall;
            this.sequenceCloneToolStripMenuItem.Name = "sequenceCloneToolStripMenuItem";
            this.sequenceCloneToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.sequenceCloneToolStripMenuItem.Text = "Clone";
            this.sequenceCloneToolStripMenuItem.Click += new System.EventHandler(this.sequenceCloneToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(133, 6);
            // 
            // sequenceDeleteToolStripMenuItem
            // 
            this.sequenceDeleteToolStripMenuItem.Image = global::UBoat.WebHawk.UI.Properties.Resources.Delete;
            this.sequenceDeleteToolStripMenuItem.Name = "sequenceDeleteToolStripMenuItem";
            this.sequenceDeleteToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.sequenceDeleteToolStripMenuItem.Text = "Delete";
            this.sequenceDeleteToolStripMenuItem.Click += new System.EventHandler(this.sequenceDeleteToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonRun,
            this.toolStripButtonStop,
            this.toolStripButtonXML,
            this.toolStripButtonXSLT,
            this.toolStripSeparator3,
            this.toolStripButtonSave,
            this.toolStripButtonDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1227, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonRun
            // 
            this.toolStripButtonRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRun.Enabled = false;
            this.toolStripButtonRun.Image = global::UBoat.WebHawk.UI.Properties.Resources.PlayIcon;
            this.toolStripButtonRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRun.Name = "toolStripButtonRun";
            this.toolStripButtonRun.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRun.ToolTipText = "Run Sequence";
            this.toolStripButtonRun.Click += new System.EventHandler(this.toolStripButtonRun_Click);
            // 
            // toolStripButtonStop
            // 
            this.toolStripButtonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStop.Enabled = false;
            this.toolStripButtonStop.Image = global::UBoat.WebHawk.UI.Properties.Resources.StopIcon;
            this.toolStripButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStop.Name = "toolStripButtonStop";
            this.toolStripButtonStop.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonStop.ToolTipText = "Stop Sequence";
            this.toolStripButtonStop.Click += new System.EventHandler(this.toolStripButtonStop_Click);
            // 
            // toolStripButtonXML
            // 
            this.toolStripButtonXML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonXML.Enabled = false;
            this.toolStripButtonXML.Image = global::UBoat.WebHawk.UI.Properties.Resources.xml;
            this.toolStripButtonXML.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonXML.Name = "toolStripButtonXML";
            this.toolStripButtonXML.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonXML.ToolTipText = "Save XML From Sequence";
            this.toolStripButtonXML.Click += new System.EventHandler(this.toolStripButtonXML_Click);
            // 
            // toolStripButtonXSLT
            // 
            this.toolStripButtonXSLT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonXSLT.Enabled = false;
            this.toolStripButtonXSLT.Image = global::UBoat.WebHawk.UI.Properties.Resources.XSLT;
            this.toolStripButtonXSLT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonXSLT.Name = "toolStripButtonXSLT";
            this.toolStripButtonXSLT.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonXSLT.ToolTipText = "Translate Sequence to XSLT";
            this.toolStripButtonXSLT.Click += new System.EventHandler(this.toolStripButtonXSLT_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Enabled = false;
            this.toolStripButtonSave.Image = global::UBoat.WebHawk.UI.Properties.Resources.save;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSave.ToolTipText = "Save Sequence";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDelete.Enabled = false;
            this.toolStripButtonDelete.Image = global::UBoat.WebHawk.UI.Properties.Resources.Delete;
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDelete.ToolTipText = "Delete Sequence";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
            // 
            // scheduledTasksMenu
            // 
            this.scheduledTasksMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taskRunNowToolStripMenuItem,
            this.taskDisableToolStripMenuItem,
            this.taskPropertiesToolStripMenuItem,
            this.toolStripSeparator4,
            this.taskDeleteToolStripMenuItem});
            this.scheduledTasksMenu.Name = "scheduledTasksMenu";
            this.scheduledTasksMenu.Size = new System.Drawing.Size(137, 98);
            // 
            // taskRunNowToolStripMenuItem
            // 
            this.taskRunNowToolStripMenuItem.Image = global::UBoat.WebHawk.UI.Properties.Resources.PlayIcon;
            this.taskRunNowToolStripMenuItem.Name = "taskRunNowToolStripMenuItem";
            this.taskRunNowToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.taskRunNowToolStripMenuItem.Text = "Run Now...";
            this.taskRunNowToolStripMenuItem.Click += new System.EventHandler(this.taskRunNowToolStripMenuItem_Click);
            // 
            // taskDisableToolStripMenuItem
            // 
            this.taskDisableToolStripMenuItem.Image = global::UBoat.WebHawk.UI.Properties.Resources.RedCircle;
            this.taskDisableToolStripMenuItem.Name = "taskDisableToolStripMenuItem";
            this.taskDisableToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.taskDisableToolStripMenuItem.Text = "Disable...";
            this.taskDisableToolStripMenuItem.Click += new System.EventHandler(this.taskDisableToolStripMenuItem_Click);
            // 
            // taskPropertiesToolStripMenuItem
            // 
            this.taskPropertiesToolStripMenuItem.Image = global::UBoat.WebHawk.UI.Properties.Resources.Document;
            this.taskPropertiesToolStripMenuItem.Name = "taskPropertiesToolStripMenuItem";
            this.taskPropertiesToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.taskPropertiesToolStripMenuItem.Text = "Properties...";
            this.taskPropertiesToolStripMenuItem.Click += new System.EventHandler(this.taskPropertiesToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(133, 6);
            // 
            // taskDeleteToolStripMenuItem
            // 
            this.taskDeleteToolStripMenuItem.Image = global::UBoat.WebHawk.UI.Properties.Resources.Delete;
            this.taskDeleteToolStripMenuItem.Name = "taskDeleteToolStripMenuItem";
            this.taskDeleteToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.taskDeleteToolStripMenuItem.Text = "Delete";
            this.taskDeleteToolStripMenuItem.Click += new System.EventHandler(this.taskDeleteToolStripMenuItem_Click);
            // 
            // tabMenu
            // 
            this.tabMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.closeAllButThisToolStripMenuItem});
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.Size = new System.Drawing.Size(167, 48);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = global::UBoat.WebHawk.UI.Properties.Resources.Delete;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // closeAllButThisToolStripMenuItem
            // 
            this.closeAllButThisToolStripMenuItem.Name = "closeAllButThisToolStripMenuItem";
            this.closeAllButThisToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.closeAllButThisToolStripMenuItem.Text = "Close All But This";
            this.closeAllButThisToolStripMenuItem.Click += new System.EventHandler(this.closeAllButThisToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1227, 750);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "frmMain";
            this.Text = "Web Hawk 0.3 Beta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpSequences.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvSequences)).EndInit();
            this.tpScheduledTasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvScheduledTasks)).EndInit();
            this.sequencesMenu.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.scheduledTasksMenu.ResumeLayout(false);
            this.tabMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSequenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private UBoat.Utils.Controls.TabControlEx tabControl1;
        private UBoat.Utils.Controls.TabPageEx tpSequences;
        private BrightIdeasSoftware.ObjectListView olvSequences;
        private BrightIdeasSoftware.OLVColumn olvColumnSequenceName;
        private BrightIdeasSoftware.OLVColumn olvColumnSequenceType;
        private BrightIdeasSoftware.OLVColumn olvColumnSequenceStepCount;
        private System.Windows.Forms.ImageList imageListSequences;
        private System.Windows.Forms.ContextMenuStrip sequencesMenu;
        private System.Windows.Forms.ToolStripMenuItem sequenceDesignToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sequenceDeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonRun;
        private System.Windows.Forms.ToolStripButton toolStripButtonXSLT;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.ToolStripButton toolStripButtonXML;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonStop;
        private System.Windows.Forms.ToolStripMenuItem sequencePropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private UBoat.Utils.Controls.TabPageEx tpScheduledTasks;
        private BrightIdeasSoftware.ObjectListView olvScheduledTasks;
        private BrightIdeasSoftware.OLVColumn olvColumnTaskName;
        private BrightIdeasSoftware.OLVColumn olvColumnTaskSequence;
        private BrightIdeasSoftware.OLVColumn olvColumnTaskLastRunStart;
        private BrightIdeasSoftware.OLVColumn olvColumnTaskLastRunEnd;
        private BrightIdeasSoftware.OLVColumn olvColumnTaskLastRunStatus;
        private BrightIdeasSoftware.OLVColumn olvColumnTaskNextScheduledRunTime;
        private BrightIdeasSoftware.OLVColumn olvColumnTaskLastRunError;
        private System.Windows.Forms.ToolStripMenuItem newScheduledTaskToolStripMenuItem;
        private System.Windows.Forms.ImageList imageListScheduledTasks;
        private BrightIdeasSoftware.OLVColumn olvColumnTaskEnabled;
        private System.Windows.Forms.ContextMenuStrip scheduledTasksMenu;
        private System.Windows.Forms.ToolStripMenuItem taskRunNowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taskPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem taskDeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taskDisableToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip tabMenu;
        private System.Windows.Forms.ToolStripMenuItem closeAllButThisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sequenceCloneToolStripMenuItem;
    }
}

