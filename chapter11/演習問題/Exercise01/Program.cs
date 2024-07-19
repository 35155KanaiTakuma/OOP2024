using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var file = "Sample.xml";
            Exercise1_1(file);
            Console.WriteLine();
            Exercise1_2(file);
            Console.WriteLine();
            Exercise1_3(file);
            Console.WriteLine();

            var newfile = "sports.xml";
            Exercise1_4(file, newfile);

        }

        private static void Exercise1_1(string file) {
            var xdoc = XDocument.Load(file);
            /*var sports = xdoc.Root.Elements().Select(x => new {
                Name = x.Element("name").Value,
                Teammembers = x.Element("teammembers").Value
            });
            foreach (var sport in sports) {
                Console.WriteLine("{0} {1}", sport.Name, sport.Teammembers);
            }*/

            var xelement = xdoc.Root.Elements();
            foreach (var item in xelement) {
                var xname = item.Element("name").Value;
                var member = item.Element("teammembers").Value;
                Console.WriteLine("{0} {1}", xname, member);
            }
        }


        private static void Exercise1_2(string file) {
            var xdoc = XDocument.Load(file);
            var sports = xdoc.Root.Elements()
                             .Select(x => new {
                                 Name = x.Element("name").Attribute("kanji").Value,
                                 Firstplayed = x.Element("firstplayed").Value,
                             }).OrderBy(x => x.Firstplayed);

            //var xelement = xdoc.Root.Elements().OrderBy(x => x.Element("firstplayed"));
            //foreach (var item in xelement) {
            //var xname = item.Element("name");
            // var sport = xname.Attribute("kanji").Value;
            foreach (var sport in sports) {
                Console.WriteLine("{0} {1}", sport.Name, sport.Firstplayed);
            }

        }


        private static void Exercise1_3(string file) {
            var xdoc = XDocument.Load(file);
            var xelement = xdoc.Root.Elements()
                .OrderByDescending(x => x.Element("teammembers").Value).First();
            var xname = xelement.Element("name").Value;
            Console.WriteLine("{0}", xname);

            /*var xdoc = XDocment.Load(file) 
              var sport = xdoc.Root.Elements()
                                   .Select(x => new {
                Name = x.Element("name").Value
                Teammembers = x.Element("teammembers").Value
            })
            .OrderByDescending(x => int.Parse(x.Teammembers))
            .First();
            Console.WriteLine("{0}",sport.Name);
            */
        }

        private static void Exercise1_4(string file, string newfile) {
            List<XElement> xElements = new List<XElement>();

            var xdoc = XDocument.Load(file);
            string name, kanji, teammembers, firstplayed;
            int nextFlag;
            while (true) {
                Console.Write("名称："); name = Console.ReadLine();
                Console.Write("漢字："); kanji = Console.ReadLine();
                Console.Write("人数："); teammembers = Console.ReadLine();
                Console.Write("起源："); firstplayed = Console.ReadLine();

                var element = new XElement("file",
                    new XElement("name", name, new XAttribute("kanji", kanji)),
                    new XElement("teammembers", teammembers),
                    new XElement("firstplayed", firstplayed)
                    );
                xElements.Add(element);// リストに要素を追加
                Console.WriteLine();    //改行
                Console.Write("追加【1】保存【２】");
                Console.Write(">");
                nextFlag = int.Parse(Console.ReadLine());
                if (nextFlag == 2) break;  //無限ループを抜ける
                Console.WriteLine();    //改行
            }
            xdoc.Root.Add(xElements);
            xdoc.Save(newfile); //保存

            // 確認用
            /*foreach (var sport in xdoc.Root.Elements()) {
                var xname = sport.Element("name").Value;
                var xteammembers = sport.Element("teammembers").Value;
                var xfirstplayed = sport.Element("firstplayed").Value;
                Console.WriteLine("{0} {1} {2}", xname, xteammembers, xfirstplayed);
            }*/
        }
    }
}

