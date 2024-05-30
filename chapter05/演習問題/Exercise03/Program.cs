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
            //var cnt = text.Count(s => s == "");
            var cnt = text.Count(c => c == ' ');
            Console.WriteLine("空白数:{0}",cnt);
        }

        private static void Exercise3_2(string text) {
            var replaced = text.Replace("big", "small");
            Console.WriteLine(replaced);
        }

        private static void Exercise3_3(string text) {
            //var cnt = text.Count(c => c != ' ');
            //Console.WriteLine("単語数:{0}",cnt);
            int cnt = text.Split(' ').Length;
            Console.WriteLine("単語数:{0}", cnt);
        }

        private static void Exercise3_4(string text) {
            var words = text.Split(' ').Where(s => s.Length <= 4);
            foreach (var word in words) { 
                Console.WriteLine(word);
            }
        }

        private static void Exercise3_5(string text) {
            /*var sb = new StringBuilder();
            string[] n = text.Split(' ');
            foreach (var word in n){
                sb.Append(word);
            }
            var num = sb.ToString();
            Console.WriteLine(num);*/
            var array = text.Split(' ').ToArray();
            var sb = new StringBuilder();
            foreach (var word in array) {
                sb.Append(word);
                sb.Append(' ');
            }
            Console.WriteLine(sb);
        }
    }
}
