namespace UBoat.WebHawk.UI
{
    partial class frmScheduledTaskProperties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScheduledTaskProperties));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbMissedScheduleModeNextScheduledTime = new System.Windows.Forms.RadioButton();
            this.rbMissedScheduleModeRunImmediately = new System.Windows.Forms.RadioButton();
            this.ipMaxDuration = new UBoat.Utils.Controls.IntervalPicker();
            this.cbTaskEnabled = new System.Windows.Forms.CheckBox();
            this.dtpTaskEndTime = new UBoat.Utils.Controls.DateTimePickerEx();
            this.cbTaskExpires = new System.Windows.Forms.CheckBox();
            this.cbLimitTaskRunTime = new System.Windows.Forms.CheckBox();
            this.dtpTaskStartTime = new UBoat.Utils.Controls.DateTimePickerEx();
            this.gbScheduler = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTaskSequence = new System.Windows.Forms.ComboBox();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.scheduleTypePanel = new System.Windows.Forms.Panel();
            this.rbOneTime = new System.Windows.Forms.RadioButton();
            this.rbDaily = new System.Windows.Forms.RadioButton();
            this.rbWeekly = new System.Windows.Forms.RadioButton();
            this.rbMonthly = new System.Windows.Forms.RadioButton();
            this.rbHourly = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbMissedScheduleMode = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.scheduleTypePanel.SuspendLayout();
            this.gbMissedScheduleMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.gbMissedScheduleMode);
            this.groupBox1.Controls.Add(this.ipMaxDuration);
            this.groupBox1.Controls.Add(this.cbTaskEnabled);
            this.groupBox1.Controls.Add(this.dtpTaskEndTime);
            this.groupBox1.Controls.Add(this.cbTaskExpires);
            this.groupBox1.Controls.Add(this.cbLimitTaskRunTime);
            this.groupBox1.Controls.Add(this.dtpTaskStartTime);
            this.groupBox1.Controls.Add(this.gbScheduler);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbTaskSequence);
            this.groupBox1.Controls.Add(this.txtTaskName);
            this.groupBox1.Controls.Add(this.scheduleTypePanel);
            this.groupBox1.Location = new System.Drawing.Point(128, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(476, 421);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create New Scheduled Task";
            // 
            // rbMissedScheduleModeNextScheduledTime
            // 
            this.rbMissedScheduleModeNextScheduledTime.AutoSize = true;
            this.rbMissedScheduleModeNextScheduledTime.Location = new System.Drawing.Point(6, 17);
            this.rbMissedScheduleModeNextScheduledTime.Name = "rbMissedScheduleModeNextScheduledTime";
            this.rbMissedScheduleModeNextScheduledTime.Size = new System.Drawing.Size(211, 20);
            this.rbMissedScheduleModeNextScheduledTime.TabIndex = 1;
            this.rbMissedScheduleModeNextScheduledTime.TabStop = true;
            this.rbMissedScheduleModeNextScheduledTime.Text = "Run at next scheduled time";
            this.rbMissedScheduleModeNextScheduledTime.UseVisualStyleBackColor = true;
            // 
            // rbMissedScheduleModeRunImmediately
            // 
            this.rbMissedScheduleModeRunImmediately.AutoSize = true;
            this.rbMissedScheduleModeRunImmediately.Location = new System.Drawing.Point(223, 17);
            this.rbMissedScheduleModeRunImmediately.Name = "rbMissedScheduleModeRunImmediately";
            this.rbMissedScheduleModeRunImmediately.Size = new System.Drawing.Size(141, 20);
            this.rbMissedScheduleModeRunImmediately.TabIndex = 0;
            this.rbMissedScheduleModeRunImmediately.TabStop = true;
            this.rbMissedScheduleModeRunImmediately.Text = "Run Immediately";
            this.rbMissedScheduleModeRunImmediately.UseVisualStyleBackColor = true;
            // 
            // ipMaxDuration
            // 
            this.ipMaxDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ipMaxDuration.AutoSize = true;
            this.ipMaxDuration.Location = new System.Drawing.Point(136, 284);
            this.ipMaxDuration.Margin = new System.Windows.Forms.Padding(4);
            this.ipMaxDuration.Name = "ipMaxDuration";
            this.ipMaxDuration.ShowMilliseconds = false;
            this.ipMaxDuration.Size = new System.Drawing.Size(307, 28);
            this.ipMaxDuration.TabIndex = 19;
            // 
            // cbTaskEnabled
            // 
            this.cbTaskEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbTaskEnabled.AutoSize = true;
            this.cbTaskEnabled.Location = new System.Drawing.Point(9, 338);
            this.cbTaskEnabled.Name = "cbTaskEnabled";
            this.cbTaskEnabled.Size = new System.Drawing.Size(85, 20);
            this.cbTaskEnabled.TabIndex = 18;
            this.cbTaskEnabled.Text = "Enabled";
            this.cbTaskEnabled.UseVisualStyleBackColor = true;
            // 
            // dtpTaskEndTime
            // 
            this.dtpTaskEndTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpTaskEndTime.Location = new System.Drawing.Point(136, 307);
            this.dtpTaskEndTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpTaskEndTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpTaskEndTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTaskEndTime.Name = "dtpTaskEndTime";
            this.dtpTaskEndTime.Size = new System.Drawing.Size(308, 27);
            this.dtpTaskEndTime.TabIndex = 16;
            this.dtpTaskEndTime.Value = new System.DateTime(2014, 11, 29, 17, 3, 29, 0);
            // 
            // cbTaskExpires
            // 
            this.cbTaskExpires.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbTaskExpires.AutoSize = true;
            this.cbTaskExpires.Location = new System.Drawing.Point(9, 312);
            this.cbTaskExpires.Name = "cbTaskExpires";
            this.cbTaskExpires.Size = new System.Drawing.Size(121, 20);
            this.cbTaskExpires.TabIndex = 15;
            this.cbTaskExpires.Text = "Task expires:";
            this.cbTaskExpires.UseVisualStyleBackColor = true;
            this.cbTaskExpires.CheckedChanged += new System.EventHandler(this.cbTaskExpires_CheckedChanged);
            // 
            // cbLimitTaskRunTime
            // 
            this.cbLimitTaskRunTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbLimitTaskRunTime.AutoSize = true;
            this.cbLimitTaskRunTime.Location = new System.Drawing.Point(9, 286);
            this.cbLimitTaskRunTime.Name = "cbLimitTaskRunTime";
            this.cbLimitTaskRunTime.Size = new System.Drawing.Size(119, 20);
            this.cbLimitTaskRunTime.TabIndex = 13;
            this.cbLimitTaskRunTime.Text = "Max duration:";
            this.cbLimitTaskRunTime.UseVisualStyleBackColor = true;
            this.cbLimitTaskRunTime.CheckedChanged += new System.EventHandler(this.cbLimitTaskRunTime_CheckedChanged);
            // 
            // dtpTaskStartTime
            // 
            this.dtpTaskStartTime.Location = new System.Drawing.Point(104, 80);
            this.dtpTaskStartTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpTaskStartTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpTaskStartTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTaskStartTime.Name = "dtpTaskStartTime";
            this.dtpTaskStartTime.Size = new System.Drawing.Size(334, 27);
            this.dtpTaskStartTime.TabIndex = 12;
            this.dtpTaskStartTime.Value = new System.DateTime(2014, 11, 27, 23, 51, 0, 0);
            // 
            // gbScheduler
            // 
            this.gbScheduler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbScheduler.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbScheduler.Location = new System.Drawing.Point(104, 114);
            this.gbScheduler.Name = "gbScheduler";
            this.gbScheduler.Size = new System.Drawing.Size(366, 156);
            this.gbScheduler.TabIndex = 10;
            this.gbScheduler.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Start:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sequence:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Task Name:";
            // 
            // cbTaskSequence
            // 
            this.cbTaskSequence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTaskSequence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTaskSequence.FormattingEnabled = true;
            this.cbTaskSequence.Location = new System.Drawing.Point(104, 49);
            this.cbTaskSequence.Name = "cbTaskSequence";
            this.cbTaskSequence.Size = new System.Drawing.Size(358, 24);
            this.cbTaskSequence.TabIndex = 1;
            // 
            // txtTaskName
            // 
            this.txtTaskName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaskName.Location = new System.Drawing.Point(104, 21);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(358, 22);
            this.txtTaskName.TabIndex = 0;
            // 
            // scheduleTypePanel
            // 
            this.scheduleTypePanel.Controls.Add(this.rbOneTime);
            this.scheduleTypePanel.Controls.Add(this.rbDaily);
            this.scheduleTypePanel.Controls.Add(this.rbWeekly);
            this.scheduleTypePanel.Controls.Add(this.rbMonthly);
            this.scheduleTypePanel.Controls.Add(this.rbHourly);
            this.scheduleTypePanel.Location = new System.Drawing.Point(9, 114);
            this.scheduleTypePanel.Name = "scheduleTypePanel";
            this.scheduleTypePanel.Size = new System.Drawing.Size(89, 154);
            this.scheduleTypePanel.TabIndex = 20;
            // 
            // rbOneTime
            // 
            this.rbOneTime.AutoSize = true;
            this.rbOneTime.Location = new System.Drawing.Point(0, 12);
            this.rbOneTime.Name = "rbOneTime";
            this.rbOneTime.Size = new System.Drawing.Size(87, 20);
            this.rbOneTime.TabIndex = 6;
            this.rbOneTime.TabStop = true;
            this.rbOneTime.Text = "One time";
            this.rbOneTime.UseVisualStyleBackColor = true;
            this.rbOneTime.CheckedChanged += new System.EventHandler(this.rbOneTime_CheckedChanged);
            // 
            // rbDaily
            // 
            this.rbDaily.AutoSize = true;
            this.rbDaily.Location = new System.Drawing.Point(0, 64);
            this.rbDaily.Name = "rbDaily";
            this.rbDaily.Size = new System.Drawing.Size(62, 20);
            this.rbDaily.TabIndex = 7;
            this.rbDaily.TabStop = true;
            this.rbDaily.Text = "Daily";
            this.rbDaily.UseVisualStyleBackColor = true;
            this.rbDaily.CheckedChanged += new System.EventHandler(this.rbDaily_CheckedChanged);
            // 
            // rbWeekly
            // 
            this.rbWeekly.AutoSize = true;
            this.rbWeekly.Location = new System.Drawing.Point(0, 90);
            this.rbWeekly.Name = "rbWeekly";
            this.rbWeekly.Size = new System.Drawing.Size(78, 20);
            this.rbWeekly.TabIndex = 8;
            this.rbWeekly.TabStop = true;
            this.rbWeekly.Text = "Weekly";
            this.rbWeekly.UseVisualStyleBackColor = true;
            this.rbWeekly.CheckedChanged += new System.EventHandler(this.rbWeekly_CheckedChanged);
            // 
            // rbMonthly
            // 
            this.rbMonthly.AutoSize = true;
            this.rbMonthly.Location = new System.Drawing.Point(0, 116);
            this.rbMonthly.Name = "rbMonthly";
            this.rbMonthly.Size = new System.Drawing.Size(79, 20);
            this.rbMonthly.TabIndex = 9;
            this.rbMonthly.TabStop = true;
            this.rbMonthly.Text = "Monthly";
            this.rbMonthly.UseVisualStyleBackColor = true;
            this.rbMonthly.CheckedChanged += new System.EventHandler(this.rbMonthly_CheckedChanged);
            // 
            // rbHourly
            // 
            this.rbHourly.AutoSize = true;
            this.rbHourly.Location = new System.Drawing.Point(0, 38);
            this.rbHourly.Name = "rbHourly";
            this.rbHourly.Size = new System.Drawing.Size(71, 20);
            this.rbHourly.TabIndex = 11;
            this.rbHourly.TabStop = true;
            this.rbHourly.Text = "Hourly";
            this.rbHourly.UseVisualStyleBackColor = true;
            this.rbHourly.CheckedChanged += new System.EventHandler(this.rbHourly_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(529, 439);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(448, 439);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Create";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbMissedScheduleMode
            // 
            this.gbMissedScheduleMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbMissedScheduleMode.Controls.Add(this.rbMissedScheduleModeNextScheduledTime);
            this.gbMissedScheduleMode.Controls.Add(this.rbMissedScheduleModeRunImmediately);
            this.gbMissedScheduleMode.Location = new System.Drawing.Point(9, 372);
            this.gbMissedScheduleMode.Name = "gbMissedScheduleMode";
            this.gbMissedScheduleMode.Size = new System.Drawing.Size(461, 43);
            this.gbMissedScheduleMode.TabIndex = 21;
            this.gbMissedScheduleMode.TabStop = false;
            this.gbMissedScheduleMode.Text = "On missed run:";
            // 
            // frmScheduledTaskProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 476);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmScheduledTaskProperties";
            this.Text = "New Scheduled Task";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmScheduledTaskProperties_FormClosing);
            this.Load += new System.EventHandler(this.frmScheduledTaskProperties_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.scheduleTypePanel.ResumeLayout(false);
            this.scheduleTypePanel.PerformLayout();
            this.gbMissedScheduleMode.ResumeLayout(false);
            this.gbMissedScheduleMode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTaskSequence;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbOneTime;
        private System.Windows.Forms.RadioButton rbMonthly;
        private System.Windows.Forms.RadioButton rbWeekly;
        private System.Windows.Forms.RadioButton rbDaily;
        private System.Windows.Forms.GroupBox gbScheduler;
        private System.Windows.Forms.RadioButton rbHourly;
        private Utils.Controls.DateTimePickerEx dtpTaskStartTime;
        private Utils.Controls.DateTimePickerEx dtpTaskEndTime;
        private System.Windows.Forms.CheckBox cbTaskExpires;
        private System.Windows.Forms.CheckBox cbLimitTaskRunTime;
        private System.Windows.Forms.CheckBox cbTaskEnabled;
        private Utils.Controls.IntervalPicker ipMaxDuration;
        private System.Windows.Forms.Panel scheduleTypePanel;
        private System.Windows.Forms.RadioButton rbMissedScheduleModeNextScheduledTime;
        private System.Windows.Forms.RadioButton rbMissedScheduleModeRunImmediately;
        private System.Windows.Forms.GroupBox gbMissedScheduleMode;
    }
}