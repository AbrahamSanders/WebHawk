namespace UBoat.WebHawk.UI.Wizards.Scrape
{
    partial class ScrapeWizardName
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
            this.lblNameExists = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtURL1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtURL2 = new System.Windows.Forms.TextBox();
            this.txtURL3 = new System.Windows.Forms.TextBox();
            this.btnAddUrl = new System.Windows.Forms.Button();
            this.URLPanel = new System.Windows.Forms.Panel();
            this.URLPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNameExists
            // 
            this.lblNameExists.AutoSize = true;
            this.lblNameExists.ForeColor = System.Drawing.Color.Red;
            this.lblNameExists.Location = new System.Drawing.Point(475, 14);
            this.lblNameExists.Name = "lblNameExists";
            this.lblNameExists.Size = new System.Drawing.Size(125, 13);
            this.lblNameExists.TabIndex = 7;
            this.lblNameExists.Text = "This name already exists!";
            this.lblNameExists.Visible = false;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(7, 34);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(593, 20);
            this.txtName.TabIndex = 6;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "First, give your scraper a name:";
            // 
            // txtURL1
            // 
            this.txtURL1.Location = new System.Drawing.Point(0, 3);
            this.txtURL1.Name = "txtURL1";
            this.txtURL1.Size = new System.Drawing.Size(593, 20);
            this.txtURL1.TabIndex = 9;
            this.txtURL1.Text = "http://";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(527, 22);
            this.label2.TabIndex = 8;
            this.label2.Text = "Then enter the URL(s) you would like to scrape:";
            // 
            // txtURL2
            // 
            this.txtURL2.Location = new System.Drawing.Point(0, 29);
            this.txtURL2.Name = "txtURL2";
            this.txtURL2.Size = new System.Drawing.Size(593, 20);
            this.txtURL2.TabIndex = 10;
            this.txtURL2.Text = "http://";
            // 
            // txtURL3
            // 
            this.txtURL3.Location = new System.Drawing.Point(0, 55);
            this.txtURL3.Name = "txtURL3";
            this.txtURL3.Size = new System.Drawing.Size(593, 20);
            this.txtURL3.TabIndex = 11;
            this.txtURL3.Text = "http://";
            // 
            // btnAddUrl
            // 
            this.btnAddUrl.BackgroundImage = global::UBoat.WebHawk.UI.Properties.Resources.Add;
            this.btnAddUrl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddUrl.Location = new System.Drawing.Point(563, 81);
            this.btnAddUrl.Name = "btnAddUrl";
            this.btnAddUrl.Size = new System.Drawing.Size(33, 34);
            this.btnAddUrl.TabIndex = 12;
            this.btnAddUrl.UseVisualStyleBackColor = true;
            this.btnAddUrl.Click += new System.EventHandler(this.btnAddUrl_Click);
            // 
            // URLPanel
            // 
            this.URLPanel.Controls.Add(this.txtURL1);
            this.URLPanel.Controls.Add(this.btnAddUrl);
            this.URLPanel.Controls.Add(this.txtURL2);
            this.URLPanel.Controls.Add(this.txtURL3);
            this.URLPanel.Location = new System.Drawing.Point(7, 105);
            this.URLPanel.Name = "URLPanel";
            this.URLPanel.Size = new System.Drawing.Size(602, 284);
            this.URLPanel.TabIndex = 13;
            // 
            // ScrapeWizardName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.URLPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNameExists);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "ScrapeWizardName";
            this.Size = new System.Drawing.Size(698, 392);
            this.URLPanel.ResumeLayout(false);
            this.URLPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNameExists;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtURL1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtURL2;
        private System.Windows.Forms.TextBox txtURL3;
        private System.Windows.Forms.Button btnAddUrl;
        private System.Windows.Forms.Panel URLPanel;
    }
}
