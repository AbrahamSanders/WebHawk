namespace UBoat.WebHawk.UI.StepEditors.DatabaseEditors
{
    partial class TableResultMappingEditor
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
            this.btnAddTableResult = new System.Windows.Forms.Button();
            this.olvTableResults = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnTableResultColumnName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnTableResultStateVariable = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnTableResultXMLOutputMode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnTableResultPersistenceMode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnTableResultDelete = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cbPersistList = new System.Windows.Forms.CheckBox();
            this.cbIncludeInXML = new System.Windows.Forms.CheckBox();
            this.cbListName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtObjectClassName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.olvTableResults)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddTableResult
            // 
            this.btnAddTableResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTableResult.BackgroundImage = global::UBoat.WebHawk.UI.Properties.Resources.Add;
            this.btnAddTableResult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddTableResult.Location = new System.Drawing.Point(611, 172);
            this.btnAddTableResult.Name = "btnAddTableResult";
            this.btnAddTableResult.Size = new System.Drawing.Size(31, 32);
            this.btnAddTableResult.TabIndex = 38;
            this.btnAddTableResult.UseVisualStyleBackColor = true;
            this.btnAddTableResult.Click += new System.EventHandler(this.btnAddTableResult_Click);
            // 
            // olvTableResults
            // 
            this.olvTableResults.AllColumns.Add(this.olvColumnTableResultColumnName);
            this.olvTableResults.AllColumns.Add(this.olvColumnTableResultStateVariable);
            this.olvTableResults.AllColumns.Add(this.olvColumnTableResultXMLOutputMode);
            this.olvTableResults.AllColumns.Add(this.olvColumnTableResultPersistenceMode);
            this.olvTableResults.AllColumns.Add(this.olvColumnTableResultDelete);
            this.olvTableResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvTableResults.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.olvTableResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnTableResultColumnName,
            this.olvColumnTableResultStateVariable,
            this.olvColumnTableResultXMLOutputMode,
            this.olvColumnTableResultPersistenceMode,
            this.olvColumnTableResultDelete});
            this.olvTableResults.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvTableResults.EmptyListMsg = "No Columns Added.";
            this.olvTableResults.FullRowSelect = true;
            this.olvTableResults.Location = new System.Drawing.Point(0, 0);
            this.olvTableResults.Name = "olvTableResults";
            this.olvTableResults.ShowGroups = false;
            this.olvTableResults.Size = new System.Drawing.Size(642, 166);
            this.olvTableResults.TabIndex = 37;
            this.olvTableResults.UseCompatibleStateImageBehavior = false;
            this.olvTableResults.UseHyperlinks = true;
            this.olvTableResults.View = System.Windows.Forms.View.Details;
            this.olvTableResults.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.olvTableResults_CellEditFinishing);
            this.olvTableResults.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.olvTableResults_CellEditStarting);
            this.olvTableResults.HyperlinkClicked += new System.EventHandler<BrightIdeasSoftware.HyperlinkClickedEventArgs>(this.olvTableResults_HyperlinkClicked);
            // 
            // olvColumnTableResultColumnName
            // 
            this.olvColumnTableResultColumnName.AspectName = "ColumnName";
            this.olvColumnTableResultColumnName.Groupable = false;
            this.olvColumnTableResultColumnName.Hideable = false;
            this.olvColumnTableResultColumnName.Searchable = false;
            this.olvColumnTableResultColumnName.Sortable = false;
            this.olvColumnTableResultColumnName.Text = "Column Name";
            this.olvColumnTableResultColumnName.UseFiltering = false;
            this.olvColumnTableResultColumnName.Width = 182;
            // 
            // olvColumnTableResultStateVariable
            // 
            this.olvColumnTableResultStateVariable.AspectName = "StateVariable";
            this.olvColumnTableResultStateVariable.Groupable = false;
            this.olvColumnTableResultStateVariable.Hideable = false;
            this.olvColumnTableResultStateVariable.Searchable = false;
            this.olvColumnTableResultStateVariable.Sortable = false;
            this.olvColumnTableResultStateVariable.Text = "State Variable";
            this.olvColumnTableResultStateVariable.UseFiltering = false;
            this.olvColumnTableResultStateVariable.Width = 184;
            // 
            // olvColumnTableResultXMLOutputMode
            // 
            this.olvColumnTableResultXMLOutputMode.AspectName = "XMLFieldOutputMode";
            this.olvColumnTableResultXMLOutputMode.Groupable = false;
            this.olvColumnTableResultXMLOutputMode.Hideable = false;
            this.olvColumnTableResultXMLOutputMode.Searchable = false;
            this.olvColumnTableResultXMLOutputMode.Sortable = false;
            this.olvColumnTableResultXMLOutputMode.Text = "XML Output Mode";
            this.olvColumnTableResultXMLOutputMode.UseFiltering = false;
            this.olvColumnTableResultXMLOutputMode.Width = 104;
            // 
            // olvColumnTableResultPersistenceMode
            // 
            this.olvColumnTableResultPersistenceMode.AspectName = "PersistenceMode";
            this.olvColumnTableResultPersistenceMode.Groupable = false;
            this.olvColumnTableResultPersistenceMode.Hideable = false;
            this.olvColumnTableResultPersistenceMode.Searchable = false;
            this.olvColumnTableResultPersistenceMode.Sortable = false;
            this.olvColumnTableResultPersistenceMode.Text = "Persistence Mode";
            this.olvColumnTableResultPersistenceMode.UseFiltering = false;
            this.olvColumnTableResultPersistenceMode.Width = 101;
            // 
            // olvColumnTableResultDelete
            // 
            this.olvColumnTableResultDelete.Groupable = false;
            this.olvColumnTableResultDelete.Hideable = false;
            this.olvColumnTableResultDelete.Hyperlink = true;
            this.olvColumnTableResultDelete.IsEditable = false;
            this.olvColumnTableResultDelete.Searchable = false;
            this.olvColumnTableResultDelete.Sortable = false;
            this.olvColumnTableResultDelete.Text = "";
            this.olvColumnTableResultDelete.UseFiltering = false;
            // 
            // cbPersistList
            // 
            this.cbPersistList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbPersistList.AutoSize = true;
            this.cbPersistList.Location = new System.Drawing.Point(103, 225);
            this.cbPersistList.Name = "cbPersistList";
            this.cbPersistList.Size = new System.Drawing.Size(57, 17);
            this.cbPersistList.TabIndex = 36;
            this.cbPersistList.Text = "Persist";
            this.cbPersistList.UseVisualStyleBackColor = true;
            // 
            // cbIncludeInXML
            // 
            this.cbIncludeInXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbIncludeInXML.AutoSize = true;
            this.cbIncludeInXML.Location = new System.Drawing.Point(166, 225);
            this.cbIncludeInXML.Name = "cbIncludeInXML";
            this.cbIncludeInXML.Size = new System.Drawing.Size(98, 17);
            this.cbIncludeInXML.TabIndex = 35;
            this.cbIncludeInXML.Text = "Include In XML";
            this.cbIncludeInXML.UseVisualStyleBackColor = true;
            // 
            // cbListName
            // 
            this.cbListName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbListName.FormattingEnabled = true;
            this.cbListName.Location = new System.Drawing.Point(103, 198);
            this.cbListName.Name = "cbListName";
            this.cbListName.Size = new System.Drawing.Size(264, 21);
            this.cbListName.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(-3, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "List Name:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-3, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Object Class Name:";
            // 
            // txtObjectClassName
            // 
            this.txtObjectClassName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtObjectClassName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObjectClassName.Location = new System.Drawing.Point(103, 172);
            this.txtObjectClassName.Name = "txtObjectClassName";
            this.txtObjectClassName.Size = new System.Drawing.Size(264, 20);
            this.txtObjectClassName.TabIndex = 31;
            // 
            // TableResultMappingEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddTableResult);
            this.Controls.Add(this.olvTableResults);
            this.Controls.Add(this.cbPersistList);
            this.Controls.Add(this.cbIncludeInXML);
            this.Controls.Add(this.cbListName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtObjectClassName);
            this.Name = "TableResultMappingEditor";
            this.Size = new System.Drawing.Size(642, 245);
            ((System.ComponentModel.ISupportInitialize)(this.olvTableResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddTableResult;
        private BrightIdeasSoftware.ObjectListView olvTableResults;
        private BrightIdeasSoftware.OLVColumn olvColumnTableResultColumnName;
        private BrightIdeasSoftware.OLVColumn olvColumnTableResultStateVariable;
        private BrightIdeasSoftware.OLVColumn olvColumnTableResultDelete;
        private System.Windows.Forms.CheckBox cbPersistList;
        private System.Windows.Forms.CheckBox cbIncludeInXML;
        private System.Windows.Forms.ComboBox cbListName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtObjectClassName;
        private BrightIdeasSoftware.OLVColumn olvColumnTableResultXMLOutputMode;
        private BrightIdeasSoftware.OLVColumn olvColumnTableResultPersistenceMode;
    }
}
