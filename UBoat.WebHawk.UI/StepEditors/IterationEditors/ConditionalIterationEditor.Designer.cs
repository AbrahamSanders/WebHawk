namespace UBoat.WebHawk.UI.StepEditors.IterationEditors
{
    partial class ConditionalIterationEditor
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
            this.cbSkipInitialConditionCheck = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbSkipInitialConditionCheck
            // 
            this.cbSkipInitialConditionCheck.AutoSize = true;
            this.cbSkipInitialConditionCheck.Location = new System.Drawing.Point(3, 3);
            this.cbSkipInitialConditionCheck.Name = "cbSkipInitialConditionCheck";
            this.cbSkipInitialConditionCheck.Size = new System.Drawing.Size(152, 17);
            this.cbSkipInitialConditionCheck.TabIndex = 0;
            this.cbSkipInitialConditionCheck.Text = "Skip initial condition check";
            this.cbSkipInitialConditionCheck.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(482, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "* If enabled, the condition set on this Group Step will not be checked before ent" +
    "ering for the first time,\r\n  and will only be checked before subsequent iteratio" +
    "ns.";
            // 
            // ConditionalIterationEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSkipInitialConditionCheck);
            this.Name = "ConditionalIterationEditor";
            this.Size = new System.Drawing.Size(490, 65);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbSkipInitialConditionCheck;
        private System.Windows.Forms.Label label1;
    }
}
