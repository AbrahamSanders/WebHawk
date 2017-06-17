namespace UBoat.WebHawk.UI.Wizards.Watch
{
    partial class WatchWizardRules
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
            this.label1 = new System.Windows.Forms.Label();
            this.rbNumberBelowThreshold = new System.Windows.Forms.RadioButton();
            this.rbNumberAboveThreshold = new System.Windows.Forms.RadioButton();
            this.rbTextContainsPhrase = new System.Windows.Forms.RadioButton();
            this.nudAboveThreshold = new System.Windows.Forms.NumericUpDown();
            this.nudBelowThreshold = new System.Windows.Forms.NumericUpDown();
            this.txtPhrase = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudAboveThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBelowThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(538, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Next, define when you would like to be notified:";
            // 
            // rbNumberBelowThreshold
            // 
            this.rbNumberBelowThreshold.AutoSize = true;
            this.rbNumberBelowThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNumberBelowThreshold.Location = new System.Drawing.Point(7, 106);
            this.rbNumberBelowThreshold.Name = "rbNumberBelowThreshold";
            this.rbNumberBelowThreshold.Size = new System.Drawing.Size(321, 24);
            this.rbNumberBelowThreshold.TabIndex = 2;
            this.rbNumberBelowThreshold.TabStop = true;
            this.rbNumberBelowThreshold.Text = "When the number goes below a threshold";
            this.rbNumberBelowThreshold.UseVisualStyleBackColor = true;
            this.rbNumberBelowThreshold.CheckedChanged += new System.EventHandler(this.rbNumberBelowThreshold_CheckedChanged);
            // 
            // rbNumberAboveThreshold
            // 
            this.rbNumberAboveThreshold.AutoSize = true;
            this.rbNumberAboveThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNumberAboveThreshold.Location = new System.Drawing.Point(7, 50);
            this.rbNumberAboveThreshold.Name = "rbNumberAboveThreshold";
            this.rbNumberAboveThreshold.Size = new System.Drawing.Size(323, 24);
            this.rbNumberAboveThreshold.TabIndex = 3;
            this.rbNumberAboveThreshold.TabStop = true;
            this.rbNumberAboveThreshold.Text = "When the number goes above a threshold";
            this.rbNumberAboveThreshold.UseVisualStyleBackColor = true;
            this.rbNumberAboveThreshold.CheckedChanged += new System.EventHandler(this.rbNumberAboveThreshold_CheckedChanged);
            // 
            // rbTextContainsPhrase
            // 
            this.rbTextContainsPhrase.AutoSize = true;
            this.rbTextContainsPhrase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTextContainsPhrase.Location = new System.Drawing.Point(7, 162);
            this.rbTextContainsPhrase.Name = "rbTextContainsPhrase";
            this.rbTextContainsPhrase.Size = new System.Drawing.Size(256, 24);
            this.rbTextContainsPhrase.TabIndex = 4;
            this.rbTextContainsPhrase.TabStop = true;
            this.rbTextContainsPhrase.Text = "When the text contains a phrase";
            this.rbTextContainsPhrase.UseVisualStyleBackColor = true;
            this.rbTextContainsPhrase.CheckedChanged += new System.EventHandler(this.rbTextContainsPhrase_CheckedChanged);
            // 
            // nudAboveThreshold
            // 
            this.nudAboveThreshold.DecimalPlaces = 2;
            this.nudAboveThreshold.Enabled = false;
            this.nudAboveThreshold.Location = new System.Drawing.Point(19, 80);
            this.nudAboveThreshold.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.nudAboveThreshold.Name = "nudAboveThreshold";
            this.nudAboveThreshold.Size = new System.Drawing.Size(91, 20);
            this.nudAboveThreshold.TabIndex = 5;
            // 
            // nudBelowThreshold
            // 
            this.nudBelowThreshold.DecimalPlaces = 2;
            this.nudBelowThreshold.Enabled = false;
            this.nudBelowThreshold.Location = new System.Drawing.Point(19, 136);
            this.nudBelowThreshold.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.nudBelowThreshold.Name = "nudBelowThreshold";
            this.nudBelowThreshold.Size = new System.Drawing.Size(91, 20);
            this.nudBelowThreshold.TabIndex = 6;
            // 
            // txtPhrase
            // 
            this.txtPhrase.Enabled = false;
            this.txtPhrase.Location = new System.Drawing.Point(19, 192);
            this.txtPhrase.Name = "txtPhrase";
            this.txtPhrase.Size = new System.Drawing.Size(526, 20);
            this.txtPhrase.TabIndex = 7;
            this.txtPhrase.TextChanged += new System.EventHandler(this.txtPhrase_TextChanged);
            // 
            // WatchWizardRules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtPhrase);
            this.Controls.Add(this.nudBelowThreshold);
            this.Controls.Add(this.nudAboveThreshold);
            this.Controls.Add(this.rbTextContainsPhrase);
            this.Controls.Add(this.rbNumberAboveThreshold);
            this.Controls.Add(this.rbNumberBelowThreshold);
            this.Controls.Add(this.label1);
            this.Name = "WatchWizardRules";
            this.Size = new System.Drawing.Size(969, 518);
            ((System.ComponentModel.ISupportInitialize)(this.nudAboveThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBelowThreshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbNumberBelowThreshold;
        private System.Windows.Forms.RadioButton rbNumberAboveThreshold;
        private System.Windows.Forms.RadioButton rbTextContainsPhrase;
        private System.Windows.Forms.NumericUpDown nudAboveThreshold;
        private System.Windows.Forms.NumericUpDown nudBelowThreshold;
        private System.Windows.Forms.TextBox txtPhrase;
    }
}
