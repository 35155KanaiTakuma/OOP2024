using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            if (string.Compare(str1, str2, true) == 0) //ignoreCaseを使ってもok
                Console.WriteLine("文字列が等しい");
            else
                Console.WriteLine("文字列が等しくない");
        }
    }
}
