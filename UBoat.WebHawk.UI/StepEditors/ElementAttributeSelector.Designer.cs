namespace UBoat.WebHawk.UI.StepEditors
{
    partial class ElementAttributeSelector
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
            this.cbAttribute = new System.Windows.Forms.ComboBox();
            this.rbAttribute = new System.Windows.Forms.RadioButton();
            this.rbInnerText = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // cbAttribute
            // 
            this.cbAttribute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAttribute.FormattingEnabled = true;
            this.cbAttribute.Location = new System.Drawing.Point(146, 0);
            this.cbAttribute.Name = "cbAttribute";
            this.cbAttribute.Size = new System.Drawing.Size(374, 21);
            this.cbAttribute.TabIndex = 11;
            // 
            // rbAttribute
            // 
            this.rbAttribute.AutoSize = true;
            this.rbAttribute.Location = new System.Drawing.Point(76, 1);
            this.rbAttribute.Name = "rbAttribute";
            this.rbAttribute.Size = new System.Drawing.Size(64, 17);
            this.rbAttribute.TabIndex = 13;
            this.rbAttribute.TabStop = true;
            this.rbAttribute.Text = "Attribute";
            this.rbAttribute.UseVisualStyleBackColor = true;
            this.rbAttribute.CheckedChanged += new System.EventHandler(this.rbAttribute_CheckedChanged);
            // 
            // rbInnerText
            // 
            this.rbInnerText.AutoSize = true;
            this.rbInnerText.Location = new System.Drawing.Point(0, 1);
            this.rbInnerText.Name = "rbInnerText";
            this.rbInnerText.Size = new System.Drawing.Size(70, 17);
            this.rbInnerText.TabIndex = 12;
            this.rbInnerText.TabStop = true;
            this.rbInnerText.Text = "InnerText";
            this.rbInnerText.UseVisualStyleBackColor = true;
            // 
            // ElementAttributeSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbAttribute);
            this.Controls.Add(this.rbAttribute);
            this.Controls.Add(this.rbInnerText);
            this.Name = "ElementAttributeSelector";
            this.Size = new System.Drawing.Size(520, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbAttribute;
        private System.Windows.Forms.RadioButton rbAttribute;
        private System.Windows.Forms.RadioButton rbInnerText;
    }
}
