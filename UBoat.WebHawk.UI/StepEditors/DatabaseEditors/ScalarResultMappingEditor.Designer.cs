namespace UBoat.WebHawk.UI.StepEditors.DatabaseEditors
{
    partial class ScalarResultMappingEditor
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
            this.cbPersistVariable = new System.Windows.Forms.CheckBox();
            this.cbVariableName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbXMLNone = new System.Windows.Forms.RadioButton();
            this.rbXMLAttribute = new System.Windows.Forms.RadioButton();
            this.rbXMLElement = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbPersistVariable
            // 
            this.cbPersistVariable.AutoSize = true;
            this.cbPersistVariable.Location = new System.Drawing.Point(571, 5);
            this.cbPersistVariable.Name = "cbPersistVariable";
            this.cbPersistVariable.Size = new System.Drawing.Size(57, 17);
            this.cbPersistVariable.TabIndex = 23;
            this.cbPersistVariable.Text = "Persist";
            this.cbPersistVariable.UseVisualStyleBackColor = true;
            // 
            // cbVariableName
            // 
            this.cbVariableName.FormattingEnabled = true;
            this.cbVariableName.Location = new System.Drawing.Point(104, 3);
            this.cbVariableName.Name = "cbVariableName";
            this.cbVariableName.Size = new System.Drawing.Size(461, 21);
            this.cbVariableName.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "State Variable:";
            // 
            // rbXMLNone
            // 
            this.rbXMLNone.AutoSize = true;
            this.rbXMLNone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbXMLNone.Location = new System.Drawing.Point(256, 30);
            this.rbXMLNone.Name = "rbXMLNone";
            this.rbXMLNone.Size = new System.Drawing.Size(51, 17);
            this.rbXMLNone.TabIndex = 22;
            this.rbXMLNone.TabStop = true;
            this.rbXMLNone.Text = "None";
            this.rbXMLNone.UseVisualStyleBackColor = true;
            // 
            // rbXMLAttribute
            // 
            this.rbXMLAttribute.AutoSize = true;
            this.rbXMLAttribute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbXMLAttribute.Location = new System.Drawing.Point(180, 30);
            this.rbXMLAttribute.Name = "rbXMLAttribute";
            this.rbXMLAttribute.Size = new System.Drawing.Size(64, 17);
            this.rbXMLAttribute.TabIndex = 20;
            this.rbXMLAttribute.TabStop = true;
            this.rbXMLAttribute.Text = "Attribute";
            this.rbXMLAttribute.UseVisualStyleBackColor = true;
            // 
            // rbXMLElement
            // 
            this.rbXMLElement.AutoSize = true;
            this.rbXMLElement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbXMLElement.Location = new System.Drawing.Point(104, 30);
            this.rbXMLElement.Name = "rbXMLElement";
            this.rbXMLElement.Size = new System.Drawing.Size(63, 17);
            this.rbXMLElement.TabIndex = 18;
            this.rbXMLElement.TabStop = true;
            this.rbXMLElement.Text = "Element";
            this.rbXMLElement.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "XML Output Mode:";
            // 
            // ScalarResultMappingEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbPersistVariable);
            this.Controls.Add(this.cbVariableName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbXMLNone);
            this.Controls.Add(this.rbXMLAttribute);
            this.Controls.Add(this.rbXMLElement);
            this.Controls.Add(this.label4);
            this.Name = "ScalarResultMappingEditor";
            this.Size = new System.Drawing.Size(627, 57);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbPersistVariable;
        private System.Windows.Forms.ComboBox cbVariableName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbXMLNone;
        private System.Windows.Forms.RadioButton rbXMLAttribute;
        private System.Windows.Forms.RadioButton rbXMLElement;
        private System.Windows.Forms.Label label4;
    }
}
