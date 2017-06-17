namespace UBoat.WebHawk.UI.StepEditors.IterationEditors
{
    partial class DataSetIterationEditor
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
            this.cbListVariableList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbObjectClassList = new System.Windows.Forms.ComboBox();
            this.txtScopeName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbListVariableList
            // 
            this.cbListVariableList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbListVariableList.FormattingEnabled = true;
            this.cbListVariableList.Location = new System.Drawing.Point(91, 3);
            this.cbListVariableList.Name = "cbListVariableList";
            this.cbListVariableList.Size = new System.Drawing.Size(220, 21);
            this.cbListVariableList.TabIndex = 0;
            this.cbListVariableList.SelectedIndexChanged += new System.EventHandler(this.cbListVariableList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "List Variable:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Object Class:";
            // 
            // cbObjectClassList
            // 
            this.cbObjectClassList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbObjectClassList.FormattingEnabled = true;
            this.cbObjectClassList.Location = new System.Drawing.Point(91, 30);
            this.cbObjectClassList.Name = "cbObjectClassList";
            this.cbObjectClassList.Size = new System.Drawing.Size(220, 21);
            this.cbObjectClassList.TabIndex = 2;
            this.cbObjectClassList.SelectedIndexChanged += new System.EventHandler(this.cbObjectClassList_SelectedIndexChanged);
            // 
            // txtScopeName
            // 
            this.txtScopeName.Location = new System.Drawing.Point(91, 57);
            this.txtScopeName.Name = "txtScopeName";
            this.txtScopeName.Size = new System.Drawing.Size(220, 20);
            this.txtScopeName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Scope Name:";
            // 
            // DataSetIterationEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtScopeName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbObjectClassList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbListVariableList);
            this.Name = "DataSetIterationEditor";
            this.Size = new System.Drawing.Size(314, 83);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbListVariableList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbObjectClassList;
        private System.Windows.Forms.TextBox txtScopeName;
        private System.Windows.Forms.Label label3;
    }
}
