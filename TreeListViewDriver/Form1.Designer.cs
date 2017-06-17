namespace TreeListViewDriver
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
            this.components = new System.ComponentModel.Container();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.treeListView1 = new BrightIdeasSoftware.TreeListView();
            this.olvColumnFirstName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnLastName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnAge = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnLink = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(649, 412);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(568, 412);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // treeListView1
            // 
            this.treeListView1.AllColumns.Add(this.olvColumnFirstName);
            this.treeListView1.AllColumns.Add(this.olvColumnLastName);
            this.treeListView1.AllColumns.Add(this.olvColumnAge);
            this.treeListView1.AllColumns.Add(this.olvColumnLink);
            this.treeListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnFirstName,
            this.olvColumnLastName,
            this.olvColumnAge,
            this.olvColumnLink});
            this.treeListView1.FullRowSelect = true;
            this.treeListView1.IsSimpleDragSource = true;
            this.treeListView1.IsSimpleDropSink = true;
            this.treeListView1.Location = new System.Drawing.Point(12, 12);
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.OwnerDraw = true;
            this.treeListView1.ShowGroups = false;
            this.treeListView1.Size = new System.Drawing.Size(712, 394);
            this.treeListView1.TabIndex = 0;
            this.treeListView1.UseCompatibleStateImageBehavior = false;
            this.treeListView1.UseHyperlinks = true;
            this.treeListView1.View = System.Windows.Forms.View.Details;
            this.treeListView1.VirtualMode = true;
            this.treeListView1.HyperlinkClicked += new System.EventHandler<BrightIdeasSoftware.HyperlinkClickedEventArgs>(this.treeListView1_HyperlinkClicked);
            this.treeListView1.ModelCanDrop += new System.EventHandler<BrightIdeasSoftware.ModelDropEventArgs>(this.treeListView1_ModelCanDrop);
            this.treeListView1.ModelDropped += new System.EventHandler<BrightIdeasSoftware.ModelDropEventArgs>(this.treeListView1_ModelDropped);
            // 
            // olvColumnFirstName
            // 
            this.olvColumnFirstName.AspectName = "FirstName";
            this.olvColumnFirstName.FillsFreeSpace = true;
            this.olvColumnFirstName.Text = "First Name";
            this.olvColumnFirstName.Width = 120;
            // 
            // olvColumnLastName
            // 
            this.olvColumnLastName.AspectName = "LastName";
            this.olvColumnLastName.FillsFreeSpace = true;
            this.olvColumnLastName.Text = "Last Name";
            this.olvColumnLastName.Width = 150;
            // 
            // olvColumnAge
            // 
            this.olvColumnAge.AspectName = "Age";
            this.olvColumnAge.FillsFreeSpace = true;
            this.olvColumnAge.Text = "Age";
            this.olvColumnAge.Width = 127;
            // 
            // olvColumnLink
            // 
            this.olvColumnLink.Groupable = false;
            this.olvColumnLink.Hyperlink = true;
            this.olvColumnLink.IsEditable = false;
            this.olvColumnLink.Searchable = false;
            this.olvColumnLink.Sortable = false;
            this.olvColumnLink.Text = "";
            this.olvColumnLink.UseFiltering = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 447);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.treeListView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.TreeListView treeListView1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private BrightIdeasSoftware.OLVColumn olvColumnFirstName;
        private BrightIdeasSoftware.OLVColumn olvColumnLastName;
        private BrightIdeasSoftware.OLVColumn olvColumnAge;
        private BrightIdeasSoftware.OLVColumn olvColumnLink;
    }
}

