namespace SequenceRecorderDriver
{
    partial class RecorderDriver
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
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.sequenceRecorder1 = new UBoat.WebHawk.UI.SequenceRecorder();
            this.btnGenerateXML = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGenerateXSLT = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtURL
            // 
            this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtURL.Location = new System.Drawing.Point(50, 8);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(749, 20);
            this.txtURL.TabIndex = 1;
            this.txtURL.Text = "file:///C:/UBoat/SequenceRecorderDriver/WebTests/Test1.html";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "URL:";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(805, 6);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 3;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(886, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "|";
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Location = new System.Drawing.Point(903, 6);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 5;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // sequenceRecorder1
            // 
            this.sequenceRecorder1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sequenceRecorder1.Location = new System.Drawing.Point(12, 34);
            this.sequenceRecorder1.Name = "sequenceRecorder1";
            this.sequenceRecorder1.RecordingEnabled = false;
            this.sequenceRecorder1.Size = new System.Drawing.Size(1162, 577);
            this.sequenceRecorder1.TabIndex = 0;
            // 
            // btnGenerateXML
            // 
            this.btnGenerateXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateXML.Location = new System.Drawing.Point(1082, 6);
            this.btnGenerateXML.Name = "btnGenerateXML";
            this.btnGenerateXML.Size = new System.Drawing.Size(40, 23);
            this.btnGenerateXML.TabIndex = 6;
            this.btnGenerateXML.Text = "XML";
            this.btnGenerateXML.UseVisualStyleBackColor = true;
            this.btnGenerateXML.Click += new System.EventHandler(this.btnGenerateXML_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1065, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "|";
            // 
            // btnGenerateXSLT
            // 
            this.btnGenerateXSLT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateXSLT.Location = new System.Drawing.Point(1128, 6);
            this.btnGenerateXSLT.Name = "btnGenerateXSLT";
            this.btnGenerateXSLT.Size = new System.Drawing.Size(46, 23);
            this.btnGenerateXSLT.TabIndex = 8;
            this.btnGenerateXSLT.Text = "XSLT";
            this.btnGenerateXSLT.UseVisualStyleBackColor = true;
            this.btnGenerateXSLT.Click += new System.EventHandler(this.btnGenerateXSLT_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Location = new System.Drawing.Point(984, 6);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 9;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // RecorderDriver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 623);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnGenerateXSLT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGenerateXML);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.sequenceRecorder1);
            this.Name = "RecorderDriver";
            this.Text = "RecorderDriver";
            this.Load += new System.EventHandler(this.RecorderDriver_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UBoat.WebHawk.UI.SequenceRecorder sequenceRecorder1;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnGenerateXML;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGenerateXSLT;
        private System.Windows.Forms.Button btnStop;
    }
}