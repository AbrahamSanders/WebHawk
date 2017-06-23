namespace UBoat.WebHawk.UI.StepEditors
{
    partial class NavigateStepEditor
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
            this.urlEditor = new UBoat.WebHawk.UI.StepEditors.OutputValueEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.cbWaitType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL:";
            // 
            // urlEditor
            // 
            this.urlEditor.Location = new System.Drawing.Point(65, 3);
            this.urlEditor.Name = "urlEditor";
            this.urlEditor.Size = new System.Drawing.Size(610, 58);
            this.urlEditor.TabIndex = 2;
            this.urlEditor.TrimVariableValueWhitespace = false;
            this.urlEditor.Value = "http://";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Wait Until:";
            // 
            // cbWaitType
            // 
            this.cbWaitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWaitType.FormattingEnabled = true;
            this.cbWaitType.Location = new System.Drawing.Point(65, 67);
            this.cbWaitType.Name = "cbWaitType";
            this.cbWaitType.Size = new System.Drawing.Size(279, 21);
            this.cbWaitType.TabIndex = 4;
            // 
            // NavigateStepEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbWaitType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.urlEditor);
            this.Controls.Add(this.label1);
            this.Name = "NavigateStepEditor";
            this.Size = new System.Drawing.Size(678, 104);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private OutputValueEditor urlEditor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbWaitType;
    }
}
