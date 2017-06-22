namespace UBoat.WebHawk.UI.StepEditors.NotificationEditors
{
    partial class SMSNotificationEditor
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
            this.gbTextbelt = new System.Windows.Forms.GroupBox();
            this.cbTextbeltPresets = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTextbeltAPIURL = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTextbeltAPIKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbAddresses = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNumbers = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbTextbelt.SuspendLayout();
            this.gbAddresses.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTextbelt
            // 
            this.gbTextbelt.Controls.Add(this.cbTextbeltPresets);
            this.gbTextbelt.Controls.Add(this.label5);
            this.gbTextbelt.Controls.Add(this.txtTextbeltAPIURL);
            this.gbTextbelt.Controls.Add(this.label4);
            this.gbTextbelt.Controls.Add(this.label3);
            this.gbTextbelt.Controls.Add(this.txtTextbeltAPIKey);
            this.gbTextbelt.Controls.Add(this.label1);
            this.gbTextbelt.Location = new System.Drawing.Point(3, 3);
            this.gbTextbelt.Name = "gbTextbelt";
            this.gbTextbelt.Size = new System.Drawing.Size(297, 153);
            this.gbTextbelt.TabIndex = 0;
            this.gbTextbelt.TabStop = false;
            this.gbTextbelt.Text = "Textbelt Settings";
            // 
            // cbTextbeltPresets
            // 
            this.cbTextbeltPresets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTextbeltPresets.FormattingEnabled = true;
            this.cbTextbeltPresets.Location = new System.Drawing.Point(57, 22);
            this.cbTextbeltPresets.Name = "cbTextbeltPresets";
            this.cbTextbeltPresets.Size = new System.Drawing.Size(92, 21);
            this.cbTextbeltPresets.TabIndex = 23;
            this.cbTextbeltPresets.SelectedIndexChanged += new System.EventHandler(this.cbTextbeltPresets_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Presets:";
            // 
            // txtTextbeltAPIURL
            // 
            this.txtTextbeltAPIURL.Location = new System.Drawing.Point(70, 49);
            this.txtTextbeltAPIURL.Name = "txtTextbeltAPIURL";
            this.txtTextbeltAPIURL.Size = new System.Drawing.Size(221, 20);
            this.txtTextbeltAPIURL.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "API URL:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(268, 26);
            this.label3.TabIndex = 19;
            this.label3.Text = "*API key only needed if using the paid Textbelt service.\r\n If using a self-hosted" +
    " Textbelt service, leave this blank.";
            // 
            // txtTextbeltAPIKey
            // 
            this.txtTextbeltAPIKey.Location = new System.Drawing.Point(70, 75);
            this.txtTextbeltAPIKey.Name = "txtTextbeltAPIKey";
            this.txtTextbeltAPIKey.Size = new System.Drawing.Size(221, 20);
            this.txtTextbeltAPIKey.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "API Key:";
            // 
            // gbAddresses
            // 
            this.gbAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAddresses.Controls.Add(this.label10);
            this.gbAddresses.Controls.Add(this.txtNumbers);
            this.gbAddresses.Controls.Add(this.label2);
            this.gbAddresses.Location = new System.Drawing.Point(306, 3);
            this.gbAddresses.Name = "gbAddresses";
            this.gbAddresses.Size = new System.Drawing.Size(289, 153);
            this.gbAddresses.TabIndex = 1;
            this.gbAddresses.TabStop = false;
            this.gbAddresses.Text = "Recipients";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(274, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "*Multiple numbers should be separated by a semicolon (;)";
            // 
            // txtNumbers
            // 
            this.txtNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumbers.Location = new System.Drawing.Point(70, 19);
            this.txtNumbers.Name = "txtNumbers";
            this.txtNumbers.Size = new System.Drawing.Size(213, 20);
            this.txtNumbers.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number(s):";
            // 
            // SMSNotificationEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbAddresses);
            this.Controls.Add(this.gbTextbelt);
            this.Name = "SMSNotificationEditor";
            this.Size = new System.Drawing.Size(601, 162);
            this.gbTextbelt.ResumeLayout(false);
            this.gbTextbelt.PerformLayout();
            this.gbAddresses.ResumeLayout(false);
            this.gbAddresses.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTextbelt;
        private System.Windows.Forms.TextBox txtTextbeltAPIKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbAddresses;
        private System.Windows.Forms.TextBox txtNumbers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTextbeltAPIURL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTextbeltPresets;
        private System.Windows.Forms.Label label5;
    }
}
