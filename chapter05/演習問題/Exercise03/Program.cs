using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";

            Exercise3_1(text);
            Console.WriteLine("-----");

            Exercise3_2(text);
            Console.WriteLine("-----");

            Exercise3_3(text);
            Console.WriteLine("-----");

            Exercise3_4(text);
            Console.WriteLine("-----");

            Exercise3_5(text);
        }

        private static void Exercise3_1(string text) {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            if (string.Compare(str1,str2,true) == 0) //ignoreCaseを使ってもok
                Console.WriteLine("文字列が等しい");
             else 
                Console.WriteLine("文字列が等しくない");
        }

        private static void Exercise3_2(string text) {
            var line = Console.ReadLine();
            int num;
            if(int.TryParse(line, out num)) {
                //Console.WriteLine("{0:#,#}",num);
                Console.WriteLine($"{num:#,#}");
            } else {
                Console.WriteLine("数字文字列ではありません");
            }
        }

        private static void Exercise3_3(string text) {
            

        }

        private static void Exercise3_4(string text) {
            
        }

        private static void Exercise3_5(string text) {
            
        }
    }
}
