namespace UBoat.WebHawk.UI.StepEditors
{
    partial class GetValueSuggestor
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
            this.wbPreview = new System.Windows.Forms.WebBrowser();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.olvDetectedValues = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnValue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.olvDetectedValues)).BeginInit();
            this.SuspendLayout();
            // 
            // wbPreview
            // 
            this.wbPreview.AllowWebBrowserDrop = false;
            this.wbPreview.IsWebBrowserContextMenuEnabled = false;
            this.wbPreview.Location = new System.Drawing.Point(12, 321);
            this.wbPreview.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbPreview.Name = "wbPreview";
            this.wbPreview.ScriptErrorsSuppressed = true;
            this.wbPreview.Size = new System.Drawing.Size(50, 20);
            this.wbPreview.TabIndex = 1;
            this.wbPreview.Visible = false;
            // 
            // pbLoading
            // 
            this.pbLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbLoading.Image = global::UBoat.WebHawk.UI.Properties.Resources.loader;
            this.pbLoading.Location = new System.Drawing.Point(179, 136);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(63, 61);
            this.pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLoading.TabIndex = 2;
            this.pbLoading.TabStop = false;
            // 
            // olvDetectedValues
            // 
            this.olvDetectedValues.AllColumns.Add(this.olvColumnValue);
            this.olvDetectedValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvDetectedValues.CheckBoxes = true;
            this.olvDetectedValues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnValue});
            this.olvDetectedValues.EmptyListMsg = "No values could be detected.";
            this.olvDetectedValues.EmptyListMsgFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvDetectedValues.FullRowSelect = true;
            this.olvDetectedValues.Location = new System.Drawing.Point(12, 32);
            this.olvDetectedValues.Name = "olvDetectedValues";
            this.olvDetectedValues.ShowGroups = false;
            this.olvDetectedValues.Size = new System.Drawing.Size(388, 275);
            this.olvDetectedValues.TabIndex = 3;
            this.olvDetectedValues.UseCompatibleStateImageBehavior = false;
            this.olvDetectedValues.View = System.Windows.Forms.View.Details;
            this.olvDetectedValues.Visible = false;
            this.olvDetectedValues.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.olvDetectedValues_ItemChecked);
            // 
            // olvColumnValue
            // 
            this.olvColumnValue.AspectName = "";
            this.olvColumnValue.FillsFreeSpace = true;
            this.olvColumnValue.Groupable = false;
            this.olvColumnValue.Searchable = false;
            this.olvColumnValue.Text = "Value";
            this.olvColumnValue.UseFiltering = false;
            this.olvColumnValue.WordWrap = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(316, 313);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 28);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Enabled = false;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(226, 313);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(84, 28);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "The following values were detected:";
            // 
            // GetValueSuggestor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 353);
            this.Controls.Add(this.pbLoading);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.wbPreview);
            this.Controls.Add(this.olvDetectedValues);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GetValueSuggestor";
            this.Text = "Value Suggestor";
            this.Load += new System.EventHandler(this.GetValueSuggestor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.olvDetectedValues)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbPreview;
        private System.Windows.Forms.PictureBox pbLoading;
        private BrightIdeasSoftware.ObjectListView olvDetectedValues;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private BrightIdeasSoftware.OLVColumn olvColumnValue;

    }
}