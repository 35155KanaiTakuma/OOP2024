﻿namespace RssReader {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.tbRssUrl = new System.Windows.Forms.TextBox();
            this.btGet = new System.Windows.Forms.Button();
            this.lbRssTitle = new System.Windows.Forms.ListBox();
            this.webView2_1 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.btclean = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.webView2_1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbRssUrl
            // 
            this.tbRssUrl.Location = new System.Drawing.Point(12, 14);
            this.tbRssUrl.Name = "tbRssUrl";
            this.tbRssUrl.Size = new System.Drawing.Size(571, 19);
            this.tbRssUrl.TabIndex = 0;
            // 
            // btGet
            // 
            this.btGet.Location = new System.Drawing.Point(606, 10);
            this.btGet.Name = "btGet";
            this.btGet.Size = new System.Drawing.Size(80, 23);
            this.btGet.TabIndex = 1;
            this.btGet.Text = "取得";
            this.btGet.UseVisualStyleBackColor = true;
            this.btGet.Click += new System.EventHandler(this.btGet_Click_1);
            // 
            // lbRssTitle
            // 
            this.lbRssTitle.FormattingEnabled = true;
            this.lbRssTitle.ItemHeight = 12;
            this.lbRssTitle.Location = new System.Drawing.Point(12, 51);
            this.lbRssTitle.Name = "lbRssTitle";
            this.lbRssTitle.Size = new System.Drawing.Size(645, 64);
            this.lbRssTitle.TabIndex = 2;
            this.lbRssTitle.SelectedIndexChanged += new System.EventHandler(this.lbRssTitle_SelectedIndexChanged);
            // 
            // webView2_1
            // 
            this.webView2_1.AllowExternalDrop = true;
            this.webView2_1.CreationProperties = null;
            this.webView2_1.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView2_1.Location = new System.Drawing.Point(12, 134);
            this.webView2_1.Name = "webView2_1";
            this.webView2_1.Size = new System.Drawing.Size(756, 497);
            this.webView2_1.Source = new System.Uri("https://news.yahoo.co.jp/rss", System.UriKind.Absolute);
            this.webView2_1.TabIndex = 4;
            this.webView2_1.ZoomFactor = 1D;
            // 
            // btclean
            // 
            this.btclean.Location = new System.Drawing.Point(663, 66);
            this.btclean.Name = "btclean";
            this.btclean.Size = new System.Drawing.Size(95, 49);
            this.btclean.TabIndex = 5;
            this.btclean.Text = "クリア";
            this.btclean.UseVisualStyleBackColor = true;
            this.btclean.Click += new System.EventHandler(this.btclean_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 662);
            this.Controls.Add(this.btclean);
            this.Controls.Add(this.webView2_1);
            this.Controls.Add(this.lbRssTitle);
            this.Controls.Add(this.btGet);
            this.Controls.Add(this.tbRssUrl);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.webView2_1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbRssUrl;
        private System.Windows.Forms.Button btGet;
        private System.Windows.Forms.ListBox lbRssTitle;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2_1;
        private System.Windows.Forms.Button btclean;
    }
}

