namespace UBoat.WebHawk.UI.Wizards.Watch
{
    partial class WatchWizardName
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.lblNameExists = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "First, give your watcher a name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(7, 34);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(593, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(483, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Then enter the URL you would like to watch:";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(7, 103);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(593, 20);
            this.txtURL.TabIndex = 3;
            this.txtURL.Text = "http://";
            this.txtURL.TextChanged += new System.EventHandler(this.txtURL_TextChanged);
            // 
            // lblNameExists
            // 
            this.lblNameExists.AutoSize = true;
            this.lblNameExists.ForeColor = System.Drawing.Color.Red;
            this.lblNameExists.Location = new System.Drawing.Point(475, 14);
            this.lblNameExists.Name = "lblNameExists";
            this.lblNameExists.Size = new System.Drawing.Size(125, 13);
            this.lblNameExists.TabIndex = 4;
            this.lblNameExists.Text = "This name already exists!";
            this.lblNameExists.Visible = false;
            // 
            // WizardName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNameExists);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "WizardName";
            this.Size = new System.Drawing.Size(611, 359);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label lblNameExists;
    }
}
