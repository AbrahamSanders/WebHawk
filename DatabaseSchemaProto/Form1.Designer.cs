namespace DatabaseSchemaProto
{
    partial class Form1
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
            this.cbConnectionType = new System.Windows.Forms.ComboBox();
            this.txtConnString = new System.Windows.Forms.TextBox();
            this.cbMetadataType = new System.Windows.Forms.ComboBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.dgvMetadata = new System.Windows.Forms.DataGridView();
            this.btnCollections = new System.Windows.Forms.Button();
            this.btnRestrictions = new System.Windows.Forms.Button();
            this.btnDataSourceInformation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetadata)).BeginInit();
            this.SuspendLayout();
            // 
            // cbConnectionType
            // 
            this.cbConnectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConnectionType.FormattingEnabled = true;
            this.cbConnectionType.Location = new System.Drawing.Point(12, 12);
            this.cbConnectionType.Name = "cbConnectionType";
            this.cbConnectionType.Size = new System.Drawing.Size(121, 21);
            this.cbConnectionType.TabIndex = 0;
            this.cbConnectionType.SelectedIndexChanged += new System.EventHandler(this.cbConnectionType_SelectedIndexChanged);
            // 
            // txtConnString
            // 
            this.txtConnString.Location = new System.Drawing.Point(139, 12);
            this.txtConnString.Name = "txtConnString";
            this.txtConnString.Size = new System.Drawing.Size(597, 20);
            this.txtConnString.TabIndex = 1;
            // 
            // cbMetadataType
            // 
            this.cbMetadataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMetadataType.FormattingEnabled = true;
            this.cbMetadataType.Location = new System.Drawing.Point(12, 39);
            this.cbMetadataType.Name = "cbMetadataType";
            this.cbMetadataType.Size = new System.Drawing.Size(121, 21);
            this.cbMetadataType.TabIndex = 2;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(139, 37);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 3;
            this.btnGo.Text = "Go...";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // dgvMetadata
            // 
            this.dgvMetadata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMetadata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMetadata.Location = new System.Drawing.Point(12, 66);
            this.dgvMetadata.Name = "dgvMetadata";
            this.dgvMetadata.Size = new System.Drawing.Size(793, 413);
            this.dgvMetadata.TabIndex = 4;
            // 
            // btnCollections
            // 
            this.btnCollections.Location = new System.Drawing.Point(220, 37);
            this.btnCollections.Name = "btnCollections";
            this.btnCollections.Size = new System.Drawing.Size(75, 23);
            this.btnCollections.TabIndex = 5;
            this.btnCollections.Text = "Collections...";
            this.btnCollections.UseVisualStyleBackColor = true;
            this.btnCollections.Click += new System.EventHandler(this.btnCollections_Click);
            // 
            // btnRestrictions
            // 
            this.btnRestrictions.Location = new System.Drawing.Point(301, 37);
            this.btnRestrictions.Name = "btnRestrictions";
            this.btnRestrictions.Size = new System.Drawing.Size(81, 23);
            this.btnRestrictions.TabIndex = 6;
            this.btnRestrictions.Text = "Restrictions...";
            this.btnRestrictions.UseVisualStyleBackColor = true;
            this.btnRestrictions.Click += new System.EventHandler(this.btnRestrictions_Click);
            // 
            // btnDataSourceInformation
            // 
            this.btnDataSourceInformation.Location = new System.Drawing.Point(388, 37);
            this.btnDataSourceInformation.Name = "btnDataSourceInformation";
            this.btnDataSourceInformation.Size = new System.Drawing.Size(135, 23);
            this.btnDataSourceInformation.TabIndex = 7;
            this.btnDataSourceInformation.Text = "DataSourceInformation...";
            this.btnDataSourceInformation.UseVisualStyleBackColor = true;
            this.btnDataSourceInformation.Click += new System.EventHandler(this.btnDataSourceInformation_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 491);
            this.Controls.Add(this.btnDataSourceInformation);
            this.Controls.Add(this.btnRestrictions);
            this.Controls.Add(this.btnCollections);
            this.Controls.Add(this.dgvMetadata);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.cbMetadataType);
            this.Controls.Add(this.txtConnString);
            this.Controls.Add(this.cbConnectionType);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetadata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbConnectionType;
        private System.Windows.Forms.TextBox txtConnString;
        private System.Windows.Forms.ComboBox cbMetadataType;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.DataGridView dgvMetadata;
        private System.Windows.Forms.Button btnCollections;
        private System.Windows.Forms.Button btnRestrictions;
        private System.Windows.Forms.Button btnDataSourceInformation;
    }
}

