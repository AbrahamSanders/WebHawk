namespace UBoat.WebHawk.UI.Wizards.Watch
{
    partial class WatchWizardNotification
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSendEmail = new System.Windows.Forms.CheckBox();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.cbSendSMS = new System.Windows.Forms.CheckBox();
            this.txtSMSNumber = new System.Windows.Forms.TextBox();
            this.cbPopupWindow = new System.Windows.Forms.CheckBox();
            this.ipRunInterval = new UBoat.Utils.Controls.IntervalPicker();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Finally...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-4, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(527, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "How often would you like to check the web page?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-4, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(384, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "How would you like to be notified?";
            // 
            // cbSendEmail
            // 
            this.cbSendEmail.AutoSize = true;
            this.cbSendEmail.Location = new System.Drawing.Point(3, 117);
            this.cbSendEmail.Name = "cbSendEmail";
            this.cbSendEmail.Size = new System.Drawing.Size(122, 17);
            this.cbSendEmail.TabIndex = 4;
            this.cbSendEmail.Text = "Send me an email at";
            this.cbSendEmail.UseVisualStyleBackColor = true;
            this.cbSendEmail.CheckedChanged += new System.EventHandler(this.cbSendEmail_CheckedChanged);
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Enabled = false;
            this.txtEmailAddress.Location = new System.Drawing.Point(25, 140);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(218, 20);
            this.txtEmailAddress.TabIndex = 5;
            this.txtEmailAddress.TextChanged += new System.EventHandler(this.txtEmailAddress_TextChanged);
            // 
            // cbSendSMS
            // 
            this.cbSendSMS.AutoSize = true;
            this.cbSendSMS.Enabled = false;
            this.cbSendSMS.Location = new System.Drawing.Point(3, 166);
            this.cbSendSMS.Name = "cbSendSMS";
            this.cbSendSMS.Size = new System.Drawing.Size(115, 17);
            this.cbSendSMS.TabIndex = 6;
            this.cbSendSMS.Text = "Send me a SMS at";
            this.cbSendSMS.UseVisualStyleBackColor = true;
            this.cbSendSMS.CheckedChanged += new System.EventHandler(this.cbSendSMS_CheckedChanged);
            // 
            // txtSMSNumber
            // 
            this.txtSMSNumber.Enabled = false;
            this.txtSMSNumber.Location = new System.Drawing.Point(25, 189);
            this.txtSMSNumber.Name = "txtSMSNumber";
            this.txtSMSNumber.Size = new System.Drawing.Size(218, 20);
            this.txtSMSNumber.TabIndex = 7;
            this.txtSMSNumber.TextChanged += new System.EventHandler(this.txtSMSNumber_TextChanged);
            // 
            // cbPopupWindow
            // 
            this.cbPopupWindow.AutoSize = true;
            this.cbPopupWindow.Location = new System.Drawing.Point(3, 215);
            this.cbPopupWindow.Name = "cbPopupWindow";
            this.cbPopupWindow.Size = new System.Drawing.Size(108, 17);
            this.cbPopupWindow.TabIndex = 8;
            this.cbPopupWindow.Text = "Pop up a window";
            this.cbPopupWindow.UseVisualStyleBackColor = true;
            this.cbPopupWindow.CheckedChanged += new System.EventHandler(this.cbPopupWindow_CheckedChanged);
            // 
            // ipCheckInterval
            // 
            this.ipRunInterval.Location = new System.Drawing.Point(3, 47);
            this.ipRunInterval.Name = "ipCheckInterval";
            this.ipRunInterval.Size = new System.Drawing.Size(179, 21);
            this.ipRunInterval.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-3, 383);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(608, 40);
            this.label4.TabIndex = 10;
            this.label4.Text = "(To properly receive email notifications, remember to add to your trusted senders" +
    " list! Click the link above to copy.)";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(576, 381);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(200, 20);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "webhawknotify@gmail.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // WatchWizardNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ipRunInterval);
            this.Controls.Add(this.cbPopupWindow);
            this.Controls.Add(this.txtSMSNumber);
            this.Controls.Add(this.cbSendSMS);
            this.Controls.Add(this.txtEmailAddress);
            this.Controls.Add(this.cbSendEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "WatchWizardNotification";
            this.Size = new System.Drawing.Size(779, 423);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbSendEmail;
        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.CheckBox cbSendSMS;
        private System.Windows.Forms.TextBox txtSMSNumber;
        private System.Windows.Forms.CheckBox cbPopupWindow;
        private Utils.Controls.IntervalPicker ipRunInterval;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}
