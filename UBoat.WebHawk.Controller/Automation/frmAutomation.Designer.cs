namespace UBoat.WebHawk.Controller.Automation
{
    internal partial class frmAutomation
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
            this.wbAutomation = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbAutomation
            // 
            this.wbAutomation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbAutomation.IsWebBrowserContextMenuEnabled = false;
            this.wbAutomation.Location = new System.Drawing.Point(0, 0);
            this.wbAutomation.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbAutomation.Name = "wbAutomation";
            this.wbAutomation.ScriptErrorsSuppressed = true;
            this.wbAutomation.Size = new System.Drawing.Size(588, 338);
            this.wbAutomation.TabIndex = 0;
            // 
            // frmAutomation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 338);
            this.Controls.Add(this.wbAutomation);
            this.Name = "frmAutomation";
            this.Text = "frmAutomation";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbAutomation;
    }
}