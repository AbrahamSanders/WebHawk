namespace UBoat.WebHawk.UI.Scheduler
{
    partial class DailyScheduler
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
            this.label5 = new System.Windows.Forms.Label();
            this.nudDailyRecurrence = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.dailyRepeatableScheduler = new UBoat.WebHawk.UI.Scheduler.DailyRepeatableScheduler();
            ((System.ComponentModel.ISupportInitialize)(this.nudDailyRecurrence)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(130, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "days";
            // 
            // nudDailyRecurrence
            // 
            this.nudDailyRecurrence.Location = new System.Drawing.Point(76, 3);
            this.nudDailyRecurrence.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.nudDailyRecurrence.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDailyRecurrence.Name = "nudDailyRecurrence";
            this.nudDailyRecurrence.Size = new System.Drawing.Size(48, 20);
            this.nudDailyRecurrence.TabIndex = 9;
            this.nudDailyRecurrence.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Recur every:";
            // 
            // dailyRepeatableScheduler
            // 
            this.dailyRepeatableScheduler.Location = new System.Drawing.Point(5, 29);
            this.dailyRepeatableScheduler.Name = "dailyRepeatableScheduler";
            this.dailyRepeatableScheduler.Schedule = null;
            this.dailyRepeatableScheduler.Size = new System.Drawing.Size(333, 53);
            this.dailyRepeatableScheduler.TabIndex = 11;
            // 
            // DailyScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dailyRepeatableScheduler);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudDailyRecurrence);
            this.Controls.Add(this.label4);
            this.Name = "DailyScheduler";
            this.Size = new System.Drawing.Size(420, 87);
            ((System.ComponentModel.ISupportInitialize)(this.nudDailyRecurrence)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudDailyRecurrence;
        private System.Windows.Forms.Label label4;
        private DailyRepeatableScheduler dailyRepeatableScheduler;
    }
}
