using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace section01 {
    internal class Program {
        static void Main(string[] args) {

            var xdoc = XDocument.Load("novelists.xml");
            var xelements = xdoc.Root.Descendants("title");
                //.OrderByDescending(e => (DateTime)e.Element("birth"));

            foreach (var xnovelist in xelements) {
                var xname = xnovelist.Element("name");// 要素の取得
                var xworks = xnovelist.Element("masterpieces")
                                     .Elements("title")
                                     .Select(x => x.Value);

                Console.WriteLine("{0} - {1}",xname.Value,string.Join(",",xworks));


                //var xkana = xname.Attribute("kana");// 属性の取得

                //var birth = (DateTime)xnovelist.Element("birth");// 要素の取得

                //Console.WriteLine($"{xname.Value}　[{xkana?.Value}] {birth.ToShortDateString()}");
            }
        }
    }
}
