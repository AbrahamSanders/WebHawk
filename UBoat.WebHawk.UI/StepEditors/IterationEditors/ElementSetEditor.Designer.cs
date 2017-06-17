namespace UBoat.WebHawk.UI.StepEditors.IterationEditors
{
    partial class ElementSetEditor
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.wbElementSet = new System.Windows.Forms.WebBrowser();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.EditorPanel = new System.Windows.Forms.Panel();
            this.btnSelectContainer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtElementSetContainer = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            this.EditorPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // wbElementSet
            // 
            this.wbElementSet.AllowWebBrowserDrop = false;
            this.wbElementSet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbElementSet.IsWebBrowserContextMenuEnabled = false;
            this.wbElementSet.Location = new System.Drawing.Point(12, 12);
            this.wbElementSet.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbElementSet.Name = "wbElementSet";
            this.wbElementSet.ScriptErrorsSuppressed = true;
            this.wbElementSet.Size = new System.Drawing.Size(894, 493);
            this.wbElementSet.TabIndex = 0;
            // 
            // pbLoading
            // 
            this.pbLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbLoading.Image = global::UBoat.WebHawk.UI.Properties.Resources.loader;
            this.pbLoading.Location = new System.Drawing.Point(429, 257);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(63, 61);
            this.pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLoading.TabIndex = 1;
            this.pbLoading.TabStop = false;
            // 
            // EditorPanel
            // 
            this.EditorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditorPanel.Controls.Add(this.btnSelectContainer);
            this.EditorPanel.Controls.Add(this.label2);
            this.EditorPanel.Controls.Add(this.txtElementSetContainer);
            this.EditorPanel.Controls.Add(this.wbElementSet);
            this.EditorPanel.Location = new System.Drawing.Point(0, 0);
            this.EditorPanel.Name = "EditorPanel";
            this.EditorPanel.Size = new System.Drawing.Size(918, 546);
            this.EditorPanel.TabIndex = 2;
            this.EditorPanel.Visible = false;
            // 
            // btnSelectContainer
            // 
            this.btnSelectContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectContainer.BackgroundImage = global::UBoat.WebHawk.UI.Properties.Resources.Pointer;
            this.btnSelectContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSelectContainer.Location = new System.Drawing.Point(875, 511);
            this.btnSelectContainer.Name = "btnSelectContainer";
            this.btnSelectContainer.Size = new System.Drawing.Size(31, 32);
            this.btnSelectContainer.TabIndex = 9;
            this.btnSelectContainer.UseVisualStyleBackColor = true;
            this.btnSelectContainer.Click += new System.EventHandler(this.btnSelectContainer_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 516);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Element Set Container:";
            // 
            // txtElementSetContainer
            // 
            this.txtElementSetContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtElementSetContainer.Enabled = false;
            this.txtElementSetContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtElementSetContainer.Location = new System.Drawing.Point(220, 513);
            this.txtElementSetContainer.Margin = new System.Windows.Forms.Padding(5);
            this.txtElementSetContainer.Name = "txtElementSetContainer";
            this.txtElementSetContainer.Size = new System.Drawing.Size(647, 26);
            this.txtElementSetContainer.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(822, 552);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 28);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Enabled = false;
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Location = new System.Drawing.Point(732, 552);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(84, 28);
            this.btnSelect.TabIndex = 10;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // ElementSetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 592);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.pbLoading);
            this.Controls.Add(this.EditorPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ElementSetEditor";
            this.Text = "Element Set Editor";
            this.Load += new System.EventHandler(this.ElementSetEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            this.EditorPanel.ResumeLayout(false);
            this.EditorPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbElementSet;
        private System.Windows.Forms.PictureBox pbLoading;
        private System.Windows.Forms.Panel EditorPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtElementSetContainer;
        private System.Windows.Forms.Button btnSelectContainer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSelect;
    }
}