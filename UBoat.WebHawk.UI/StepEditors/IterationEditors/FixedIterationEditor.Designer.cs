namespace UBoat.WebHawk.UI.StepEditors.IterationEditors
{
    partial class FixedIterationEditor
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
            this.label2 = new System.Windows.Forms.Label();
            this.nudNumberOfIterations = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfIterations)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "#:";
            // 
            // nudNumberOfIterations
            // 
            this.nudNumberOfIterations.Location = new System.Drawing.Point(23, 3);
            this.nudNumberOfIterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumberOfIterations.Name = "nudNumberOfIterations";
            this.nudNumberOfIterations.Size = new System.Drawing.Size(91, 20);
            this.nudNumberOfIterations.TabIndex = 4;
            this.nudNumberOfIterations.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FixedIterationEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudNumberOfIterations);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FixedIterationEditor";
            this.Size = new System.Drawing.Size(117, 33);
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfIterations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudNumberOfIterations;

    }
}
