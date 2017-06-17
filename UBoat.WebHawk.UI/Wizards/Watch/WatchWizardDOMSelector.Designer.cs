namespace UBoat.WebHawk.UI.Wizards.Watch
{
    partial class WatchWizardDOMSelector
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
            this.wbDOMSelector = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSelectedElement = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // wbDOMSelector
            // 
            this.wbDOMSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbDOMSelector.IsWebBrowserContextMenuEnabled = false;
            this.wbDOMSelector.Location = new System.Drawing.Point(7, 71);
            this.wbDOMSelector.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbDOMSelector.Name = "wbDOMSelector";
            this.wbDOMSelector.ScriptErrorsSuppressed = true;
            this.wbDOMSelector.Size = new System.Drawing.Size(798, 400);
            this.wbDOMSelector.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(725, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "Next, select the element of the web page you would like to watch. Press CTRL and " +
    "hover over the desired element.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Selected Element:";
            // 
            // lblSelectedElement
            // 
            this.lblSelectedElement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedElement.Location = new System.Drawing.Point(148, 48);
            this.lblSelectedElement.Name = "lblSelectedElement";
            this.lblSelectedElement.Size = new System.Drawing.Size(657, 20);
            this.lblSelectedElement.TabIndex = 4;
            this.lblSelectedElement.Text = "None";
            // 
            // WatchWizardDOMSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSelectedElement);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.wbDOMSelector);
            this.Controls.Add(this.label1);
            this.Name = "WatchWizardDOMSelector";
            this.Size = new System.Drawing.Size(808, 474);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.WebBrowser wbDOMSelector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSelectedElement;
    }
}
