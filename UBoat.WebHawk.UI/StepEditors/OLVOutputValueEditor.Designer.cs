namespace UBoat.WebHawk.UI.StepEditors
{
    partial class OLVOutputValueEditor
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
            this.txtOutputValue = new System.Windows.Forms.TextBox();
            this.btnInsertVariable = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtOutputValue
            // 
            this.txtOutputValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputValue.Location = new System.Drawing.Point(0, 0);
            this.txtOutputValue.Name = "txtOutputValue";
            this.txtOutputValue.Size = new System.Drawing.Size(241, 20);
            this.txtOutputValue.TabIndex = 0;
            // 
            // btnInsertVariable
            // 
            this.btnInsertVariable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsertVariable.BackgroundImage = global::UBoat.WebHawk.UI.Properties.Resources.Add;
            this.btnInsertVariable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInsertVariable.Location = new System.Drawing.Point(244, 0);
            this.btnInsertVariable.Name = "btnInsertVariable";
            this.btnInsertVariable.Size = new System.Drawing.Size(19, 18);
            this.btnInsertVariable.TabIndex = 1;
            this.btnInsertVariable.UseVisualStyleBackColor = true;
            this.btnInsertVariable.Click += new System.EventHandler(this.btnInsertVariable_Click);
            // 
            // OLVOutputValueEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnInsertVariable);
            this.Controls.Add(this.txtOutputValue);
            this.Name = "OLVOutputValueEditor";
            this.Size = new System.Drawing.Size(264, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOutputValue;
        private System.Windows.Forms.Button btnInsertVariable;
    }
}
