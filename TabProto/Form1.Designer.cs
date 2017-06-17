namespace TabProto
{
    partial class Form1
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
            this.tabControl1 = new UBoat.Utils.Controls.TabControlEx();
            this.tabPage1 = new UBoat.Utils.Controls.TabPageEx();
            this.cbCloseButton = new System.Windows.Forms.CheckBox();
            this.cbNull = new System.Windows.Forms.CheckBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.tabPage2 = new UBoat.Utils.Controls.TabPageEx();
            this.tabPage3 = new UBoat.Utils.Controls.TabPageEx();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.ItemSize = new System.Drawing.Size(58, 24);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(807, 422);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbCloseButton);
            this.tabPage1.Controls.Add(this.cbNull);
            this.tabPage1.Controls.Add(this.txtTitle);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(799, 390);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbCloseButton
            // 
            this.cbCloseButton.AutoSize = true;
            this.cbCloseButton.Location = new System.Drawing.Point(6, 14);
            this.cbCloseButton.Name = "cbCloseButton";
            this.cbCloseButton.Size = new System.Drawing.Size(83, 17);
            this.cbCloseButton.TabIndex = 2;
            this.cbCloseButton.Text = "CloseButton";
            this.cbCloseButton.UseVisualStyleBackColor = true;
            this.cbCloseButton.CheckedChanged += new System.EventHandler(this.cbCloseButton_CheckedChanged);
            // 
            // cbNull
            // 
            this.cbNull.AutoSize = true;
            this.cbNull.Location = new System.Drawing.Point(249, 39);
            this.cbNull.Name = "cbNull";
            this.cbNull.Size = new System.Drawing.Size(44, 17);
            this.cbNull.TabIndex = 1;
            this.cbNull.Text = "Null";
            this.cbNull.UseVisualStyleBackColor = true;
            this.cbNull.CheckedChanged += new System.EventHandler(this.cbNull_CheckedChanged);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(6, 37);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(237, 20);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(799, 390);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(799, 390);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 446);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UBoat.Utils.Controls.TabControlEx tabControl1;
        private UBoat.Utils.Controls.TabPageEx tabPage1;
        private UBoat.Utils.Controls.TabPageEx tabPage2;
        private UBoat.Utils.Controls.TabPageEx tabPage3;
        private System.Windows.Forms.CheckBox cbNull;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.CheckBox cbCloseButton;
    }
}

