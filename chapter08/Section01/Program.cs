using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var today = DateTime.Today;
            Console.WriteLine("生年月日を入力");
            Console.Write("年:");
            var year = Console.ReadLine();
            Console.Write("月:");
            var month = Console.ReadLine();
            Console.Write("日:");
            var day = Console.ReadLine();

            var birth = new DateTime(int.Parse(year),int.Parse(month),int.Parse(day));

            DayOfWeek dayOfWeek = birth.DayOfWeek;


            Console.Write("あなたの生まれた曜日は");
            switch (dayOfWeek) {
                case DayOfWeek.Monday:
                    Console.Write("月曜日");
                    break;

                case DayOfWeek.Tuesday:
                    Console.Write("火曜日");
                    break;

                case DayOfWeek.Wednesday:
                    Console.Write("水曜日");
                    break;

                case DayOfWeek.Thursday:
                    Console.Write("木曜日");
                    break;

                case DayOfWeek.Friday:
                    Console.Write("金曜日");
                    break;

                case DayOfWeek.Saturday:
                    Console.Write("土曜日");
                    break;

                case DayOfWeek.Sunday:
                    Console.Write("日曜日");
                    break;  
            }
            Console.WriteLine("です");
            Console.WriteLine();

            Console.WriteLine(birth.ToString("あなたが生まれた曜日はddddです"));
            Console.WriteLine();

            //aあなたは平成○○年○月○○日に生まれました
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str = birth.ToString("あなたはggyy年M月d日ddddに生まれました",culture);
            Console.WriteLine(str);
            Console.WriteLine();

            TimeSpan diff = today.Date - birth.Date;
            Console.WriteLine("あなたは生まれてから今日で{0}日目です",diff.Days + 1);
            /*if (dayOfWeek == DayOfWeek.Friday)
                Console.WriteLine("今日は金曜日です");
            var dt2 = new DateTime(2005,1,1,4,8,5);
            Console.WriteLine(dt1);
            Console.WriteLine(dt2);
            
            var today = DateTime.Today;
            var now = DateTime.Now;
            Console.WriteLine("Today : {0}",today);
            Console.WriteLine("Now : {0}" ,now);

            var isLeapYear = DateTime.IsLeapYear(2024);
            if(isLeapYear) {
                Console.WriteLine("閏年です");
            }else {
                Console.WriteLine("閏年ではありません");
            }*/
        }
    }
}
