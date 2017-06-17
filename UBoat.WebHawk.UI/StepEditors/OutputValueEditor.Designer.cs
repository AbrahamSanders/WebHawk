namespace UBoat.WebHawk.UI.StepEditors
{
    partial class OutputValueEditor
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
            this.cbTrimVariableValueWhitespace = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbVariableList = new System.Windows.Forms.ComboBox();
            this.btnInsertVariable = new System.Windows.Forms.Button();
            this.txtOutputValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbTrimVariableValueWhitespace
            // 
            this.cbTrimVariableValueWhitespace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbTrimVariableValueWhitespace.AutoSize = true;
            this.cbTrimVariableValueWhitespace.Location = new System.Drawing.Point(0, 141);
            this.cbTrimVariableValueWhitespace.Name = "cbTrimVariableValueWhitespace";
            this.cbTrimVariableValueWhitespace.Size = new System.Drawing.Size(200, 17);
            this.cbTrimVariableValueWhitespace.TabIndex = 17;
            this.cbTrimVariableValueWhitespace.Text = "Trim whitespace from variable values";
            this.cbTrimVariableValueWhitespace.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Insert Variable:";
            // 
            // cbVariableList
            // 
            this.cbVariableList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVariableList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariableList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVariableList.FormattingEnabled = true;
            this.cbVariableList.Location = new System.Drawing.Point(319, 134);
            this.cbVariableList.Name = "cbVariableList";
            this.cbVariableList.Size = new System.Drawing.Size(269, 28);
            this.cbVariableList.TabIndex = 15;
            // 
            // btnInsertVariable
            // 
            this.btnInsertVariable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsertVariable.BackgroundImage = global::UBoat.WebHawk.UI.Properties.Resources.Add;
            this.btnInsertVariable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInsertVariable.Location = new System.Drawing.Point(594, 132);
            this.btnInsertVariable.Name = "btnInsertVariable";
            this.btnInsertVariable.Size = new System.Drawing.Size(31, 32);
            this.btnInsertVariable.TabIndex = 14;
            this.btnInsertVariable.UseVisualStyleBackColor = true;
            this.btnInsertVariable.Click += new System.EventHandler(this.btnInsertVariable_Click);
            // 
            // txtOutputValue
            // 
            this.txtOutputValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputValue.Location = new System.Drawing.Point(0, 0);
            this.txtOutputValue.Multiline = true;
            this.txtOutputValue.Name = "txtOutputValue";
            this.txtOutputValue.Size = new System.Drawing.Size(625, 126);
            this.txtOutputValue.TabIndex = 13;
            // 
            // OutputValueEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbTrimVariableValueWhitespace);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbVariableList);
            this.Controls.Add(this.btnInsertVariable);
            this.Controls.Add(this.txtOutputValue);
            this.Name = "OutputValueEditor";
            this.Size = new System.Drawing.Size(625, 164);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbTrimVariableValueWhitespace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbVariableList;
        private System.Windows.Forms.Button btnInsertVariable;
        private System.Windows.Forms.TextBox txtOutputValue;

    }
}
