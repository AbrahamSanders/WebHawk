namespace UBoat.WebHawk.UI.StepEditors
{
    partial class ElementStepEditor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEditElementIdentifier = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ipPollingTimeout = new UBoat.Utils.Controls.IntervalPicker();
            this.txtElementPath = new System.Windows.Forms.TextBox();
            this.rbDynamicElement = new System.Windows.Forms.RadioButton();
            this.rbStaticElement = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnEditElementIdentifier);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ipPollingTimeout);
            this.groupBox1.Controls.Add(this.txtElementPath);
            this.groupBox1.Controls.Add(this.rbDynamicElement);
            this.groupBox1.Controls.Add(this.rbStaticElement);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(639, 103);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Element Settings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Element Path:";
            // 
            // btnEditElementIdentifier
            // 
            this.btnEditElementIdentifier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditElementIdentifier.Location = new System.Drawing.Point(600, 17);
            this.btnEditElementIdentifier.Name = "btnEditElementIdentifier";
            this.btnEditElementIdentifier.Size = new System.Drawing.Size(33, 23);
            this.btnEditElementIdentifier.TabIndex = 13;
            this.btnEditElementIdentifier.Text = "...";
            this.btnEditElementIdentifier.UseVisualStyleBackColor = true;
            this.btnEditElementIdentifier.Click += new System.EventHandler(this.btnEditElementIdentifier_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Polling Timeout:";
            // 
            // ipPollingTimeout
            // 
            this.ipPollingTimeout.Location = new System.Drawing.Point(96, 70);
            this.ipPollingTimeout.Margin = new System.Windows.Forms.Padding(5);
            this.ipPollingTimeout.Name = "ipPollingTimeout";
            this.ipPollingTimeout.Size = new System.Drawing.Size(298, 29);
            this.ipPollingTimeout.TabIndex = 4;
            // 
            // txtElementPath
            // 
            this.txtElementPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtElementPath.Enabled = false;
            this.txtElementPath.Location = new System.Drawing.Point(96, 19);
            this.txtElementPath.Name = "txtElementPath";
            this.txtElementPath.Size = new System.Drawing.Size(498, 20);
            this.txtElementPath.TabIndex = 12;
            // 
            // rbDynamicElement
            // 
            this.rbDynamicElement.AutoSize = true;
            this.rbDynamicElement.Location = new System.Drawing.Point(154, 45);
            this.rbDynamicElement.Name = "rbDynamicElement";
            this.rbDynamicElement.Size = new System.Drawing.Size(66, 17);
            this.rbDynamicElement.TabIndex = 2;
            this.rbDynamicElement.TabStop = true;
            this.rbDynamicElement.Text = "Dynamic";
            this.rbDynamicElement.UseVisualStyleBackColor = true;
            this.rbDynamicElement.CheckedChanged += new System.EventHandler(this.rbDynamicElement_CheckedChanged);
            // 
            // rbStaticElement
            // 
            this.rbStaticElement.AutoSize = true;
            this.rbStaticElement.Location = new System.Drawing.Point(96, 45);
            this.rbStaticElement.Name = "rbStaticElement";
            this.rbStaticElement.Size = new System.Drawing.Size(52, 17);
            this.rbStaticElement.TabIndex = 1;
            this.rbStaticElement.TabStop = true;
            this.rbStaticElement.Text = "Static";
            this.rbStaticElement.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Element Type:";
            // 
            // ElementStepEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ElementStepEditor";
            this.Size = new System.Drawing.Size(645, 115);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbDynamicElement;
        private System.Windows.Forms.RadioButton rbStaticElement;
        private System.Windows.Forms.Label label1;
        private Utils.Controls.IntervalPicker ipPollingTimeout;
        private System.Windows.Forms.Button btnEditElementIdentifier;
        private System.Windows.Forms.TextBox txtElementPath;
        private System.Windows.Forms.Label label3;
    }
}
