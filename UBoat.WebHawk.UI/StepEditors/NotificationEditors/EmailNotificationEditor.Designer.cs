namespace UBoat.WebHawk.UI.StepEditors.NotificationEditors
{
    partial class EmailNotificationEditor
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
            this.gbSmtp = new System.Windows.Forms.GroupBox();
            this.txtSmtpPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSmtpUsername = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbSmtpSSL = new System.Windows.Forms.CheckBox();
            this.nudSmtpPort = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSmtpHost = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSmtpPresets = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbAddresses = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtToAddresses = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFromAddressDisplayName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFromAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gbSmtp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSmtpPort)).BeginInit();
            this.gbAddresses.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSmtp
            // 
            this.gbSmtp.Controls.Add(this.txtSmtpPassword);
            this.gbSmtp.Controls.Add(this.label6);
            this.gbSmtp.Controls.Add(this.txtSmtpUsername);
            this.gbSmtp.Controls.Add(this.label5);
            this.gbSmtp.Controls.Add(this.label4);
            this.gbSmtp.Controls.Add(this.cbSmtpSSL);
            this.gbSmtp.Controls.Add(this.nudSmtpPort);
            this.gbSmtp.Controls.Add(this.label3);
            this.gbSmtp.Controls.Add(this.txtSmtpHost);
            this.gbSmtp.Controls.Add(this.label2);
            this.gbSmtp.Controls.Add(this.cbSmtpPresets);
            this.gbSmtp.Controls.Add(this.label1);
            this.gbSmtp.Location = new System.Drawing.Point(3, 3);
            this.gbSmtp.Name = "gbSmtp";
            this.gbSmtp.Size = new System.Drawing.Size(297, 153);
            this.gbSmtp.TabIndex = 0;
            this.gbSmtp.TabStop = false;
            this.gbSmtp.Text = "SMTP Settings";
            // 
            // txtSmtpPassword
            // 
            this.txtSmtpPassword.Location = new System.Drawing.Point(70, 123);
            this.txtSmtpPassword.Name = "txtSmtpPassword";
            this.txtSmtpPassword.Size = new System.Drawing.Size(221, 20);
            this.txtSmtpPassword.TabIndex = 11;
            this.txtSmtpPassword.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Password:";
            // 
            // txtSmtpUsername
            // 
            this.txtSmtpUsername.Location = new System.Drawing.Point(70, 97);
            this.txtSmtpUsername.Name = "txtSmtpUsername";
            this.txtSmtpUsername.Size = new System.Drawing.Size(221, 20);
            this.txtSmtpUsername.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Username:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "SSL:";
            // 
            // cbSmtpSSL
            // 
            this.cbSmtpSSL.AutoSize = true;
            this.cbSmtpSSL.Location = new System.Drawing.Point(163, 74);
            this.cbSmtpSSL.Name = "cbSmtpSSL";
            this.cbSmtpSSL.Size = new System.Drawing.Size(15, 14);
            this.cbSmtpSSL.TabIndex = 6;
            this.cbSmtpSSL.UseVisualStyleBackColor = true;
            // 
            // nudSmtpPort
            // 
            this.nudSmtpPort.Location = new System.Drawing.Point(70, 71);
            this.nudSmtpPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudSmtpPort.Name = "nudSmtpPort";
            this.nudSmtpPort.Size = new System.Drawing.Size(50, 20);
            this.nudSmtpPort.TabIndex = 5;
            this.nudSmtpPort.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Port:";
            // 
            // txtSmtpHost
            // 
            this.txtSmtpHost.Location = new System.Drawing.Point(70, 45);
            this.txtSmtpHost.Name = "txtSmtpHost";
            this.txtSmtpHost.Size = new System.Drawing.Size(221, 20);
            this.txtSmtpHost.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Host:";
            // 
            // cbSmtpPresets
            // 
            this.cbSmtpPresets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSmtpPresets.FormattingEnabled = true;
            this.cbSmtpPresets.Location = new System.Drawing.Point(57, 18);
            this.cbSmtpPresets.Name = "cbSmtpPresets";
            this.cbSmtpPresets.Size = new System.Drawing.Size(92, 21);
            this.cbSmtpPresets.TabIndex = 1;
            this.cbSmtpPresets.SelectedIndexChanged += new System.EventHandler(this.cbSmtpPresets_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Presets:";
            // 
            // gbAddresses
            // 
            this.gbAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAddresses.Controls.Add(this.label10);
            this.gbAddresses.Controls.Add(this.txtToAddresses);
            this.gbAddresses.Controls.Add(this.label9);
            this.gbAddresses.Controls.Add(this.txtFromAddressDisplayName);
            this.gbAddresses.Controls.Add(this.label8);
            this.gbAddresses.Controls.Add(this.txtFromAddress);
            this.gbAddresses.Controls.Add(this.label7);
            this.gbAddresses.Location = new System.Drawing.Point(306, 3);
            this.gbAddresses.Name = "gbAddresses";
            this.gbAddresses.Size = new System.Drawing.Size(295, 153);
            this.gbAddresses.TabIndex = 1;
            this.gbAddresses.TabStop = false;
            this.gbAddresses.Text = "Sender / Recipients";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(282, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "*Multiple addresses should be separated by a semicolon (;)";
            // 
            // txtToAddresses
            // 
            this.txtToAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToAddresses.Location = new System.Drawing.Point(93, 71);
            this.txtToAddresses.Name = "txtToAddresses";
            this.txtToAddresses.Size = new System.Drawing.Size(195, 20);
            this.txtToAddresses.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "To Address(es):";
            // 
            // txtFromAddressDisplayName
            // 
            this.txtFromAddressDisplayName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromAddressDisplayName.Location = new System.Drawing.Point(93, 45);
            this.txtFromAddressDisplayName.Name = "txtFromAddressDisplayName";
            this.txtFromAddressDisplayName.Size = new System.Drawing.Size(195, 20);
            this.txtFromAddressDisplayName.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Display Name:";
            // 
            // txtFromAddress
            // 
            this.txtFromAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromAddress.Location = new System.Drawing.Point(93, 19);
            this.txtFromAddress.Name = "txtFromAddress";
            this.txtFromAddress.Size = new System.Drawing.Size(195, 20);
            this.txtFromAddress.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "From Address:";
            // 
            // EmailNotificationEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbAddresses);
            this.Controls.Add(this.gbSmtp);
            this.Name = "EmailNotificationEditor";
            this.Size = new System.Drawing.Size(609, 162);
            this.gbSmtp.ResumeLayout(false);
            this.gbSmtp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSmtpPort)).EndInit();
            this.gbAddresses.ResumeLayout(false);
            this.gbAddresses.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSmtp;
        private System.Windows.Forms.ComboBox cbSmtpPresets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbSmtpSSL;
        private System.Windows.Forms.NumericUpDown nudSmtpPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSmtpHost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSmtpPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSmtpUsername;
        private System.Windows.Forms.GroupBox gbAddresses;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtToAddresses;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFromAddressDisplayName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFromAddress;
        private System.Windows.Forms.Label label7;
    }
}
