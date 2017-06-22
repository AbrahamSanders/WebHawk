namespace UBoat.WebHawk.UI.StepEditors
{
    partial class NotifyStepEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbNotifications = new System.Windows.Forms.GroupBox();
            this.gbNotificationEditor = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbNotificationType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddSaveNotification = new System.Windows.Forms.Button();
            this.olvNotifications = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnTarget = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnDelete = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.gbMessage = new System.Windows.Forms.GroupBox();
            this.messageEditor = new UBoat.WebHawk.UI.StepEditors.OutputValueEditor();
            this.gbNotifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvNotifications)).BeginInit();
            this.gbMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbNotifications
            // 
            this.gbNotifications.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbNotifications.Controls.Add(this.gbNotificationEditor);
            this.gbNotifications.Controls.Add(this.label2);
            this.gbNotifications.Controls.Add(this.cbNotificationType);
            this.gbNotifications.Controls.Add(this.label1);
            this.gbNotifications.Controls.Add(this.btnAddSaveNotification);
            this.gbNotifications.Controls.Add(this.olvNotifications);
            this.gbNotifications.Location = new System.Drawing.Point(3, 3);
            this.gbNotifications.Name = "gbNotifications";
            this.gbNotifications.Size = new System.Drawing.Size(622, 347);
            this.gbNotifications.TabIndex = 0;
            this.gbNotifications.TabStop = false;
            this.gbNotifications.Text = "Notification Targets";
            // 
            // gbNotificationEditor
            // 
            this.gbNotificationEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbNotificationEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbNotificationEditor.Location = new System.Drawing.Point(6, 163);
            this.gbNotificationEditor.Name = "gbNotificationEditor";
            this.gbNotificationEditor.Size = new System.Drawing.Size(610, 178);
            this.gbNotificationEditor.TabIndex = 5;
            this.gbNotificationEditor.TabStop = false;
            this.gbNotificationEditor.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Type:";
            // 
            // cbNotificationType
            // 
            this.cbNotificationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNotificationType.FormattingEnabled = true;
            this.cbNotificationType.Location = new System.Drawing.Point(46, 135);
            this.cbNotificationType.Name = "cbNotificationType";
            this.cbNotificationType.Size = new System.Drawing.Size(158, 21);
            this.cbNotificationType.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Add Notification Target";
            // 
            // btnAddSaveNotification
            // 
            this.btnAddSaveNotification.BackgroundImage = global::UBoat.WebHawk.UI.Properties.Resources.Add;
            this.btnAddSaveNotification.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddSaveNotification.Location = new System.Drawing.Point(210, 132);
            this.btnAddSaveNotification.Name = "btnAddSaveNotification";
            this.btnAddSaveNotification.Size = new System.Drawing.Size(24, 25);
            this.btnAddSaveNotification.TabIndex = 1;
            this.btnAddSaveNotification.UseVisualStyleBackColor = true;
            this.btnAddSaveNotification.Click += new System.EventHandler(this.btnAddSaveNotification_Click);
            // 
            // olvNotifications
            // 
            this.olvNotifications.AllColumns.Add(this.olvColumnTarget);
            this.olvNotifications.AllColumns.Add(this.olvColumnDelete);
            this.olvNotifications.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvNotifications.CellEditUseWholeCell = false;
            this.olvNotifications.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnTarget,
            this.olvColumnDelete});
            this.olvNotifications.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvNotifications.EmptyListMsg = "No notification targets have been specified.";
            this.olvNotifications.EmptyListMsgFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvNotifications.FullRowSelect = true;
            this.olvNotifications.Location = new System.Drawing.Point(6, 19);
            this.olvNotifications.Name = "olvNotifications";
            this.olvNotifications.ShowGroups = false;
            this.olvNotifications.Size = new System.Drawing.Size(610, 97);
            this.olvNotifications.TabIndex = 0;
            this.olvNotifications.UseCompatibleStateImageBehavior = false;
            this.olvNotifications.UseHotItem = true;
            this.olvNotifications.UseHyperlinks = true;
            this.olvNotifications.View = System.Windows.Forms.View.Details;
            this.olvNotifications.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.olvNotifications_CellClick);
            this.olvNotifications.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.olvNotifications_FormatRow);
            this.olvNotifications.HyperlinkClicked += new System.EventHandler<BrightIdeasSoftware.HyperlinkClickedEventArgs>(this.olvNotifications_HyperlinkClicked);
            // 
            // olvColumnTarget
            // 
            this.olvColumnTarget.AspectName = "";
            this.olvColumnTarget.FillsFreeSpace = true;
            this.olvColumnTarget.Groupable = false;
            this.olvColumnTarget.Searchable = false;
            this.olvColumnTarget.Sortable = false;
            this.olvColumnTarget.Text = "Notification Target";
            this.olvColumnTarget.UseFiltering = false;
            // 
            // olvColumnDelete
            // 
            this.olvColumnDelete.Groupable = false;
            this.olvColumnDelete.Hyperlink = true;
            this.olvColumnDelete.IsEditable = false;
            this.olvColumnDelete.Searchable = false;
            this.olvColumnDelete.Sortable = false;
            this.olvColumnDelete.Text = "";
            this.olvColumnDelete.UseFiltering = false;
            // 
            // gbMessage
            // 
            this.gbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMessage.Controls.Add(this.messageEditor);
            this.gbMessage.Location = new System.Drawing.Point(3, 350);
            this.gbMessage.Name = "gbMessage";
            this.gbMessage.Size = new System.Drawing.Size(622, 141);
            this.gbMessage.TabIndex = 1;
            this.gbMessage.TabStop = false;
            this.gbMessage.Text = "Message";
            // 
            // messageEditor
            // 
            this.messageEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageEditor.Location = new System.Drawing.Point(6, 19);
            this.messageEditor.Name = "messageEditor";
            this.messageEditor.Size = new System.Drawing.Size(610, 114);
            this.messageEditor.TabIndex = 0;
            this.messageEditor.TrimVariableValueWhitespace = false;
            this.messageEditor.Value = "Your notification message here...";
            // 
            // NotifyStepEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbMessage);
            this.Controls.Add(this.gbNotifications);
            this.Name = "NotifyStepEditor";
            this.Size = new System.Drawing.Size(642, 495);
            this.gbNotifications.ResumeLayout(false);
            this.gbNotifications.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvNotifications)).EndInit();
            this.gbMessage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbNotifications;
        private BrightIdeasSoftware.ObjectListView olvNotifications;
        private System.Windows.Forms.Button btnAddSaveNotification;
        private System.Windows.Forms.GroupBox gbMessage;
        private BrightIdeasSoftware.OLVColumn olvColumnTarget;
        private BrightIdeasSoftware.OLVColumn olvColumnDelete;
        private OutputValueEditor messageEditor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbNotificationType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbNotificationEditor;
    }
}
