namespace UBoat.WebHawk.UI
{
    partial class SequenceRecorder
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SequenceRecorder));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnSelectSetElement = new System.Windows.Forms.Button();
            this.btnSelectGetElement = new System.Windows.Forms.Button();
            this.gbSequence = new System.Windows.Forms.GroupBox();
            this.btnAddStep = new System.Windows.Forms.Button();
            this.cbAvailableStepList = new System.Windows.Forms.ComboBox();
            this.btnGroupSteps = new System.Windows.Forms.Button();
            this.tlvSequence = new BrightIdeasSoftware.TreeListView();
            this.olvColumnOrder = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnIsIteration = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnHasCondition = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnEdit = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnDelete = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnExecute = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageListSequence = new System.Windows.Forms.ImageList(this.components);
            this.pbRecordingStatus = new System.Windows.Forms.PictureBox();
            this.btnToggleRecording = new System.Windows.Forms.Button();
            this.lblRecordingStatus = new System.Windows.Forms.Label();
            this.gbVariables = new System.Windows.Forms.GroupBox();
            this.cbRefreshVariablesInRealTime = new System.Windows.Forms.CheckBox();
            this.btnRefreshVariables = new System.Windows.Forms.Button();
            this.tlvVariables = new BrightIdeasSoftware.TreeListView();
            this.olvColumnVariableName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnVariableValue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.wbRecorder = new System.Windows.Forms.WebBrowser();
            this.stepsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stepEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepGoToThisStepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.stepCutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepCopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepPasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepRemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.gbSequence.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvSequence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRecordingStatus)).BeginInit();
            this.gbVariables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvVariables)).BeginInit();
            this.stepsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.wbRecorder);
            this.splitContainer1.Size = new System.Drawing.Size(1058, 583);
            this.splitContainer1.SplitterDistance = 354;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnSelectSetElement);
            this.splitContainer2.Panel1.Controls.Add(this.btnSelectGetElement);
            this.splitContainer2.Panel1.Controls.Add(this.gbSequence);
            this.splitContainer2.Panel1.Controls.Add(this.pbRecordingStatus);
            this.splitContainer2.Panel1.Controls.Add(this.btnToggleRecording);
            this.splitContainer2.Panel1.Controls.Add(this.lblRecordingStatus);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gbVariables);
            this.splitContainer2.Size = new System.Drawing.Size(354, 583);
            this.splitContainer2.SplitterDistance = 370;
            this.splitContainer2.TabIndex = 7;
            // 
            // btnSelectSetElement
            // 
            this.btnSelectSetElement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectSetElement.BackgroundImage = global::UBoat.WebHawk.UI.Properties.Resources.SetValueIcon;
            this.btnSelectSetElement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSelectSetElement.Enabled = false;
            this.btnSelectSetElement.Location = new System.Drawing.Point(315, 3);
            this.btnSelectSetElement.Name = "btnSelectSetElement";
            this.btnSelectSetElement.Size = new System.Drawing.Size(31, 32);
            this.btnSelectSetElement.TabIndex = 8;
            this.btnSelectSetElement.UseVisualStyleBackColor = true;
            this.btnSelectSetElement.Click += new System.EventHandler(this.btnSelectSetElement_Click);
            // 
            // btnSelectGetElement
            // 
            this.btnSelectGetElement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectGetElement.BackgroundImage = global::UBoat.WebHawk.UI.Properties.Resources.GetValueIcon;
            this.btnSelectGetElement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSelectGetElement.Enabled = false;
            this.btnSelectGetElement.Location = new System.Drawing.Point(278, 3);
            this.btnSelectGetElement.Name = "btnSelectGetElement";
            this.btnSelectGetElement.Size = new System.Drawing.Size(31, 32);
            this.btnSelectGetElement.TabIndex = 7;
            this.btnSelectGetElement.UseVisualStyleBackColor = true;
            this.btnSelectGetElement.Click += new System.EventHandler(this.btnSelectGetElement_Click);
            // 
            // gbSequence
            // 
            this.gbSequence.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSequence.Controls.Add(this.btnAddStep);
            this.gbSequence.Controls.Add(this.cbAvailableStepList);
            this.gbSequence.Controls.Add(this.btnGroupSteps);
            this.gbSequence.Controls.Add(this.tlvSequence);
            this.gbSequence.Location = new System.Drawing.Point(3, 41);
            this.gbSequence.Name = "gbSequence";
            this.gbSequence.Size = new System.Drawing.Size(346, 324);
            this.gbSequence.TabIndex = 6;
            this.gbSequence.TabStop = false;
            this.gbSequence.Text = "Sequence";
            // 
            // btnAddStep
            // 
            this.btnAddStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddStep.BackgroundImage = global::UBoat.WebHawk.UI.Properties.Resources.Add;
            this.btnAddStep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddStep.Location = new System.Drawing.Point(213, 286);
            this.btnAddStep.Name = "btnAddStep";
            this.btnAddStep.Size = new System.Drawing.Size(31, 32);
            this.btnAddStep.TabIndex = 10;
            this.btnAddStep.UseVisualStyleBackColor = true;
            this.btnAddStep.Click += new System.EventHandler(this.btnAddStep_Click);
            // 
            // cbAvailableStepList
            // 
            this.cbAvailableStepList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbAvailableStepList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAvailableStepList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAvailableStepList.FormattingEnabled = true;
            this.cbAvailableStepList.Location = new System.Drawing.Point(3, 288);
            this.cbAvailableStepList.Name = "cbAvailableStepList";
            this.cbAvailableStepList.Size = new System.Drawing.Size(204, 28);
            this.cbAvailableStepList.TabIndex = 9;
            // 
            // btnGroupSteps
            // 
            this.btnGroupSteps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGroupSteps.BackgroundImage = global::UBoat.WebHawk.UI.Properties.Resources.Group;
            this.btnGroupSteps.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGroupSteps.Enabled = false;
            this.btnGroupSteps.Location = new System.Drawing.Point(312, 286);
            this.btnGroupSteps.Name = "btnGroupSteps";
            this.btnGroupSteps.Size = new System.Drawing.Size(31, 32);
            this.btnGroupSteps.TabIndex = 8;
            this.btnGroupSteps.UseVisualStyleBackColor = true;
            this.btnGroupSteps.Click += new System.EventHandler(this.btnGroupSteps_Click);
            // 
            // tlvSequence
            // 
            this.tlvSequence.AllColumns.Add(this.olvColumnOrder);
            this.tlvSequence.AllColumns.Add(this.olvColumnIsIteration);
            this.tlvSequence.AllColumns.Add(this.olvColumnHasCondition);
            this.tlvSequence.AllColumns.Add(this.olvColumnEdit);
            this.tlvSequence.AllColumns.Add(this.olvColumnDelete);
            this.tlvSequence.AllColumns.Add(this.olvColumnExecute);
            this.tlvSequence.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlvSequence.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnOrder,
            this.olvColumnIsIteration,
            this.olvColumnHasCondition,
            this.olvColumnEdit,
            this.olvColumnDelete,
            this.olvColumnExecute});
            this.tlvSequence.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlvSequence.FullRowSelect = true;
            this.tlvSequence.IsSimpleDragSource = true;
            this.tlvSequence.IsSimpleDropSink = true;
            this.tlvSequence.Location = new System.Drawing.Point(3, 19);
            this.tlvSequence.Name = "tlvSequence";
            this.tlvSequence.OwnerDraw = true;
            this.tlvSequence.ShowGroups = false;
            this.tlvSequence.Size = new System.Drawing.Size(340, 261);
            this.tlvSequence.SmallImageList = this.imageListSequence;
            this.tlvSequence.TabIndex = 0;
            this.tlvSequence.UseCompatibleStateImageBehavior = false;
            this.tlvSequence.UseHotItem = true;
            this.tlvSequence.UseHyperlinks = true;
            this.tlvSequence.View = System.Windows.Forms.View.Details;
            this.tlvSequence.VirtualMode = true;
            this.tlvSequence.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.tlvSequence_CellClick);
            this.tlvSequence.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.tlvSequence_CellRightClick);
            this.tlvSequence.HyperlinkClicked += new System.EventHandler<BrightIdeasSoftware.HyperlinkClickedEventArgs>(this.tlvSequence_HyperlinkClicked);
            this.tlvSequence.ModelCanDrop += new System.EventHandler<BrightIdeasSoftware.ModelDropEventArgs>(this.tlvSequence_ModelCanDrop);
            this.tlvSequence.ModelDropped += new System.EventHandler<BrightIdeasSoftware.ModelDropEventArgs>(this.tlvSequence_ModelDropped);
            this.tlvSequence.SelectionChanged += new System.EventHandler(this.tlvSequence_SelectionChanged);
            this.tlvSequence.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tlvSequence_KeyUp);
            // 
            // olvColumnOrder
            // 
            this.olvColumnOrder.MinimumWidth = 80;
            this.olvColumnOrder.Searchable = false;
            this.olvColumnOrder.Sortable = false;
            this.olvColumnOrder.Text = "Step";
            this.olvColumnOrder.UseFiltering = false;
            this.olvColumnOrder.Width = 178;
            // 
            // olvColumnIsIteration
            // 
            this.olvColumnIsIteration.MaximumWidth = 20;
            this.olvColumnIsIteration.MinimumWidth = 20;
            this.olvColumnIsIteration.Searchable = false;
            this.olvColumnIsIteration.Sortable = false;
            this.olvColumnIsIteration.Text = "";
            this.olvColumnIsIteration.UseFiltering = false;
            this.olvColumnIsIteration.Width = 20;
            // 
            // olvColumnHasCondition
            // 
            this.olvColumnHasCondition.MaximumWidth = 20;
            this.olvColumnHasCondition.MinimumWidth = 20;
            this.olvColumnHasCondition.Searchable = false;
            this.olvColumnHasCondition.Sortable = false;
            this.olvColumnHasCondition.Text = "";
            this.olvColumnHasCondition.UseFiltering = false;
            this.olvColumnHasCondition.Width = 20;
            // 
            // olvColumnEdit
            // 
            this.olvColumnEdit.Hyperlink = true;
            this.olvColumnEdit.MaximumWidth = 35;
            this.olvColumnEdit.MinimumWidth = 35;
            this.olvColumnEdit.Searchable = false;
            this.olvColumnEdit.Sortable = false;
            this.olvColumnEdit.Text = "";
            this.olvColumnEdit.UseFiltering = false;
            this.olvColumnEdit.Width = 35;
            // 
            // olvColumnDelete
            // 
            this.olvColumnDelete.Hyperlink = true;
            this.olvColumnDelete.MaximumWidth = 50;
            this.olvColumnDelete.MinimumWidth = 50;
            this.olvColumnDelete.Searchable = false;
            this.olvColumnDelete.Sortable = false;
            this.olvColumnDelete.Text = "";
            this.olvColumnDelete.UseFiltering = false;
            this.olvColumnDelete.Width = 50;
            // 
            // olvColumnExecute
            // 
            this.olvColumnExecute.Hyperlink = true;
            this.olvColumnExecute.MaximumWidth = 30;
            this.olvColumnExecute.MinimumWidth = 30;
            this.olvColumnExecute.Searchable = false;
            this.olvColumnExecute.Sortable = false;
            this.olvColumnExecute.Text = "";
            this.olvColumnExecute.UseFiltering = false;
            this.olvColumnExecute.Width = 30;
            // 
            // imageListSequence
            // 
            this.imageListSequence.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListSequence.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListSequence.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pbRecordingStatus
            // 
            this.pbRecordingStatus.Image = global::UBoat.WebHawk.UI.Properties.Resources.RedCircle;
            this.pbRecordingStatus.Location = new System.Drawing.Point(6, 3);
            this.pbRecordingStatus.Name = "pbRecordingStatus";
            this.pbRecordingStatus.Size = new System.Drawing.Size(31, 31);
            this.pbRecordingStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRecordingStatus.TabIndex = 3;
            this.pbRecordingStatus.TabStop = false;
            // 
            // btnToggleRecording
            // 
            this.btnToggleRecording.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToggleRecording.BackgroundImage = global::UBoat.WebHawk.UI.Properties.Resources.PlayIcon;
            this.btnToggleRecording.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnToggleRecording.Enabled = false;
            this.btnToggleRecording.Location = new System.Drawing.Point(241, 3);
            this.btnToggleRecording.Name = "btnToggleRecording";
            this.btnToggleRecording.Size = new System.Drawing.Size(31, 32);
            this.btnToggleRecording.TabIndex = 4;
            this.btnToggleRecording.UseVisualStyleBackColor = true;
            this.btnToggleRecording.Click += new System.EventHandler(this.btnToggleRecording_Click);
            // 
            // lblRecordingStatus
            // 
            this.lblRecordingStatus.AutoSize = true;
            this.lblRecordingStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordingStatus.Location = new System.Drawing.Point(43, 10);
            this.lblRecordingStatus.Name = "lblRecordingStatus";
            this.lblRecordingStatus.Size = new System.Drawing.Size(108, 16);
            this.lblRecordingStatus.TabIndex = 2;
            this.lblRecordingStatus.Text = "Not Recording";
            // 
            // gbVariables
            // 
            this.gbVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbVariables.Controls.Add(this.cbRefreshVariablesInRealTime);
            this.gbVariables.Controls.Add(this.btnRefreshVariables);
            this.gbVariables.Controls.Add(this.tlvVariables);
            this.gbVariables.Location = new System.Drawing.Point(3, 3);
            this.gbVariables.Name = "gbVariables";
            this.gbVariables.Size = new System.Drawing.Size(346, 201);
            this.gbVariables.TabIndex = 7;
            this.gbVariables.TabStop = false;
            this.gbVariables.Text = "Variables";
            // 
            // cbRefreshVariablesInRealTime
            // 
            this.cbRefreshVariablesInRealTime.AutoSize = true;
            this.cbRefreshVariablesInRealTime.Checked = true;
            this.cbRefreshVariablesInRealTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRefreshVariablesInRealTime.Location = new System.Drawing.Point(6, 19);
            this.cbRefreshVariablesInRealTime.Name = "cbRefreshVariablesInRealTime";
            this.cbRefreshVariablesInRealTime.Size = new System.Drawing.Size(139, 17);
            this.cbRefreshVariablesInRealTime.TabIndex = 12;
            this.cbRefreshVariablesInRealTime.Text = "Update view in real time";
            this.cbRefreshVariablesInRealTime.UseVisualStyleBackColor = true;
            // 
            // btnRefreshVariables
            // 
            this.btnRefreshVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshVariables.BackgroundImage = global::UBoat.WebHawk.UI.Properties.Resources.refresh_icon;
            this.btnRefreshVariables.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefreshVariables.Location = new System.Drawing.Point(312, 10);
            this.btnRefreshVariables.Name = "btnRefreshVariables";
            this.btnRefreshVariables.Size = new System.Drawing.Size(31, 32);
            this.btnRefreshVariables.TabIndex = 11;
            this.btnRefreshVariables.UseVisualStyleBackColor = true;
            this.btnRefreshVariables.Click += new System.EventHandler(this.btnRefreshVariables_Click);
            // 
            // tlvVariables
            // 
            this.tlvVariables.AllColumns.Add(this.olvColumnVariableName);
            this.tlvVariables.AllColumns.Add(this.olvColumnVariableValue);
            this.tlvVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlvVariables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnVariableName,
            this.olvColumnVariableValue});
            this.tlvVariables.FullRowSelect = true;
            this.tlvVariables.Location = new System.Drawing.Point(3, 48);
            this.tlvVariables.Name = "tlvVariables";
            this.tlvVariables.OwnerDraw = true;
            this.tlvVariables.ShowGroups = false;
            this.tlvVariables.Size = new System.Drawing.Size(340, 150);
            this.tlvVariables.TabIndex = 5;
            this.tlvVariables.UseCompatibleStateImageBehavior = false;
            this.tlvVariables.View = System.Windows.Forms.View.Details;
            this.tlvVariables.VirtualMode = true;
            this.tlvVariables.SelectionChanged += new System.EventHandler(this.tlvVariables_SelectionChanged);
            // 
            // olvColumnVariableName
            // 
            this.olvColumnVariableName.AspectName = "Name";
            this.olvColumnVariableName.FillsFreeSpace = true;
            this.olvColumnVariableName.MinimumWidth = 150;
            this.olvColumnVariableName.Text = "Name";
            this.olvColumnVariableName.Width = 150;
            // 
            // olvColumnVariableValue
            // 
            this.olvColumnVariableValue.FillsFreeSpace = true;
            this.olvColumnVariableValue.MinimumWidth = 150;
            this.olvColumnVariableValue.Text = "Value";
            this.olvColumnVariableValue.Width = 150;
            // 
            // wbRecorder
            // 
            this.wbRecorder.AllowWebBrowserDrop = false;
            this.wbRecorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbRecorder.IsWebBrowserContextMenuEnabled = false;
            this.wbRecorder.Location = new System.Drawing.Point(0, 0);
            this.wbRecorder.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbRecorder.Name = "wbRecorder";
            this.wbRecorder.ScriptErrorsSuppressed = true;
            this.wbRecorder.Size = new System.Drawing.Size(698, 581);
            this.wbRecorder.TabIndex = 0;
            // 
            // stepsMenu
            // 
            this.stepsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stepEditToolStripMenuItem,
            this.stepGoToThisStepToolStripMenuItem,
            this.toolStripSeparator1,
            this.stepCutToolStripMenuItem,
            this.stepCopyToolStripMenuItem,
            this.stepPasteToolStripMenuItem,
            this.stepRemoveToolStripMenuItem});
            this.stepsMenu.Name = "stepsMenu";
            this.stepsMenu.Size = new System.Drawing.Size(160, 164);
            // 
            // stepEditToolStripMenuItem
            // 
            this.stepEditToolStripMenuItem.Image = global::UBoat.WebHawk.UI.Properties.Resources.Edit2;
            this.stepEditToolStripMenuItem.Name = "stepEditToolStripMenuItem";
            this.stepEditToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.stepEditToolStripMenuItem.Text = "Edit...";
            this.stepEditToolStripMenuItem.Click += new System.EventHandler(this.stepEditToolStripMenuItem_Click);
            // 
            // stepGoToThisStepToolStripMenuItem
            // 
            this.stepGoToThisStepToolStripMenuItem.Image = global::UBoat.WebHawk.UI.Properties.Resources.GreenArrow;
            this.stepGoToThisStepToolStripMenuItem.Name = "stepGoToThisStepToolStripMenuItem";
            this.stepGoToThisStepToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.stepGoToThisStepToolStripMenuItem.Text = "Go to this step...";
            this.stepGoToThisStepToolStripMenuItem.Click += new System.EventHandler(this.stepGoToThisStepToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(156, 6);
            // 
            // stepCutToolStripMenuItem
            // 
            this.stepCutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("stepCutToolStripMenuItem.Image")));
            this.stepCutToolStripMenuItem.Name = "stepCutToolStripMenuItem";
            this.stepCutToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.stepCutToolStripMenuItem.Text = "Cut";
            this.stepCutToolStripMenuItem.Click += new System.EventHandler(this.stepCutToolStripMenuItem_Click);
            // 
            // stepCopyToolStripMenuItem
            // 
            this.stepCopyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("stepCopyToolStripMenuItem.Image")));
            this.stepCopyToolStripMenuItem.Name = "stepCopyToolStripMenuItem";
            this.stepCopyToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.stepCopyToolStripMenuItem.Text = "Copy";
            this.stepCopyToolStripMenuItem.Click += new System.EventHandler(this.stepCopyToolStripMenuItem_Click);
            // 
            // stepPasteToolStripMenuItem
            // 
            this.stepPasteToolStripMenuItem.Enabled = false;
            this.stepPasteToolStripMenuItem.Image = global::UBoat.WebHawk.UI.Properties.Resources.PasteIcon;
            this.stepPasteToolStripMenuItem.Name = "stepPasteToolStripMenuItem";
            this.stepPasteToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.stepPasteToolStripMenuItem.Text = "Paste";
            this.stepPasteToolStripMenuItem.Click += new System.EventHandler(this.stepPasteToolStripMenuItem_Click);
            // 
            // stepRemoveToolStripMenuItem
            // 
            this.stepRemoveToolStripMenuItem.Image = global::UBoat.WebHawk.UI.Properties.Resources.Delete;
            this.stepRemoveToolStripMenuItem.Name = "stepRemoveToolStripMenuItem";
            this.stepRemoveToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.stepRemoveToolStripMenuItem.Text = "Remove";
            this.stepRemoveToolStripMenuItem.Click += new System.EventHandler(this.stepRemoveToolStripMenuItem_Click);
            // 
            // SequenceRecorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "SequenceRecorder";
            this.Size = new System.Drawing.Size(1058, 583);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.gbSequence.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlvSequence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRecordingStatus)).EndInit();
            this.gbVariables.ResumeLayout(false);
            this.gbVariables.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvVariables)).EndInit();
            this.stepsMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.WebBrowser wbRecorder;
        private System.Windows.Forms.Button btnToggleRecording;
        private System.Windows.Forms.PictureBox pbRecordingStatus;
        private System.Windows.Forms.Label lblRecordingStatus;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox gbSequence;
        private System.Windows.Forms.GroupBox gbVariables;
        private BrightIdeasSoftware.TreeListView tlvVariables;
        private System.Windows.Forms.Button btnSelectGetElement;
        private BrightIdeasSoftware.TreeListView tlvSequence;
        private BrightIdeasSoftware.OLVColumn olvColumnOrder;
        private System.Windows.Forms.ImageList imageListSequence;
        private BrightIdeasSoftware.OLVColumn olvColumnVariableName;
        private BrightIdeasSoftware.OLVColumn olvColumnVariableValue;
        private BrightIdeasSoftware.OLVColumn olvColumnEdit;
        private BrightIdeasSoftware.OLVColumn olvColumnHasCondition;
        private System.Windows.Forms.Button btnGroupSteps;
        private BrightIdeasSoftware.OLVColumn olvColumnDelete;
        private BrightIdeasSoftware.OLVColumn olvColumnExecute;
        private BrightIdeasSoftware.OLVColumn olvColumnIsIteration;
        private System.Windows.Forms.Button btnAddStep;
        private System.Windows.Forms.ComboBox cbAvailableStepList;
        private System.Windows.Forms.Button btnSelectSetElement;
        private System.Windows.Forms.Button btnRefreshVariables;
        private System.Windows.Forms.CheckBox cbRefreshVariablesInRealTime;
        private System.Windows.Forms.ContextMenuStrip stepsMenu;
        private System.Windows.Forms.ToolStripMenuItem stepEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepCutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepCopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepPasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepGoToThisStepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepRemoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}
