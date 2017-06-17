namespace UBoat.WebHawk.UI.StepEditors
{
    partial class GetValueStepEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbXMLIntegration = new System.Windows.Forms.GroupBox();
            this.rbXMLNone = new System.Windows.Forms.RadioButton();
            this.rbXMLAttribute = new System.Windows.Forms.RadioButton();
            this.rbXMLElement = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtElementPath = new System.Windows.Forms.TextBox();
            this.gbElementScraping = new System.Windows.Forms.GroupBox();
            this.cbVariableName = new System.Windows.Forms.ComboBox();
            this.getValueSelector = new UBoat.WebHawk.UI.StepEditors.ElementAttributeSelector();
            this.gbDataNormalization = new System.Windows.Forms.GroupBox();
            this.btnSuggestValues = new System.Windows.Forms.Button();
            this.cbUseNormalizationDefault = new System.Windows.Forms.CheckBox();
            this.txtNormalizationDefault = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddNormalizationRule = new System.Windows.Forms.Button();
            this.olvDataNormalization = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnComparative = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnOriginal = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnReplacement = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnCaseSensitive = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnTrim = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnReplaceWholeOriginalValue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnDelete = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cbPersistVariable = new System.Windows.Forms.CheckBox();
            this.gbXMLIntegration.SuspendLayout();
            this.gbElementScraping.SuspendLayout();
            this.gbDataNormalization.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvDataNormalization)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "State Variable Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Value To Get:";
            // 
            // gbXMLIntegration
            // 
            this.gbXMLIntegration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbXMLIntegration.Controls.Add(this.rbXMLNone);
            this.gbXMLIntegration.Controls.Add(this.rbXMLAttribute);
            this.gbXMLIntegration.Controls.Add(this.rbXMLElement);
            this.gbXMLIntegration.Controls.Add(this.label4);
            this.gbXMLIntegration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbXMLIntegration.Location = new System.Drawing.Point(3, 198);
            this.gbXMLIntegration.Name = "gbXMLIntegration";
            this.gbXMLIntegration.Size = new System.Drawing.Size(639, 49);
            this.gbXMLIntegration.TabIndex = 12;
            this.gbXMLIntegration.TabStop = false;
            this.gbXMLIntegration.Text = "XML Integration";
            // 
            // rbXMLNone
            // 
            this.rbXMLNone.AutoSize = true;
            this.rbXMLNone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbXMLNone.Location = new System.Drawing.Point(271, 19);
            this.rbXMLNone.Name = "rbXMLNone";
            this.rbXMLNone.Size = new System.Drawing.Size(51, 17);
            this.rbXMLNone.TabIndex = 15;
            this.rbXMLNone.TabStop = true;
            this.rbXMLNone.Text = "None";
            this.rbXMLNone.UseVisualStyleBackColor = true;
            // 
            // rbXMLAttribute
            // 
            this.rbXMLAttribute.AutoSize = true;
            this.rbXMLAttribute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbXMLAttribute.Location = new System.Drawing.Point(195, 19);
            this.rbXMLAttribute.Name = "rbXMLAttribute";
            this.rbXMLAttribute.Size = new System.Drawing.Size(64, 17);
            this.rbXMLAttribute.TabIndex = 14;
            this.rbXMLAttribute.TabStop = true;
            this.rbXMLAttribute.Text = "Attribute";
            this.rbXMLAttribute.UseVisualStyleBackColor = true;
            // 
            // rbXMLElement
            // 
            this.rbXMLElement.AutoSize = true;
            this.rbXMLElement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbXMLElement.Location = new System.Drawing.Point(119, 19);
            this.rbXMLElement.Name = "rbXMLElement";
            this.rbXMLElement.Size = new System.Drawing.Size(63, 17);
            this.rbXMLElement.TabIndex = 13;
            this.rbXMLElement.TabStop = true;
            this.rbXMLElement.Text = "Element";
            this.rbXMLElement.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Field Output Mode:";
            // 
            // txtElementPath
            // 
            this.txtElementPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtElementPath.Enabled = false;
            this.txtElementPath.Location = new System.Drawing.Point(195, 153);
            this.txtElementPath.Name = "txtElementPath";
            this.txtElementPath.Size = new System.Drawing.Size(415, 20);
            this.txtElementPath.TabIndex = 4;
            // 
            // gbElementScraping
            // 
            this.gbElementScraping.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbElementScraping.Controls.Add(this.cbPersistVariable);
            this.gbElementScraping.Controls.Add(this.cbVariableName);
            this.gbElementScraping.Controls.Add(this.getValueSelector);
            this.gbElementScraping.Controls.Add(this.label1);
            this.gbElementScraping.Controls.Add(this.label3);
            this.gbElementScraping.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbElementScraping.Location = new System.Drawing.Point(3, 112);
            this.gbElementScraping.Name = "gbElementScraping";
            this.gbElementScraping.Size = new System.Drawing.Size(639, 80);
            this.gbElementScraping.TabIndex = 14;
            this.gbElementScraping.TabStop = false;
            this.gbElementScraping.Text = "Element Scraping";
            // 
            // cbVariableName
            // 
            this.cbVariableName.FormattingEnabled = true;
            this.cbVariableName.Location = new System.Drawing.Point(119, 19);
            this.cbVariableName.Name = "cbVariableName";
            this.cbVariableName.Size = new System.Drawing.Size(451, 21);
            this.cbVariableName.TabIndex = 15;
            // 
            // getValueSelector
            // 
            this.getValueSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.getValueSelector.Location = new System.Drawing.Point(119, 45);
            this.getValueSelector.Name = "getValueSelector";
            this.getValueSelector.Size = new System.Drawing.Size(514, 21);
            this.getValueSelector.TabIndex = 14;
            // 
            // gbDataNormalization
            // 
            this.gbDataNormalization.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDataNormalization.Controls.Add(this.btnSuggestValues);
            this.gbDataNormalization.Controls.Add(this.cbUseNormalizationDefault);
            this.gbDataNormalization.Controls.Add(this.txtNormalizationDefault);
            this.gbDataNormalization.Controls.Add(this.label5);
            this.gbDataNormalization.Controls.Add(this.btnAddNormalizationRule);
            this.gbDataNormalization.Controls.Add(this.olvDataNormalization);
            this.gbDataNormalization.Location = new System.Drawing.Point(3, 253);
            this.gbDataNormalization.Name = "gbDataNormalization";
            this.gbDataNormalization.Size = new System.Drawing.Size(639, 239);
            this.gbDataNormalization.TabIndex = 15;
            this.gbDataNormalization.TabStop = false;
            this.gbDataNormalization.Text = "Data Normalization Rules";
            // 
            // btnSuggestValues
            // 
            this.btnSuggestValues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSuggestValues.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSuggestValues.Location = new System.Drawing.Point(605, 10);
            this.btnSuggestValues.Name = "btnSuggestValues";
            this.btnSuggestValues.Size = new System.Drawing.Size(28, 27);
            this.btnSuggestValues.TabIndex = 16;
            this.btnSuggestValues.Text = "...";
            this.btnSuggestValues.UseVisualStyleBackColor = true;
            this.btnSuggestValues.Click += new System.EventHandler(this.btnSuggestValues_Click);
            // 
            // cbUseNormalizationDefault
            // 
            this.cbUseNormalizationDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbUseNormalizationDefault.AutoSize = true;
            this.cbUseNormalizationDefault.Location = new System.Drawing.Point(9, 210);
            this.cbUseNormalizationDefault.Name = "cbUseNormalizationDefault";
            this.cbUseNormalizationDefault.Size = new System.Drawing.Size(119, 17);
            this.cbUseNormalizationDefault.TabIndex = 15;
            this.cbUseNormalizationDefault.Text = "Default substitution:";
            this.cbUseNormalizationDefault.UseVisualStyleBackColor = true;
            this.cbUseNormalizationDefault.CheckedChanged += new System.EventHandler(this.cbUseNormalizationDefault_CheckedChanged);
            // 
            // txtNormalizationDefault
            // 
            this.txtNormalizationDefault.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNormalizationDefault.Enabled = false;
            this.txtNormalizationDefault.Location = new System.Drawing.Point(134, 208);
            this.txtNormalizationDefault.Name = "txtNormalizationDefault";
            this.txtNormalizationDefault.Size = new System.Drawing.Size(499, 20);
            this.txtNormalizationDefault.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(476, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Specify substitutions for scraped values. These substitutions replace the origina" +
    "l value in the output.";
            // 
            // btnAddNormalizationRule
            // 
            this.btnAddNormalizationRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNormalizationRule.BackgroundImage = global::UBoat.WebHawk.UI.Properties.Resources.Add;
            this.btnAddNormalizationRule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddNormalizationRule.Location = new System.Drawing.Point(571, 10);
            this.btnAddNormalizationRule.Name = "btnAddNormalizationRule";
            this.btnAddNormalizationRule.Size = new System.Drawing.Size(28, 27);
            this.btnAddNormalizationRule.TabIndex = 4;
            this.btnAddNormalizationRule.UseVisualStyleBackColor = true;
            this.btnAddNormalizationRule.Click += new System.EventHandler(this.btnAddNormalizationRule_Click);
            // 
            // olvDataNormalization
            // 
            this.olvDataNormalization.AllColumns.Add(this.olvColumnComparative);
            this.olvDataNormalization.AllColumns.Add(this.olvColumnOriginal);
            this.olvDataNormalization.AllColumns.Add(this.olvColumnReplacement);
            this.olvDataNormalization.AllColumns.Add(this.olvColumnCaseSensitive);
            this.olvDataNormalization.AllColumns.Add(this.olvColumnTrim);
            this.olvDataNormalization.AllColumns.Add(this.olvColumnReplaceWholeOriginalValue);
            this.olvDataNormalization.AllColumns.Add(this.olvColumnDelete);
            this.olvDataNormalization.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvDataNormalization.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.olvDataNormalization.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnComparative,
            this.olvColumnOriginal,
            this.olvColumnReplacement,
            this.olvColumnCaseSensitive,
            this.olvColumnTrim,
            this.olvColumnReplaceWholeOriginalValue,
            this.olvColumnDelete});
            this.olvDataNormalization.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvDataNormalization.EmptyListMsg = "No substitutions have been specified.";
            this.olvDataNormalization.EmptyListMsgFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvDataNormalization.FullRowSelect = true;
            this.olvDataNormalization.Location = new System.Drawing.Point(9, 40);
            this.olvDataNormalization.Name = "olvDataNormalization";
            this.olvDataNormalization.ShowGroups = false;
            this.olvDataNormalization.Size = new System.Drawing.Size(624, 162);
            this.olvDataNormalization.TabIndex = 0;
            this.olvDataNormalization.UseCompatibleStateImageBehavior = false;
            this.olvDataNormalization.UseHyperlinks = true;
            this.olvDataNormalization.View = System.Windows.Forms.View.Details;
            this.olvDataNormalization.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.olvDataNormalization_CellEditFinishing);
            this.olvDataNormalization.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.olvDataNormalization_CellEditStarting);
            this.olvDataNormalization.HyperlinkClicked += new System.EventHandler<BrightIdeasSoftware.HyperlinkClickedEventArgs>(this.olvDataNormalization_HyperlinkClicked);
            // 
            // olvColumnComparative
            // 
            this.olvColumnComparative.AspectName = "Comparative";
            this.olvColumnComparative.Groupable = false;
            this.olvColumnComparative.Searchable = false;
            this.olvColumnComparative.Sortable = false;
            this.olvColumnComparative.Text = "Comparative";
            this.olvColumnComparative.UseFiltering = false;
            // 
            // olvColumnOriginal
            // 
            this.olvColumnOriginal.AspectName = "OriginalValue";
            this.olvColumnOriginal.FillsFreeSpace = true;
            this.olvColumnOriginal.Groupable = false;
            this.olvColumnOriginal.Searchable = false;
            this.olvColumnOriginal.Sortable = false;
            this.olvColumnOriginal.Text = "Original Value";
            this.olvColumnOriginal.UseFiltering = false;
            // 
            // olvColumnReplacement
            // 
            this.olvColumnReplacement.AspectName = "ReplacementValue";
            this.olvColumnReplacement.FillsFreeSpace = true;
            this.olvColumnReplacement.Groupable = false;
            this.olvColumnReplacement.Searchable = false;
            this.olvColumnReplacement.Sortable = false;
            this.olvColumnReplacement.Text = "Replacement Value";
            this.olvColumnReplacement.UseFiltering = false;
            // 
            // olvColumnCaseSensitive
            // 
            this.olvColumnCaseSensitive.AspectName = "CaseSensitive";
            this.olvColumnCaseSensitive.CheckBoxes = true;
            this.olvColumnCaseSensitive.Groupable = false;
            this.olvColumnCaseSensitive.Searchable = false;
            this.olvColumnCaseSensitive.Sortable = false;
            this.olvColumnCaseSensitive.Text = "Case Sensitive";
            this.olvColumnCaseSensitive.UseFiltering = false;
            // 
            // olvColumnTrim
            // 
            this.olvColumnTrim.AspectName = "Trim";
            this.olvColumnTrim.CheckBoxes = true;
            this.olvColumnTrim.Groupable = false;
            this.olvColumnTrim.Searchable = false;
            this.olvColumnTrim.Sortable = false;
            this.olvColumnTrim.Text = "Trim Whitespace";
            this.olvColumnTrim.UseFiltering = false;
            // 
            // olvColumnReplaceWholeOriginalValue
            // 
            this.olvColumnReplaceWholeOriginalValue.AspectName = "ReplaceWholeOriginalValue";
            this.olvColumnReplaceWholeOriginalValue.CheckBoxes = true;
            this.olvColumnReplaceWholeOriginalValue.Groupable = false;
            this.olvColumnReplaceWholeOriginalValue.Searchable = false;
            this.olvColumnReplaceWholeOriginalValue.Sortable = false;
            this.olvColumnReplaceWholeOriginalValue.Text = "Replace Whole Original Value";
            this.olvColumnReplaceWholeOriginalValue.UseFiltering = false;
            // 
            // olvColumnDelete
            // 
            this.olvColumnDelete.Groupable = false;
            this.olvColumnDelete.Hyperlink = true;
            this.olvColumnDelete.IsEditable = false;
            this.olvColumnDelete.Searchable = false;
            this.olvColumnDelete.ShowTextInHeader = false;
            this.olvColumnDelete.Sortable = false;
            this.olvColumnDelete.Text = "";
            this.olvColumnDelete.UseFiltering = false;
            // 
            // cbPersistVariable
            // 
            this.cbPersistVariable.AutoSize = true;
            this.cbPersistVariable.Location = new System.Drawing.Point(576, 21);
            this.cbPersistVariable.Name = "cbPersistVariable";
            this.cbPersistVariable.Size = new System.Drawing.Size(57, 17);
            this.cbPersistVariable.TabIndex = 16;
            this.cbPersistVariable.Text = "Persist";
            this.cbPersistVariable.UseVisualStyleBackColor = true;
            // 
            // GetValueStepEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbDataNormalization);
            this.Controls.Add(this.gbElementScraping);
            this.Controls.Add(this.gbXMLIntegration);
            this.Name = "GetValueStepEditor";
            this.Size = new System.Drawing.Size(656, 495);
            this.Controls.SetChildIndex(this.gbXMLIntegration, 0);
            this.Controls.SetChildIndex(this.gbElementScraping, 0);
            this.Controls.SetChildIndex(this.gbDataNormalization, 0);
            this.gbXMLIntegration.ResumeLayout(false);
            this.gbXMLIntegration.PerformLayout();
            this.gbElementScraping.ResumeLayout(false);
            this.gbElementScraping.PerformLayout();
            this.gbDataNormalization.ResumeLayout(false);
            this.gbDataNormalization.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvDataNormalization)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbXMLIntegration;
        private System.Windows.Forms.RadioButton rbXMLAttribute;
        private System.Windows.Forms.RadioButton rbXMLElement;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtElementPath;
        private System.Windows.Forms.GroupBox gbElementScraping;
        private System.Windows.Forms.GroupBox gbDataNormalization;
        private BrightIdeasSoftware.ObjectListView olvDataNormalization;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddNormalizationRule;
        private BrightIdeasSoftware.OLVColumn olvColumnOriginal;
        private BrightIdeasSoftware.OLVColumn olvColumnReplacement;
        private BrightIdeasSoftware.OLVColumn olvColumnCaseSensitive;
        private BrightIdeasSoftware.OLVColumn olvColumnDelete;
        private System.Windows.Forms.CheckBox cbUseNormalizationDefault;
        private System.Windows.Forms.TextBox txtNormalizationDefault;
        private BrightIdeasSoftware.OLVColumn olvColumnTrim;
        private BrightIdeasSoftware.OLVColumn olvColumnComparative;
        private System.Windows.Forms.Button btnSuggestValues;
        private ElementAttributeSelector getValueSelector;
        private System.Windows.Forms.ComboBox cbVariableName;
        private System.Windows.Forms.RadioButton rbXMLNone;
        private BrightIdeasSoftware.OLVColumn olvColumnReplaceWholeOriginalValue;
        private System.Windows.Forms.CheckBox cbPersistVariable;

    }
}
