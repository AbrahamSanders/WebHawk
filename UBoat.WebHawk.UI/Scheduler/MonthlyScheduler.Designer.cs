namespace UBoat.WebHawk.UI.Scheduler
{
    partial class MonthlyScheduler
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
            this.label4 = new System.Windows.Forms.Label();
            this.rbOrdinalDays = new System.Windows.Forms.RadioButton();
            this.rbWeekdays = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.ccbOrdinalDays = new UBoat.Utils.Controls.CheckedComboBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.ccbWeekdayPositions = new UBoat.Utils.Controls.CheckedComboBoxEx();
            this.ccbWeekdays = new UBoat.Utils.Controls.CheckedComboBoxEx();
            this.ccbMonths = new UBoat.Utils.Controls.CheckedComboBoxEx();
            this.dailyRepeatableScheduler = new UBoat.WebHawk.UI.Scheduler.DailyRepeatableScheduler();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Recur every:";
            // 
            // rbOrdinalDays
            // 
            this.rbOrdinalDays.AutoSize = true;
            this.rbOrdinalDays.Location = new System.Drawing.Point(16, 30);
            this.rbOrdinalDays.Name = "rbOrdinalDays";
            this.rbOrdinalDays.Size = new System.Drawing.Size(57, 17);
            this.rbOrdinalDays.TabIndex = 39;
            this.rbOrdinalDays.TabStop = true;
            this.rbOrdinalDays.Text = "On the";
            this.rbOrdinalDays.UseVisualStyleBackColor = true;
            this.rbOrdinalDays.CheckedChanged += new System.EventHandler(this.rbOrdinalDays_CheckedChanged);
            // 
            // rbWeekdays
            // 
            this.rbWeekdays.AutoSize = true;
            this.rbWeekdays.Location = new System.Drawing.Point(16, 57);
            this.rbWeekdays.Name = "rbWeekdays";
            this.rbWeekdays.Size = new System.Drawing.Size(57, 17);
            this.rbWeekdays.TabIndex = 40;
            this.rbWeekdays.TabStop = true;
            this.rbWeekdays.Text = "On the";
            this.rbWeekdays.UseVisualStyleBackColor = true;
            this.rbWeekdays.CheckedChanged += new System.EventHandler(this.rbWeekdays_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "of the month";
            // 
            // ccbOrdinalDays
            // 
            this.ccbOrdinalDays.CheckOnClick = true;
            this.ccbOrdinalDays.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ccbOrdinalDays.DropDownHeight = 1;
            this.ccbOrdinalDays.Enabled = false;
            this.ccbOrdinalDays.FormattingEnabled = true;
            this.ccbOrdinalDays.IntegralHeight = false;
            this.ccbOrdinalDays.Location = new System.Drawing.Point(77, 29);
            this.ccbOrdinalDays.MaxDropDownItems = 33;
            this.ccbOrdinalDays.Name = "ccbOrdinalDays";
            this.ccbOrdinalDays.ShowSelectAll = true;
            this.ccbOrdinalDays.Size = new System.Drawing.Size(179, 21);
            this.ccbOrdinalDays.TabIndex = 43;
            this.ccbOrdinalDays.ValueSeparator = ", ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "of the month";
            // 
            // ccbWeekdayPositions
            // 
            this.ccbWeekdayPositions.CheckOnClick = true;
            this.ccbWeekdayPositions.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ccbWeekdayPositions.DropDownHeight = 1;
            this.ccbWeekdayPositions.Enabled = false;
            this.ccbWeekdayPositions.FormattingEnabled = true;
            this.ccbWeekdayPositions.IntegralHeight = false;
            this.ccbWeekdayPositions.Location = new System.Drawing.Point(77, 56);
            this.ccbWeekdayPositions.MaxDropDownItems = 6;
            this.ccbWeekdayPositions.Name = "ccbWeekdayPositions";
            this.ccbWeekdayPositions.ShowSelectAll = true;
            this.ccbWeekdayPositions.Size = new System.Drawing.Size(86, 21);
            this.ccbWeekdayPositions.TabIndex = 45;
            this.ccbWeekdayPositions.ValueSeparator = ", ";
            // 
            // ccbWeekdays
            // 
            this.ccbWeekdays.CheckOnClick = true;
            this.ccbWeekdays.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ccbWeekdays.DropDownHeight = 1;
            this.ccbWeekdays.Enabled = false;
            this.ccbWeekdays.FormattingEnabled = true;
            this.ccbWeekdays.IntegralHeight = false;
            this.ccbWeekdays.Location = new System.Drawing.Point(169, 56);
            this.ccbWeekdays.Name = "ccbWeekdays";
            this.ccbWeekdays.ShowSelectAll = true;
            this.ccbWeekdays.Size = new System.Drawing.Size(87, 21);
            this.ccbWeekdays.TabIndex = 46;
            this.ccbWeekdays.ValueSeparator = ", ";
            // 
            // ccbMonths
            // 
            this.ccbMonths.CheckOnClick = true;
            this.ccbMonths.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ccbMonths.DropDownHeight = 1;
            this.ccbMonths.FormattingEnabled = true;
            this.ccbMonths.IntegralHeight = false;
            this.ccbMonths.Location = new System.Drawing.Point(77, 2);
            this.ccbMonths.MaxDropDownItems = 33;
            this.ccbMonths.Name = "ccbMonths";
            this.ccbMonths.ShowSelectAll = true;
            this.ccbMonths.Size = new System.Drawing.Size(179, 21);
            this.ccbMonths.TabIndex = 47;
            this.ccbMonths.ValueSeparator = ", ";
            // 
            // dailyRepeatableScheduler
            // 
            this.dailyRepeatableScheduler.Location = new System.Drawing.Point(3, 83);
            this.dailyRepeatableScheduler.Name = "dailyRepeatableScheduler";
            this.dailyRepeatableScheduler.Schedule = null;
            this.dailyRepeatableScheduler.Size = new System.Drawing.Size(335, 51);
            this.dailyRepeatableScheduler.TabIndex = 48;
            // 
            // MonthlyScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dailyRepeatableScheduler);
            this.Controls.Add(this.ccbMonths);
            this.Controls.Add(this.ccbWeekdays);
            this.Controls.Add(this.ccbWeekdayPositions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ccbOrdinalDays);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbWeekdays);
            this.Controls.Add(this.rbOrdinalDays);
            this.Controls.Add(this.label4);
            this.Name = "MonthlyScheduler";
            this.Size = new System.Drawing.Size(398, 140);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbOrdinalDays;
        private System.Windows.Forms.RadioButton rbWeekdays;
        private System.Windows.Forms.Label label1;
        private Utils.Controls.CheckedComboBoxEx ccbOrdinalDays;
        private System.Windows.Forms.Label label2;
        private Utils.Controls.CheckedComboBoxEx ccbWeekdayPositions;
        private Utils.Controls.CheckedComboBoxEx ccbWeekdays;
        private Utils.Controls.CheckedComboBoxEx ccbMonths;
        private DailyRepeatableScheduler dailyRepeatableScheduler;
    }
}
