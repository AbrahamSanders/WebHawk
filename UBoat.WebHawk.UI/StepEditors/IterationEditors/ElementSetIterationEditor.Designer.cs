namespace UBoat.WebHawk.UI.StepEditors.IterationEditors
{
    partial class ElementSetIterationEditor
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtElementSetContainer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtObjectClassName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ipPollingTimeout = new UBoat.Utils.Controls.IntervalPicker();
            this.rbDynamicElement = new System.Windows.Forms.RadioButton();
            this.rbStaticElement = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtScopeName = new System.Windows.Forms.TextBox();
            this.cbListName = new System.Windows.Forms.ComboBox();
            this.cbIncludeInXML = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbPersistList = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(527, 0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(30, 22);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Element Set Container:";
            // 
            // txtElementSetContainer
            // 
            this.txtElementSetContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtElementSetContainer.Enabled = false;
            this.txtElementSetContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtElementSetContainer.Location = new System.Drawing.Point(127, 2);
            this.txtElementSetContainer.Name = "txtElementSetContainer";
            this.txtElementSetContainer.Size = new System.Drawing.Size(394, 20);
            this.txtElementSetContainer.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Object Class Name:";
            // 
            // txtObjectClassName
            // 
            this.txtObjectClassName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObjectClassName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObjectClassName.Location = new System.Drawing.Point(127, 79);
            this.txtObjectClassName.Name = "txtObjectClassName";
            this.txtObjectClassName.Size = new System.Drawing.Size(462, 20);
            this.txtObjectClassName.TabIndex = 5;
            this.txtObjectClassName.Leave += new System.EventHandler(this.txtObjectClassName_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 55);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Polling Timeout:";
            // 
            // ipPollingTimeout
            // 
            this.ipPollingTimeout.Location = new System.Drawing.Point(127, 51);
            this.ipPollingTimeout.Margin = new System.Windows.Forms.Padding(5);
            this.ipPollingTimeout.Name = "ipPollingTimeout";
            this.ipPollingTimeout.ShowMilliseconds = true;
            this.ipPollingTimeout.Size = new System.Drawing.Size(182, 24);
            this.ipPollingTimeout.TabIndex = 11;
            // 
            // rbDynamicElement
            // 
            this.rbDynamicElement.AutoSize = true;
            this.rbDynamicElement.Location = new System.Drawing.Point(183, 27);
            this.rbDynamicElement.Margin = new System.Windows.Forms.Padding(2);
            this.rbDynamicElement.Name = "rbDynamicElement";
            this.rbDynamicElement.Size = new System.Drawing.Size(66, 17);
            this.rbDynamicElement.TabIndex = 9;
            this.rbDynamicElement.TabStop = true;
            this.rbDynamicElement.Text = "Dynamic";
            this.rbDynamicElement.UseVisualStyleBackColor = true;
            this.rbDynamicElement.CheckedChanged += new System.EventHandler(this.rbDynamicElement_CheckedChanged);
            // 
            // rbStaticElement
            // 
            this.rbStaticElement.AutoSize = true;
            this.rbStaticElement.Location = new System.Drawing.Point(127, 27);
            this.rbStaticElement.Margin = new System.Windows.Forms.Padding(2);
            this.rbStaticElement.Name = "rbStaticElement";
            this.rbStaticElement.Size = new System.Drawing.Size(52, 17);
            this.rbStaticElement.TabIndex = 8;
            this.rbStaticElement.TabStop = true;
            this.rbStaticElement.Text = "Static";
            this.rbStaticElement.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Element Type:";
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.BackgroundImage = global::UBoat.WebHawk.UI.Properties.Resources.Pointer;
            this.btnSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Location = new System.Drawing.Point(563, 0);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(26, 22);
            this.btnSelect.TabIndex = 12;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "List Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Scope Name:";
            // 
            // txtScopeName
            // 
            this.txtScopeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScopeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScopeName.Location = new System.Drawing.Point(127, 105);
            this.txtScopeName.Name = "txtScopeName";
            this.txtScopeName.Size = new System.Drawing.Size(462, 20);
            this.txtScopeName.TabIndex = 15;
            // 
            // cbListName
            // 
            this.cbListName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbListName.FormattingEnabled = true;
            this.cbListName.Location = new System.Drawing.Point(127, 131);
            this.cbListName.Name = "cbListName";
            this.cbListName.Size = new System.Drawing.Size(462, 21);
            this.cbListName.TabIndex = 17;
            // 
            // cbIncludeInXML
            // 
            this.cbIncludeInXML.AutoSize = true;
            this.cbIncludeInXML.Location = new System.Drawing.Point(127, 178);
            this.cbIncludeInXML.Name = "cbIncludeInXML";
            this.cbIncludeInXML.Size = new System.Drawing.Size(15, 14);
            this.cbIncludeInXML.TabIndex = 18;
            this.cbIncludeInXML.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Include In XML:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Persist:";
            // 
            // cbPersistList
            // 
            this.cbPersistList.AutoSize = true;
            this.cbPersistList.Location = new System.Drawing.Point(127, 158);
            this.cbPersistList.Name = "cbPersistList";
            this.cbPersistList.Size = new System.Drawing.Size(15, 14);
            this.cbPersistList.TabIndex = 20;
            this.cbPersistList.UseVisualStyleBackColor = true;
            // 
            // ElementSetIterationEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbPersistList);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbIncludeInXML);
            this.Controls.Add(this.cbListName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtScopeName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ipPollingTimeout);
            this.Controls.Add(this.rbDynamicElement);
            this.Controls.Add(this.rbStaticElement);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtObjectClassName);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtElementSetContainer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ElementSetIterationEditor";
            this.Size = new System.Drawing.Size(594, 206);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtElementSetContainer;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtObjectClassName;
        private System.Windows.Forms.Label label3;
        private Utils.Controls.IntervalPicker ipPollingTimeout;
        private System.Windows.Forms.RadioButton rbDynamicElement;
        private System.Windows.Forms.RadioButton rbStaticElement;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtScopeName;
        private System.Windows.Forms.ComboBox cbListName;
        private System.Windows.Forms.CheckBox cbIncludeInXML;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbPersistList;
    }
}
