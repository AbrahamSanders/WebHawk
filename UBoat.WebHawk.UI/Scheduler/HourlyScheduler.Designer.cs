namespace UBoat.WebHawk.UI.Scheduler
{
    partial class HourlyScheduler
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
            this.label4 = new System.Windows.Forms.Label();
            this.ipHourlyRecurrence = new UBoat.Utils.Controls.IntervalPicker();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Recur every:";
            // 
            // ipHourlyRecurrence
            // 
            this.ipHourlyRecurrence.Location = new System.Drawing.Point(78, 2);
            this.ipHourlyRecurrence.Margin = new System.Windows.Forms.Padding(4);
            this.ipHourlyRecurrence.Name = "ipHourlyRecurrence";
            this.ipHourlyRecurrence.ShowMilliseconds = false;
            this.ipHourlyRecurrence.Size = new System.Drawing.Size(188, 24);
            this.ipHourlyRecurrence.TabIndex = 10;
            // 
            // HourlyScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ipHourlyRecurrence);
            this.Controls.Add(this.label4);
            this.Name = "HourlyScheduler";
            this.Size = new System.Drawing.Size(270, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private Utils.Controls.IntervalPicker ipHourlyRecurrence;
    }
}
