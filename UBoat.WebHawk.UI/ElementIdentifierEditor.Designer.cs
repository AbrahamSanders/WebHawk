namespace UBoat.WebHawk.UI
{
    partial class ElementIdentifierEditor
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
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.olvIdentifierPaths = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnPath = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnDelete = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.olvIdentifierPaths)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Edit Element Identifier";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackgroundImage = global::UBoat.WebHawk.UI.Properties.Resources.Add;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.Location = new System.Drawing.Point(465, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(33, 32);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UBoat.WebHawk.UI.Properties.Resources.MagnifyGlass;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // olvIdentifierPaths
            // 
            this.olvIdentifierPaths.AllColumns.Add(this.olvColumnPath);
            this.olvIdentifierPaths.AllColumns.Add(this.olvColumnDelete);
            this.olvIdentifierPaths.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvIdentifierPaths.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.olvIdentifierPaths.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnPath,
            this.olvColumnDelete});
            this.olvIdentifierPaths.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvIdentifierPaths.FullRowSelect = true;
            this.olvIdentifierPaths.Location = new System.Drawing.Point(3, 41);
            this.olvIdentifierPaths.Name = "olvIdentifierPaths";
            this.olvIdentifierPaths.ShowGroups = false;
            this.olvIdentifierPaths.Size = new System.Drawing.Size(495, 274);
            this.olvIdentifierPaths.SmallImageList = this.imageList1;
            this.olvIdentifierPaths.TabIndex = 0;
            this.olvIdentifierPaths.UseCompatibleStateImageBehavior = false;
            this.olvIdentifierPaths.UseHyperlinks = true;
            this.olvIdentifierPaths.View = System.Windows.Forms.View.Details;
            this.olvIdentifierPaths.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.olvIdentifierPaths_CellEditFinishing);
            this.olvIdentifierPaths.HyperlinkClicked += new System.EventHandler<BrightIdeasSoftware.HyperlinkClickedEventArgs>(this.olvIdentifierPaths_HyperlinkClicked);
            // 
            // olvColumnPath
            // 
            this.olvColumnPath.FillsFreeSpace = true;
            this.olvColumnPath.Searchable = false;
            this.olvColumnPath.Sortable = false;
            this.olvColumnPath.Text = "Path";
            // 
            // olvColumnDelete
            // 
            this.olvColumnDelete.Hyperlink = true;
            this.olvColumnDelete.IsEditable = false;
            this.olvColumnDelete.MaximumWidth = 50;
            this.olvColumnDelete.MinimumWidth = 50;
            this.olvColumnDelete.Searchable = false;
            this.olvColumnDelete.Sortable = false;
            this.olvColumnDelete.Text = "";
            this.olvColumnDelete.Width = 50;
            // 
            // ElementIdentifierEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.olvIdentifierPaths);
            this.Name = "ElementIdentifierEditor";
            this.Size = new System.Drawing.Size(501, 318);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.olvIdentifierPaths)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView olvIdentifierPaths;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private BrightIdeasSoftware.OLVColumn olvColumnPath;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnAdd;
        private BrightIdeasSoftware.OLVColumn olvColumnDelete;
    }
}
