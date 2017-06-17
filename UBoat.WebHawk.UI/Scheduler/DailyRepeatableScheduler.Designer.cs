namespace UBoat.WebHawk.UI.Scheduler
{
    partial class DailyRepeatableScheduler
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
            this.cbRepeatsDailyOnInterval = new System.Windows.Forms.CheckBox();
            this.ipDailyRepetitionInterval = new UBoat.Utils.Controls.IntervalPicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDailyRepetitionStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpDailyRepetitionEndTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dailyRepetitionPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dailyRepetitionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbRepeatsDailyOnInterval
            // 
            this.cbRepeatsDailyOnInterval.AutoSize = true;
            this.cbRepeatsDailyOnInterval.Location = new System.Drawing.Point(3, 3);
            this.cbRepeatsDailyOnInterval.Name = "cbRepeatsDailyOnInterval";
            this.cbRepeatsDailyOnInterval.Size = new System.Drawing.Size(15, 14);
            this.cbRepeatsDailyOnInterval.TabIndex = 0;
            this.cbRepeatsDailyOnInterval.UseVisualStyleBackColor = true;
            this.cbRepeatsDailyOnInterval.CheckedChanged += new System.EventHandler(this.cbRepeatsDailyOnInterval_CheckedChanged);
            // 
            // ipDailyRepetitionInterval
            // 
            this.ipDailyRepetitionInterval.Location = new System.Drawing.Point(77, 1);
            this.ipDailyRepetitionInterval.Name = "ipDailyRepetitionInterval";
            this.ipDailyRepetitionInterval.ShowMilliseconds = false;
            this.ipDailyRepetitionInterval.Size = new System.Drawing.Size(231, 21);
            this.ipDailyRepetitionInterval.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "between";
            // 
            // dtpDailyRepetitionStartTime
            // 
            this.dtpDailyRepetitionStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpDailyRepetitionStartTime.Location = new System.Drawing.Point(77, 27);
            this.dtpDailyRepetitionStartTime.Name = "dtpDailyRepetitionStartTime";
            this.dtpDailyRepetitionStartTime.ShowUpDown = true;
            this.dtpDailyRepetitionStartTime.Size = new System.Drawing.Size(97, 20);
            this.dtpDailyRepetitionStartTime.TabIndex = 3;
            // 
            // dtpDailyRepetitionEndTime
            // 
            this.dtpDailyRepetitionEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpDailyRepetitionEndTime.Location = new System.Drawing.Point(211, 27);
            this.dtpDailyRepetitionEndTime.Name = "dtpDailyRepetitionEndTime";
            this.dtpDailyRepetitionEndTime.ShowUpDown = true;
            this.dtpDailyRepetitionEndTime.Size = new System.Drawing.Size(97, 20);
            this.dtpDailyRepetitionEndTime.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "and";
            // 
            // dailyRepetitionPanel
            // 
            this.dailyRepetitionPanel.Controls.Add(this.label3);
            this.dailyRepetitionPanel.Controls.Add(this.ipDailyRepetitionInterval);
            this.dailyRepetitionPanel.Controls.Add(this.label2);
            this.dailyRepetitionPanel.Controls.Add(this.label1);
            this.dailyRepetitionPanel.Controls.Add(this.dtpDailyRepetitionEndTime);
            this.dailyRepetitionPanel.Controls.Add(this.dtpDailyRepetitionStartTime);
            this.dailyRepetitionPanel.Location = new System.Drawing.Point(24, -1);
            this.dailyRepetitionPanel.Name = "dailyRepetitionPanel";
            this.dailyRepetitionPanel.Size = new System.Drawing.Size(312, 50);
            this.dailyRepetitionPanel.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Repeat every";
            // 
            // DailyRepeatableScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dailyRepetitionPanel);
            this.Controls.Add(this.cbRepeatsDailyOnInterval);
            this.Name = "DailyRepeatableScheduler";
            this.Size = new System.Drawing.Size(335, 51);
            this.dailyRepetitionPanel.ResumeLayout(false);
            this.dailyRepetitionPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbRepeatsDailyOnInterval;
        private Utils.Controls.IntervalPicker ipDailyRepetitionInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDailyRepetitionStartTime;
        private System.Windows.Forms.DateTimePicker dtpDailyRepetitionEndTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel dailyRepetitionPanel;
        private System.Windows.Forms.Label label3;
    }
}
