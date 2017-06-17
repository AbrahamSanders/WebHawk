namespace UBoat.WebHawk.UI.StepEditors
{
    partial class SetValueStepEditor
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
            this.gbSetValue = new System.Windows.Forms.GroupBox();
            this.setValueSelector = new UBoat.WebHawk.UI.StepEditors.ElementAttributeSelector();
            this.label4 = new System.Windows.Forms.Label();
            this.setValueEditor = new UBoat.WebHawk.UI.StepEditors.OutputValueEditor();
            this.gbSetValue.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSetValue
            // 
            this.gbSetValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSetValue.Controls.Add(this.setValueEditor);
            this.gbSetValue.Controls.Add(this.label4);
            this.gbSetValue.Controls.Add(this.setValueSelector);
            this.gbSetValue.Location = new System.Drawing.Point(3, 112);
            this.gbSetValue.Name = "gbSetValue";
            this.gbSetValue.Size = new System.Drawing.Size(639, 204);
            this.gbSetValue.TabIndex = 1;
            this.gbSetValue.TabStop = false;
            this.gbSetValue.Text = "Set Value";
            // 
            // setValueSelector
            // 
            this.setValueSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.setValueSelector.Location = new System.Drawing.Point(96, 19);
            this.setValueSelector.Name = "setValueSelector";
            this.setValueSelector.Size = new System.Drawing.Size(537, 21);
            this.setValueSelector.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Value To Set:";
            // 
            // setValueEditor
            // 
            this.setValueEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.setValueEditor.Location = new System.Drawing.Point(9, 46);
            this.setValueEditor.Name = "setValueEditor";
            this.setValueEditor.Size = new System.Drawing.Size(624, 152);
            this.setValueEditor.TabIndex = 2;
            this.setValueEditor.TrimVariableValueWhitespace = false;
            this.setValueEditor.Value = "";
            // 
            // SetValueStepEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbSetValue);
            this.Name = "SetValueStepEditor";
            this.Size = new System.Drawing.Size(653, 324);
            this.Controls.SetChildIndex(this.gbSetValue, 0);
            this.gbSetValue.ResumeLayout(false);
            this.gbSetValue.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSetValue;
        private System.Windows.Forms.Label label4;
        private ElementAttributeSelector setValueSelector;
        private OutputValueEditor setValueEditor;
    }
}
