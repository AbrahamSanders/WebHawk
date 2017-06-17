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
            this.btnAddNotification = new System.Windows.Forms.Button();
            this.olvNotifications = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnAddress = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
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
            this.gbNotifications.Controls.Add(this.btnAddNotification);
            this.gbNotifications.Controls.Add(this.olvNotifications);
            this.gbNotifications.Location = new System.Drawing.Point(3, 3);
            this.gbNotifications.Name = "gbNotifications";
            this.gbNotifications.Size = new System.Drawing.Size(622, 213);
            this.gbNotifications.TabIndex = 0;
            this.gbNotifications.TabStop = false;
            this.gbNotifications.Text = "Notification Targets";
            // 
            // btnAddNotification
            // 
            this.btnAddNotification.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNotification.BackgroundImage = global::UBoat.WebHawk.UI.Properties.Resources.Add;
            this.btnAddNotification.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddNotification.Location = new System.Drawing.Point(585, 175);
            this.btnAddNotification.Name = "btnAddNotification";
            this.btnAddNotification.Size = new System.Drawing.Size(31, 32);
            this.btnAddNotification.TabIndex = 1;
            this.btnAddNotification.UseVisualStyleBackColor = true;
            this.btnAddNotification.Click += new System.EventHandler(this.btnAddNotification_Click);
            // 
            // olvNotifications
            // 
            this.olvNotifications.AllColumns.Add(this.olvColumnType);
            this.olvNotifications.AllColumns.Add(this.olvColumnAddress);
            this.olvNotifications.AllColumns.Add(this.olvColumnDelete);
            this.olvNotifications.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvNotifications.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.olvNotifications.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnType,
            this.olvColumnAddress,
            this.olvColumnDelete});
            this.olvNotifications.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvNotifications.EmptyListMsg = "No notification targets have been specified.";
            this.olvNotifications.EmptyListMsgFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvNotifications.FullRowSelect = true;
            this.olvNotifications.Location = new System.Drawing.Point(6, 19);
            this.olvNotifications.Name = "olvNotifications";
            this.olvNotifications.ShowGroups = false;
            this.olvNotifications.Size = new System.Drawing.Size(610, 150);
            this.olvNotifications.TabIndex = 0;
            this.olvNotifications.UseCompatibleStateImageBehavior = false;
            this.olvNotifications.UseHyperlinks = true;
            this.olvNotifications.View = System.Windows.Forms.View.Details;
            this.olvNotifications.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.olvNotifications_CellEditFinishing);
            this.olvNotifications.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.olvNotifications_CellEditStarting);
            this.olvNotifications.HyperlinkClicked += new System.EventHandler<BrightIdeasSoftware.HyperlinkClickedEventArgs>(this.olvNotifications_HyperlinkClicked);
            // 
            // olvColumnType
            // 
            this.olvColumnType.AspectName = "NotificationType";
            this.olvColumnType.Groupable = false;
            this.olvColumnType.Searchable = false;
            this.olvColumnType.Sortable = false;
            this.olvColumnType.Text = "Type";
            this.olvColumnType.UseFiltering = false;
            // 
            // olvColumnAddress
            // 
            this.olvColumnAddress.AspectName = "Address";
            this.olvColumnAddress.FillsFreeSpace = true;
            this.olvColumnAddress.Groupable = false;
            this.olvColumnAddress.Searchable = false;
            this.olvColumnAddress.Sortable = false;
            this.olvColumnAddress.Text = "Address";
            this.olvColumnAddress.UseFiltering = false;
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
            this.gbMessage.Location = new System.Drawing.Point(3, 222);
            this.gbMessage.Name = "gbMessage";
            this.gbMessage.Size = new System.Drawing.Size(622, 181);
            this.gbMessage.TabIndex = 1;
            this.gbMessage.TabStop = false;
            this.gbMessage.Text = "Message";
            // 
            // messageEditor
            // 
            this.messageEditor.Location = new System.Drawing.Point(6, 19);
            this.messageEditor.Name = "messageEditor";
            this.messageEditor.Size = new System.Drawing.Size(610, 156);
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
            this.Size = new System.Drawing.Size(642, 406);
            this.gbNotifications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvNotifications)).EndInit();
            this.gbMessage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbNotifications;
        private BrightIdeasSoftware.ObjectListView olvNotifications;
        private System.Windows.Forms.Button btnAddNotification;
        private System.Windows.Forms.GroupBox gbMessage;
        private BrightIdeasSoftware.OLVColumn olvColumnType;
        private BrightIdeasSoftware.OLVColumn olvColumnAddress;
        private BrightIdeasSoftware.OLVColumn olvColumnDelete;
        private OutputValueEditor messageEditor;
    }
}
