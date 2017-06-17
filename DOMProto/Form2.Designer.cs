namespace DOMProto
{
    partial class Form2
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnAbsolute = new System.Windows.Forms.Button();
            this.btnRelative = new System.Windows.Forms.Button();
            this.btnRemoveSelector = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnParent = new System.Windows.Forms.Button();
            this.olvElementIdentifiers = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnTagName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnPrimaryIdentifier = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnEdit = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnDelete = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.gbBrowser = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnBrowserVersion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvElementIdentifiers)).BeginInit();
            this.gbBrowser.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnBrowserVersion);
            this.splitContainer1.Panel1.Controls.Add(this.btnAbsolute);
            this.splitContainer1.Panel1.Controls.Add(this.btnRelative);
            this.splitContainer1.Panel1.Controls.Add(this.btnRemoveSelector);
            this.splitContainer1.Panel1.Controls.Add(this.btnAdd);
            this.splitContainer1.Panel1.Controls.Add(this.btnParent);
            this.splitContainer1.Panel1.Controls.Add(this.olvElementIdentifiers);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbBrowser);
            this.splitContainer1.Size = new System.Drawing.Size(835, 467);
            this.splitContainer1.SplitterDistance = 213;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnAbsolute
            // 
            this.btnAbsolute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAbsolute.Enabled = false;
            this.btnAbsolute.Location = new System.Drawing.Point(279, 182);
            this.btnAbsolute.Name = "btnAbsolute";
            this.btnAbsolute.Size = new System.Drawing.Size(75, 23);
            this.btnAbsolute.TabIndex = 6;
            this.btnAbsolute.Text = "Absolute";
            this.btnAbsolute.UseVisualStyleBackColor = true;
            this.btnAbsolute.Click += new System.EventHandler(this.btnAbsolute_Click);
            // 
            // btnRelative
            // 
            this.btnRelative.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRelative.Enabled = false;
            this.btnRelative.Location = new System.Drawing.Point(198, 182);
            this.btnRelative.Name = "btnRelative";
            this.btnRelative.Size = new System.Drawing.Size(75, 23);
            this.btnRelative.TabIndex = 5;
            this.btnRelative.Text = "Relative";
            this.btnRelative.UseVisualStyleBackColor = true;
            this.btnRelative.Click += new System.EventHandler(this.btnRelative_Click);
            // 
            // btnRemoveSelector
            // 
            this.btnRemoveSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveSelector.Enabled = false;
            this.btnRemoveSelector.Location = new System.Drawing.Point(93, 182);
            this.btnRemoveSelector.Name = "btnRemoveSelector";
            this.btnRemoveSelector.Size = new System.Drawing.Size(99, 23);
            this.btnRemoveSelector.TabIndex = 4;
            this.btnRemoveSelector.Text = "Remove Selector";
            this.btnRemoveSelector.UseVisualStyleBackColor = true;
            this.btnRemoveSelector.Click += new System.EventHandler(this.btnRemoveSelector_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(791, 182);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(30, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnParent
            // 
            this.btnParent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnParent.Enabled = false;
            this.btnParent.Location = new System.Drawing.Point(12, 182);
            this.btnParent.Name = "btnParent";
            this.btnParent.Size = new System.Drawing.Size(75, 23);
            this.btnParent.TabIndex = 1;
            this.btnParent.Text = "Parent";
            this.btnParent.UseVisualStyleBackColor = true;
            this.btnParent.Click += new System.EventHandler(this.btnParent_Click);
            // 
            // olvElementIdentifiers
            // 
            this.olvElementIdentifiers.AllColumns.Add(this.olvColumnTagName);
            this.olvElementIdentifiers.AllColumns.Add(this.olvColumnPrimaryIdentifier);
            this.olvElementIdentifiers.AllColumns.Add(this.olvColumnEdit);
            this.olvElementIdentifiers.AllColumns.Add(this.olvColumnDelete);
            this.olvElementIdentifiers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvElementIdentifiers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnTagName,
            this.olvColumnPrimaryIdentifier,
            this.olvColumnEdit,
            this.olvColumnDelete});
            this.olvElementIdentifiers.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvElementIdentifiers.FullRowSelect = true;
            this.olvElementIdentifiers.Location = new System.Drawing.Point(12, 12);
            this.olvElementIdentifiers.Name = "olvElementIdentifiers";
            this.olvElementIdentifiers.ShowGroups = false;
            this.olvElementIdentifiers.Size = new System.Drawing.Size(809, 164);
            this.olvElementIdentifiers.TabIndex = 0;
            this.olvElementIdentifiers.UseCompatibleStateImageBehavior = false;
            this.olvElementIdentifiers.UseHyperlinks = true;
            this.olvElementIdentifiers.View = System.Windows.Forms.View.Details;
            this.olvElementIdentifiers.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.olvElementIdentifiers_CellClick);
            this.olvElementIdentifiers.HyperlinkClicked += new System.EventHandler<BrightIdeasSoftware.HyperlinkClickedEventArgs>(this.olvElementIdentifiers_HyperlinkClicked);
            this.olvElementIdentifiers.SelectionChanged += new System.EventHandler(this.olvElementIdentifiers_SelectionChanged);
            // 
            // olvColumnTagName
            // 
            this.olvColumnTagName.Searchable = false;
            this.olvColumnTagName.Sortable = false;
            this.olvColumnTagName.Text = "Tag";
            // 
            // olvColumnPrimaryIdentifier
            // 
            this.olvColumnPrimaryIdentifier.AspectName = "PrimaryIdentifier";
            this.olvColumnPrimaryIdentifier.FillsFreeSpace = true;
            this.olvColumnPrimaryIdentifier.Searchable = false;
            this.olvColumnPrimaryIdentifier.Sortable = false;
            this.olvColumnPrimaryIdentifier.Text = "Primary Identifier";
            // 
            // olvColumnEdit
            // 
            this.olvColumnEdit.Hyperlink = true;
            this.olvColumnEdit.Searchable = false;
            this.olvColumnEdit.Sortable = false;
            this.olvColumnEdit.Text = "";
            // 
            // olvColumnDelete
            // 
            this.olvColumnDelete.Hyperlink = true;
            this.olvColumnDelete.Searchable = false;
            this.olvColumnDelete.Sortable = false;
            this.olvColumnDelete.Text = "";
            // 
            // gbBrowser
            // 
            this.gbBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBrowser.Controls.Add(this.webBrowser1);
            this.gbBrowser.Location = new System.Drawing.Point(3, 3);
            this.gbBrowser.Name = "gbBrowser";
            this.gbBrowser.Size = new System.Drawing.Size(827, 242);
            this.gbBrowser.TabIndex = 0;
            this.gbBrowser.TabStop = false;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 16);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(821, 223);
            this.webBrowser1.TabIndex = 0;
            // 
            // btnBrowserVersion
            // 
            this.btnBrowserVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowserVersion.Location = new System.Drawing.Point(683, 182);
            this.btnBrowserVersion.Name = "btnBrowserVersion";
            this.btnBrowserVersion.Size = new System.Drawing.Size(102, 23);
            this.btnBrowserVersion.TabIndex = 7;
            this.btnBrowserVersion.Text = "Browser Version";
            this.btnBrowserVersion.UseVisualStyleBackColor = true;
            this.btnBrowserVersion.Click += new System.EventHandler(this.btnBrowserVersion_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 467);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvElementIdentifiers)).EndInit();
            this.gbBrowser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnParent;
        private BrightIdeasSoftware.ObjectListView olvElementIdentifiers;
        private System.Windows.Forms.GroupBox gbBrowser;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private BrightIdeasSoftware.OLVColumn olvColumnPrimaryIdentifier;
        private BrightIdeasSoftware.OLVColumn olvColumnEdit;
        private System.Windows.Forms.Button btnRemoveSelector;
        private BrightIdeasSoftware.OLVColumn olvColumnDelete;
        private BrightIdeasSoftware.OLVColumn olvColumnTagName;
        private System.Windows.Forms.Button btnRelative;
        private System.Windows.Forms.Button btnAbsolute;
        private System.Windows.Forms.Button btnBrowserVersion;

    }
}