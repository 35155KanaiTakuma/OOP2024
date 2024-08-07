﻿using System;
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
            int n = 1;
            var xdoc = XDocument.Load(file);
            while (n == 1) { 
                Console.Write("名称：");
                var sport_name = Console.ReadLine();
                Console.Write("漢字：");
                var sport_kanji = Console.ReadLine();
                Console.Write("人数：");
                var sport_member = Console.ReadLine();
                Console.Write("起源：");
                var sport_firstplayed = Console.ReadLine();

                var element = new XElement("file",
                    new XElement("name", sport_name, new XAttribute("kanji", sport_kanji)),
                    new XElement("teammembers", sport_member),
                    new XElement("firstplayed", sport_firstplayed)
                    );
                // 追加
                xdoc.Root.Add(element);
                // 保存
                xdoc.Save("newXmlFile.xml");
                Console.WriteLine("追加：1");
                Console.WriteLine("保存：2");
                n = int.Parse(Console.ReadLine());
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
}
