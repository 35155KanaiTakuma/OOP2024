using System;
using System.Collections;
using Microsoft.Web.WebView2.Core;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;
using Windows.UI.Xaml.Controls;

namespace RssReader {
    public partial class Form1 : Form {
        List<ItemDate> items;

        public Form1() {
            InitializeComponent();
        }

        private void btGet_Click_1(object sender, EventArgs e) {
            if (tbRssUrl.Text == "") {
                MessageBox.Show("URLが入力されていません");
                return;
            }
            using (var wc = new WebClient()) {
                var url = wc.OpenRead(tbRssUrl.Text);
                XDocument xdoc = XDocument.Load(url);

                items = xdoc.Root.Descendants("item")
                    .Select(item => new ItemDate {
                        Title = item.Element("title").Value,
                        Link = item.Element("link").Value,
                    }).ToList();

                foreach (var title in items) {

                    lbRssTitle.Items.Add(title.Title);
                }
            }
            tbRssUrl.Text = "";
        }

        private void lbRssTitle_SelectedIndexChanged(object sender, EventArgs e) {
            //webView2_1.CoreWebView2.NavigateToString(items.Link);
        }

        private void btclean_Click(object sender, EventArgs e) {
            
        }
    }
    //データ格納用のクラス
    public class ItemDate {
        public string Title { get; set; }
        public string Link { get; set; }
    }
}
