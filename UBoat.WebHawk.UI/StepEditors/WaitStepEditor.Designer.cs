namespace UBoat.WebHawk.UI.StepEditors
{
    partial class WaitStepEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitStepEditor));
            this.ipWaitDuration = new UBoat.Utils.Controls.IntervalPicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ipWaitDuration
            // 
            this.ipWaitDuration.Location = new System.Drawing.Point(61, 5);
            this.ipWaitDuration.Margin = new System.Windows.Forms.Padding(5);
            this.ipWaitDuration.Name = "ipWaitDuration";
            this.ipWaitDuration.ShowMilliseconds = true;
            this.ipWaitDuration.Size = new System.Drawing.Size(298, 29);
            this.ipWaitDuration.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Duration:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(386, 78);
            this.label2.TabIndex = 7;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // WaitStepEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ipWaitDuration);
            this.Name = "WaitStepEditor";
            this.Size = new System.Drawing.Size(395, 125);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utils.Controls.IntervalPicker ipWaitDuration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
