namespace DateTimeApp {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            label1 = new Label();
            dtpDate = new DateTimePicker();
            dtDateCount = new Button();
            tbDisp = new TextBox();
            nudDay = new NumericUpDown();
            btDayAfter = new Button();
            btDay = new Button();
            btAge = new Button();
            ((System.ComponentModel.ISupportInitialize)nudDay).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(140, 96);
            label1.Name = "label1";
            label1.Size = new Size(62, 32);
            label1.TabIndex = 0;
            label1.Text = "日付";
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtpDate.Location = new Point(302, 99);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(200, 35);
            dtpDate.TabIndex = 1;
            // 
            // dtDateCount
            // 
            dtDateCount.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtDateCount.Location = new Point(297, 148);
            dtDateCount.Name = "dtDateCount";
            dtDateCount.Size = new Size(205, 43);
            dtDateCount.TabIndex = 2;
            dtDateCount.Text = "今日までの日数";
            dtDateCount.UseVisualStyleBackColor = true;
            dtDateCount.Click += button1_Click;
            // 
            // tbDisp
            // 
            tbDisp.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbDisp.Location = new Point(245, 344);
            tbDisp.Name = "tbDisp";
            tbDisp.Size = new Size(257, 33);
            tbDisp.TabIndex = 3;
            // 
            // nudDay
            // 
            nudDay.Font = new Font("Yu Gothic UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            nudDay.Location = new Point(272, 228);
            nudDay.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            nudDay.Name = "nudDay";
            nudDay.Size = new Size(120, 46);
            nudDay.TabIndex = 4;
            // 
            // btDayAfter
            // 
            btDayAfter.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btDayAfter.Location = new Point(407, 259);
            btDayAfter.Name = "btDayAfter";
            btDayAfter.Size = new Size(95, 56);
            btDayAfter.TabIndex = 5;
            btDayAfter.Text = "日後";
            btDayAfter.UseVisualStyleBackColor = true;
            btDayAfter.Click += btDayAfter_Click;
            // 
            // btDay
            // 
            btDay.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btDay.Location = new Point(407, 197);
            btDay.Name = "btDay";
            btDay.Size = new Size(95, 56);
            btDay.TabIndex = 5;
            btDay.Text = "日前";
            btDay.UseVisualStyleBackColor = true;
            btDay.Click += btDayBefore_Click;
            // 
            // btAge
            // 
            btAge.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btAge.Location = new Point(549, 197);
            btAge.Name = "btAge";
            btAge.Size = new Size(75, 56);
            btAge.TabIndex = 6;
            btAge.Text = "年齢";
            btAge.UseVisualStyleBackColor = true;
            btAge.Click += btAge_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btAge);
            Controls.Add(btDay);
            Controls.Add(btDayAfter);
            Controls.Add(nudDay);
            Controls.Add(tbDisp);
            Controls.Add(dtDateCount);
            Controls.Add(dtpDate);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)nudDay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpDate;
        private Button dtDateCount;
        private TextBox tbDisp;
        private NumericUpDown nudDay;
        private Button btDayAfter;
        private Button btDay;
        private Button btAge;
    }
}
