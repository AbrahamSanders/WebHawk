namespace UBoat.WebHawk.UI.StepEditors
{
    partial class ConnectionStringEditor
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
            this.gbConnectionProperties = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.olvConnectionProperties = new BrightIdeasSoftware.ObjectListView();
            this.txtConnectionStringPreview = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.olvColumnPropertyName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnPropertyValue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.gbConnectionProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvConnectionProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // gbConnectionProperties
            // 
            this.gbConnectionProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbConnectionProperties.Controls.Add(this.label1);
            this.gbConnectionProperties.Controls.Add(this.txtConnectionStringPreview);
            this.gbConnectionProperties.Controls.Add(this.olvConnectionProperties);
            this.gbConnectionProperties.Location = new System.Drawing.Point(12, 12);
            this.gbConnectionProperties.Name = "gbConnectionProperties";
            this.gbConnectionProperties.Size = new System.Drawing.Size(522, 242);
            this.gbConnectionProperties.TabIndex = 0;
            this.gbConnectionProperties.TabStop = false;
            this.gbConnectionProperties.Text = "Connection Properties";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(459, 260);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(378, 260);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // olvConnectionProperties
            // 
            this.olvConnectionProperties.AllColumns.Add(this.olvColumnPropertyName);
            this.olvConnectionProperties.AllColumns.Add(this.olvColumnPropertyValue);
            this.olvConnectionProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvConnectionProperties.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.olvConnectionProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnPropertyName,
            this.olvColumnPropertyValue});
            this.olvConnectionProperties.FullRowSelect = true;
            this.olvConnectionProperties.Location = new System.Drawing.Point(6, 19);
            this.olvConnectionProperties.Name = "olvConnectionProperties";
            this.olvConnectionProperties.ShowGroups = false;
            this.olvConnectionProperties.Size = new System.Drawing.Size(510, 178);
            this.olvConnectionProperties.TabIndex = 0;
            this.olvConnectionProperties.UseCompatibleStateImageBehavior = false;
            this.olvConnectionProperties.View = System.Windows.Forms.View.Details;
            this.olvConnectionProperties.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.olvConnectionProperties_CellEditFinishing);
            // 
            // txtConnectionStringPreview
            // 
            this.txtConnectionStringPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConnectionStringPreview.Location = new System.Drawing.Point(6, 216);
            this.txtConnectionStringPreview.Name = "txtConnectionStringPreview";
            this.txtConnectionStringPreview.ReadOnly = true;
            this.txtConnectionStringPreview.Size = new System.Drawing.Size(510, 20);
            this.txtConnectionStringPreview.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Preview:";
            // 
            // olvColumnPropertyName
            // 
            this.olvColumnPropertyName.Groupable = false;
            this.olvColumnPropertyName.Hideable = false;
            this.olvColumnPropertyName.IsEditable = false;
            this.olvColumnPropertyName.Searchable = false;
            this.olvColumnPropertyName.Sortable = false;
            this.olvColumnPropertyName.Text = "Property";
            this.olvColumnPropertyName.UseFiltering = false;
            // 
            // olvColumnPropertyValue
            // 
            this.olvColumnPropertyValue.FillsFreeSpace = true;
            this.olvColumnPropertyValue.Groupable = false;
            this.olvColumnPropertyValue.Hideable = false;
            this.olvColumnPropertyValue.Searchable = false;
            this.olvColumnPropertyValue.Sortable = false;
            this.olvColumnPropertyValue.Text = "Value";
            this.olvColumnPropertyValue.UseFiltering = false;
            // 
            // ConnectionStringEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 295);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbConnectionProperties);
            this.MinimizeBox = false;
            this.Name = "ConnectionStringEditor";
            this.Text = "Connection String Builder";
            this.gbConnectionProperties.ResumeLayout(false);
            this.gbConnectionProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvConnectionProperties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbConnectionProperties;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConnectionStringPreview;
        private BrightIdeasSoftware.ObjectListView olvConnectionProperties;
        private BrightIdeasSoftware.OLVColumn olvColumnPropertyName;
        private BrightIdeasSoftware.OLVColumn olvColumnPropertyValue;
    }
}