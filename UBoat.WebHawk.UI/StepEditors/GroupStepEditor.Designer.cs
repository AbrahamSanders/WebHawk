namespace UBoat.WebHawk.UI.StepEditors
{
    partial class GroupStepEditor
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
            this.cbIteration = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbIterationEditor = new System.Windows.Forms.GroupBox();
            this.pbIteration = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbIteration)).BeginInit();
            this.SuspendLayout();
            // 
            // cbIteration
            // 
            this.cbIteration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbIteration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIteration.FormattingEnabled = true;
            this.cbIteration.Location = new System.Drawing.Point(3, 31);
            this.cbIteration.Name = "cbIteration";
            this.cbIteration.Size = new System.Drawing.Size(398, 21);
            this.cbIteration.TabIndex = 0;
            this.cbIteration.SelectedIndexChanged += new System.EventHandler(this.cbIteration_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Iteration:";
            // 
            // gbIterationEditor
            // 
            this.gbIterationEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbIterationEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbIterationEditor.Location = new System.Drawing.Point(3, 58);
            this.gbIterationEditor.Name = "gbIterationEditor";
            this.gbIterationEditor.Size = new System.Drawing.Size(398, 227);
            this.gbIterationEditor.TabIndex = 2;
            this.gbIterationEditor.TabStop = false;
            // 
            // pbIteration
            // 
            this.pbIteration.Image = global::UBoat.WebHawk.UI.Properties.Resources.Iteration;
            this.pbIteration.Location = new System.Drawing.Point(3, 3);
            this.pbIteration.Name = "pbIteration";
            this.pbIteration.Size = new System.Drawing.Size(25, 25);
            this.pbIteration.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbIteration.TabIndex = 3;
            this.pbIteration.TabStop = false;
            // 
            // GroupStepEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbIteration);
            this.Controls.Add(this.gbIterationEditor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbIteration);
            this.Name = "GroupStepEditor";
            this.Size = new System.Drawing.Size(404, 288);
            ((System.ComponentModel.ISupportInitialize)(this.pbIteration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbIteration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbIterationEditor;
        private System.Windows.Forms.PictureBox pbIteration;
    }
}
