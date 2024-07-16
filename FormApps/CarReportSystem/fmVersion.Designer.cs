namespace CarReportSystem {
    partial class fmVersion {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            btVersionOk = new Button();
            label1 = new Label();
            VersionNow = new Label();
            Name = new Label();
            SuspendLayout();
            // 
            // btVersionOk
            // 
            btVersionOk.Location = new Point(311, 219);
            btVersionOk.Name = "btVersionOk";
            btVersionOk.Size = new Size(73, 25);
            btVersionOk.TabIndex = 0;
            btVersionOk.Text = "OK";
            btVersionOk.UseVisualStyleBackColor = true;
            btVersionOk.Click += btVersionOk_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("HGｺﾞｼｯｸM", 18F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label1.Location = new Point(21, 20);
            label1.Name = "label1";
            label1.Size = new Size(205, 24);
            label1.TabIndex = 1;
            label1.Text = "CarReportSystem";
            // 
            // VersionNow
            // 
            VersionNow.AutoSize = true;
            VersionNow.Font = new Font("HGｺﾞｼｯｸM", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            VersionNow.Location = new Point(43, 71);
            VersionNow.Name = "VersionNow";
            VersionNow.Size = new Size(71, 15);
            VersionNow.TabIndex = 2;
            VersionNow.Text = "Ver0.0.1";
            // 
            // Name
            // 
            Name.AutoSize = true;
            Name.Location = new Point(46, 108);
            Name.Name = "Name";
            Name.Size = new Size(38, 15);
            Name.TabIndex = 3;
            Name.Text = "Name";
            // 
            // fmVersion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(422, 290);
            Controls.Add(Name);
            Controls.Add(VersionNow);
            Controls.Add(label1);
            Controls.Add(btVersionOk);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Text = "fmVersion";
            Load += fmVersion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btVersionOk;
        private Label label1;
        private Label VersionNow;
        private Label Name;
    }
}