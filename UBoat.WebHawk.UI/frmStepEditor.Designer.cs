namespace UBoat.WebHawk.UI
{
    partial class frmStepEditor
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
            this.gbExpressionBuilder = new System.Windows.Forms.GroupBox();
            this.btnRemoveCondition = new System.Windows.Forms.Button();
            this.panelExpressionBuilder = new System.Windows.Forms.Panel();
            this.cbCaseSensitive = new System.Windows.Forms.CheckBox();
            this.cbVariable = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbUseVariable = new System.Windows.Forms.CheckBox();
            this.cbComparative = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbDataType = new System.Windows.Forms.ComboBox();
            this.cbNegate = new System.Windows.Forms.CheckBox();
            this.btnAddCondition = new System.Windows.Forms.Button();
            this.cbCondition = new System.Windows.Forms.ComboBox();
            this.tlvCondition = new BrightIdeasSoftware.TreeListView();
            this.olvColumnConditional = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnVariable = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnComparative = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnValue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageListConditions = new System.Windows.Forms.ImageList(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpStep = new System.Windows.Forms.TabPage();
            this.tpCondition = new System.Windows.Forms.TabPage();
            this.tpBehavior = new System.Windows.Forms.TabPage();
            this.gbFailureBehavior = new System.Windows.Forms.GroupBox();
            this.cbStepFailureScope = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.veValue = new UBoat.WebHawk.UI.ValueEntry();
            this.gbExpressionBuilder.SuspendLayout();
            this.panelExpressionBuilder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvCondition)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpCondition.SuspendLayout();
            this.tpBehavior.SuspendLayout();
            this.gbFailureBehavior.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbExpressionBuilder
            // 
            this.gbExpressionBuilder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbExpressionBuilder.Controls.Add(this.btnRemoveCondition);
            this.gbExpressionBuilder.Controls.Add(this.panelExpressionBuilder);
            this.gbExpressionBuilder.Controls.Add(this.btnAddCondition);
            this.gbExpressionBuilder.Controls.Add(this.cbCondition);
            this.gbExpressionBuilder.Location = new System.Drawing.Point(6, 325);
            this.gbExpressionBuilder.Name = "gbExpressionBuilder";
            this.gbExpressionBuilder.Size = new System.Drawing.Size(671, 180);
            this.gbExpressionBuilder.TabIndex = 17;
            this.gbExpressionBuilder.TabStop = false;
            this.gbExpressionBuilder.Text = "Add Condition";
            // 
            // btnRemoveCondition
            // 
            this.btnRemoveCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveCondition.BackgroundImage = global::UBoat.WebHawk.UI.Properties.Resources.Delete;
            this.btnRemoveCondition.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveCondition.Enabled = false;
            this.btnRemoveCondition.Location = new System.Drawing.Point(635, 59);
            this.btnRemoveCondition.Name = "btnRemoveCondition";
            this.btnRemoveCondition.Size = new System.Drawing.Size(30, 30);
            this.btnRemoveCondition.TabIndex = 20;
            this.btnRemoveCondition.UseVisualStyleBackColor = true;
            this.btnRemoveCondition.Click += new System.EventHandler(this.btnRemoveCondition_Click);
            // 
            // panelExpressionBuilder
            // 
            this.panelExpressionBuilder.Controls.Add(this.cbCaseSensitive);
            this.panelExpressionBuilder.Controls.Add(this.cbVariable);
            this.panelExpressionBuilder.Controls.Add(this.label3);
            this.panelExpressionBuilder.Controls.Add(this.label2);
            this.panelExpressionBuilder.Controls.Add(this.cbUseVariable);
            this.panelExpressionBuilder.Controls.Add(this.cbComparative);
            this.panelExpressionBuilder.Controls.Add(this.veValue);
            this.panelExpressionBuilder.Controls.Add(this.label5);
            this.panelExpressionBuilder.Controls.Add(this.label4);
            this.panelExpressionBuilder.Controls.Add(this.cbDataType);
            this.panelExpressionBuilder.Controls.Add(this.cbNegate);
            this.panelExpressionBuilder.Enabled = false;
            this.panelExpressionBuilder.Location = new System.Drawing.Point(6, 23);
            this.panelExpressionBuilder.Name = "panelExpressionBuilder";
            this.panelExpressionBuilder.Size = new System.Drawing.Size(552, 151);
            this.panelExpressionBuilder.TabIndex = 18;
            // 
            // cbCaseSensitive
            // 
            this.cbCaseSensitive.AutoSize = true;
            this.cbCaseSensitive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCaseSensitive.Location = new System.Drawing.Point(403, 41);
            this.cbCaseSensitive.Name = "cbCaseSensitive";
            this.cbCaseSensitive.Size = new System.Drawing.Size(117, 20);
            this.cbCaseSensitive.TabIndex = 17;
            this.cbCaseSensitive.Text = "Case Sensitive";
            this.cbCaseSensitive.UseVisualStyleBackColor = true;
            this.cbCaseSensitive.CheckedChanged += new System.EventHandler(this.cbCaseSensitive_CheckedChanged);
            // 
            // cbVariable
            // 
            this.cbVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariable.FormattingEnabled = true;
            this.cbVariable.Location = new System.Drawing.Point(124, 2);
            this.cbVariable.Name = "cbVariable";
            this.cbVariable.Size = new System.Drawing.Size(271, 21);
            this.cbVariable.TabIndex = 6;
            this.cbVariable.SelectedIndexChanged += new System.EventHandler(this.cbVariable_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Comparative:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Variable:";
            // 
            // cbUseVariable
            // 
            this.cbUseVariable.AutoSize = true;
            this.cbUseVariable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUseVariable.Location = new System.Drawing.Point(403, 114);
            this.cbUseVariable.Name = "cbUseVariable";
            this.cbUseVariable.Size = new System.Drawing.Size(106, 20);
            this.cbUseVariable.TabIndex = 10;
            this.cbUseVariable.Text = "Use Variable";
            this.cbUseVariable.UseVisualStyleBackColor = true;
            this.cbUseVariable.CheckedChanged += new System.EventHandler(this.cbUseVariable_CheckedChanged);
            // 
            // cbComparative
            // 
            this.cbComparative.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComparative.FormattingEnabled = true;
            this.cbComparative.Location = new System.Drawing.Point(124, 70);
            this.cbComparative.Name = "cbComparative";
            this.cbComparative.Size = new System.Drawing.Size(271, 21);
            this.cbComparative.TabIndex = 8;
            this.cbComparative.SelectedIndexChanged += new System.EventHandler(this.cbComparative_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Data Type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Value";
            // 
            // cbDataType
            // 
            this.cbDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataType.FormattingEnabled = true;
            this.cbDataType.Location = new System.Drawing.Point(124, 36);
            this.cbDataType.Name = "cbDataType";
            this.cbDataType.Size = new System.Drawing.Size(271, 21);
            this.cbDataType.TabIndex = 13;
            this.cbDataType.SelectedIndexChanged += new System.EventHandler(this.cbDataType_SelectedIndexChanged);
            // 
            // cbNegate
            // 
            this.cbNegate.AutoSize = true;
            this.cbNegate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNegate.Location = new System.Drawing.Point(403, 75);
            this.cbNegate.Name = "cbNegate";
            this.cbNegate.Size = new System.Drawing.Size(72, 20);
            this.cbNegate.TabIndex = 16;
            this.cbNegate.Text = "Negate";
            this.cbNegate.UseVisualStyleBackColor = true;
            this.cbNegate.CheckedChanged += new System.EventHandler(this.cbNegate_CheckedChanged);
            // 
            // btnAddCondition
            // 
            this.btnAddCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCondition.BackgroundImage = global::UBoat.WebHawk.UI.Properties.Resources.Add;
            this.btnAddCondition.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddCondition.Location = new System.Drawing.Point(635, 23);
            this.btnAddCondition.Name = "btnAddCondition";
            this.btnAddCondition.Size = new System.Drawing.Size(30, 30);
            this.btnAddCondition.TabIndex = 1;
            this.btnAddCondition.UseVisualStyleBackColor = true;
            this.btnAddCondition.Click += new System.EventHandler(this.btnAddCondition_Click);
            // 
            // cbCondition
            // 
            this.cbCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCondition.FormattingEnabled = true;
            this.cbCondition.Location = new System.Drawing.Point(564, 25);
            this.cbCondition.Name = "cbCondition";
            this.cbCondition.Size = new System.Drawing.Size(65, 21);
            this.cbCondition.TabIndex = 4;
            // 
            // tlvCondition
            // 
            this.tlvCondition.AllColumns.Add(this.olvColumnConditional);
            this.tlvCondition.AllColumns.Add(this.olvColumnVariable);
            this.tlvCondition.AllColumns.Add(this.olvColumnComparative);
            this.tlvCondition.AllColumns.Add(this.olvColumnValue);
            this.tlvCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlvCondition.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnConditional,
            this.olvColumnVariable,
            this.olvColumnComparative,
            this.olvColumnValue});
            this.tlvCondition.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlvCondition.EmptyListMsg = "This step has no condition defined and will always run.";
            this.tlvCondition.EmptyListMsgFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlvCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlvCondition.Location = new System.Drawing.Point(6, 6);
            this.tlvCondition.Name = "tlvCondition";
            this.tlvCondition.OwnerDraw = true;
            this.tlvCondition.ShowGroups = false;
            this.tlvCondition.Size = new System.Drawing.Size(671, 313);
            this.tlvCondition.SmallImageList = this.imageListConditions;
            this.tlvCondition.TabIndex = 0;
            this.tlvCondition.UseCompatibleStateImageBehavior = false;
            this.tlvCondition.UseHotItem = true;
            this.tlvCondition.View = System.Windows.Forms.View.Details;
            this.tlvCondition.VirtualMode = true;
            this.tlvCondition.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.tlvCondition_CellClick);
            // 
            // olvColumnConditional
            // 
            this.olvColumnConditional.FillsFreeSpace = true;
            this.olvColumnConditional.Text = "Conditional";
            // 
            // olvColumnVariable
            // 
            this.olvColumnVariable.FillsFreeSpace = true;
            this.olvColumnVariable.Text = "Variable";
            // 
            // olvColumnComparative
            // 
            this.olvColumnComparative.AspectName = "";
            this.olvColumnComparative.FillsFreeSpace = true;
            this.olvColumnComparative.Text = "Comparative";
            // 
            // olvColumnValue
            // 
            this.olvColumnValue.FillsFreeSpace = true;
            this.olvColumnValue.Text = "Value";
            // 
            // imageListConditions
            // 
            this.imageListConditions.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListConditions.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListConditions.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(529, 555);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 28);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(619, 555);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 28);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpStep);
            this.tabControl1.Controls.Add(this.tpCondition);
            this.tabControl1.Controls.Add(this.tpBehavior);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(691, 537);
            this.tabControl1.TabIndex = 4;
            // 
            // tpStep
            // 
            this.tpStep.Location = new System.Drawing.Point(4, 22);
            this.tpStep.Name = "tpStep";
            this.tpStep.Padding = new System.Windows.Forms.Padding(3);
            this.tpStep.Size = new System.Drawing.Size(683, 511);
            this.tpStep.TabIndex = 0;
            this.tpStep.Text = "Step";
            this.tpStep.UseVisualStyleBackColor = true;
            // 
            // tpCondition
            // 
            this.tpCondition.Controls.Add(this.gbExpressionBuilder);
            this.tpCondition.Controls.Add(this.tlvCondition);
            this.tpCondition.Location = new System.Drawing.Point(4, 22);
            this.tpCondition.Name = "tpCondition";
            this.tpCondition.Padding = new System.Windows.Forms.Padding(3);
            this.tpCondition.Size = new System.Drawing.Size(683, 511);
            this.tpCondition.TabIndex = 1;
            this.tpCondition.Text = "Condition";
            this.tpCondition.UseVisualStyleBackColor = true;
            // 
            // tpBehavior
            // 
            this.tpBehavior.Controls.Add(this.gbFailureBehavior);
            this.tpBehavior.Location = new System.Drawing.Point(4, 22);
            this.tpBehavior.Name = "tpBehavior";
            this.tpBehavior.Padding = new System.Windows.Forms.Padding(3);
            this.tpBehavior.Size = new System.Drawing.Size(683, 511);
            this.tpBehavior.TabIndex = 2;
            this.tpBehavior.Text = "Behavior";
            this.tpBehavior.UseVisualStyleBackColor = true;
            // 
            // gbFailureBehavior
            // 
            this.gbFailureBehavior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFailureBehavior.Controls.Add(this.cbStepFailureScope);
            this.gbFailureBehavior.Controls.Add(this.label1);
            this.gbFailureBehavior.Location = new System.Drawing.Point(6, 6);
            this.gbFailureBehavior.Name = "gbFailureBehavior";
            this.gbFailureBehavior.Size = new System.Drawing.Size(671, 166);
            this.gbFailureBehavior.TabIndex = 0;
            this.gbFailureBehavior.TabStop = false;
            this.gbFailureBehavior.Text = "Failure Behavior";
            // 
            // cbStepFailureScope
            // 
            this.cbStepFailureScope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStepFailureScope.FormattingEnabled = true;
            this.cbStepFailureScope.Location = new System.Drawing.Point(127, 22);
            this.cbStepFailureScope.Name = "cbStepFailureScope";
            this.cbStepFailureScope.Size = new System.Drawing.Size(182, 21);
            this.cbStepFailureScope.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "If step fails, fail current:";
            // 
            // veValue
            // 
            this.veValue.Location = new System.Drawing.Point(124, 106);
            this.veValue.Margin = new System.Windows.Forms.Padding(5);
            this.veValue.Name = "veValue";
            this.veValue.Size = new System.Drawing.Size(271, 28);
            this.veValue.TabIndex = 15;
            this.veValue.ValueChanged += new System.EventHandler<UBoat.WebHawk.UI.ValueEntryValueChangedEventArgs>(this.veValue_ValueChanged);
            // 
            // frmStepEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 590);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStepEditor";
            this.Text = "Step Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmStepEditor_FormClosing);
            this.gbExpressionBuilder.ResumeLayout(false);
            this.panelExpressionBuilder.ResumeLayout(false);
            this.panelExpressionBuilder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvCondition)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpCondition.ResumeLayout(false);
            this.tpBehavior.ResumeLayout(false);
            this.gbFailureBehavior.ResumeLayout(false);
            this.gbFailureBehavior.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private BrightIdeasSoftware.TreeListView tlvCondition;
        private BrightIdeasSoftware.OLVColumn olvColumnConditional;
        private BrightIdeasSoftware.OLVColumn olvColumnVariable;
        private BrightIdeasSoftware.OLVColumn olvColumnComparative;
        private BrightIdeasSoftware.OLVColumn olvColumnValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbUseVariable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbComparative;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbVariable;
        private System.Windows.Forms.ComboBox cbCondition;
        private System.Windows.Forms.Button btnAddCondition;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbDataType;
        private ValueEntry veValue;
        private System.Windows.Forms.CheckBox cbNegate;
        private System.Windows.Forms.GroupBox gbExpressionBuilder;
        private System.Windows.Forms.CheckBox cbCaseSensitive;
        private System.Windows.Forms.Panel panelExpressionBuilder;
        private System.Windows.Forms.Button btnRemoveCondition;
        private System.Windows.Forms.ImageList imageListConditions;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpStep;
        private System.Windows.Forms.TabPage tpCondition;
        private System.Windows.Forms.TabPage tpBehavior;
        private System.Windows.Forms.GroupBox gbFailureBehavior;
        private System.Windows.Forms.ComboBox cbStepFailureScope;
        private System.Windows.Forms.Label label1;
    }
}