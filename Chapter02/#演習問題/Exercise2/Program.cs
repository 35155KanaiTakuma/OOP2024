

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2 {
    public class Program {
        static void Main(string[] args) {
            if (args.Length >= 1 && args[0] == "-tom") {
                // フィートからメートルへの対応表を出力
                PrintFeetToMeterList(1,10);
            } else {
                // メートルからフィートへの対応表を出力
                PrintMeterToFeetList(1,10);
            }
        }

        private static void PrintFeetToMeterList(int start, int stop) {
            for (int inti = start; inti <= stop; inti++) {
                double meter = IntiConverter.ToMeter(inti);
                Console.WriteLine("{0} ft = {1:0.0000} m", inti, meter);
            }
        }

        private static void PrintMeterToFeetList(int start, int stop) {
            for (int meter = start; meter <= stop; meter++) {
                double inti = IntiConverter.FromMeter(meter);
                Console.WriteLine("{0} m = {1:0.0000} ft", meter, inti);
            }
        }
    }
}
