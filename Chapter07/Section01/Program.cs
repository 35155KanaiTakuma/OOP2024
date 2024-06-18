using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var kentyou = new Dictionary<string, string>();
            {
                for (int i = 0; i < 5; i++) {
                    // 都道府県の入力
                    Console.Write("都道府県:");
                    var huken = Console.ReadLine();

                    // 県庁所在地の入力
                    Console.Write("県庁所在地:");
                    var syozaiti = Console.ReadLine();

                    // すでに都道府県が登録されているか？
                    if(kentyou.ContainsKey(huken)) {
                        //登録済み
                        Console.WriteLine("上書きしますかYes/No");
                        if(Console.ReadLine() == "Y") {
                            kentyou[huken] = syozaiti;
                        }
                        //var reWrite = Console.ReadLine();
                    }else {
                        // 未登録
                        kentyou[huken] = syozaiti;
                    }
                    //if (kentyou.ContainsKey(huken)) {
                    //    kentyou.Add(huken, syozaiti);
                    //}
                    // 登録済み
                    // 上書きするか
                    // Yes…登録
                    // No…次の登録へ
                    var select = Console.ReadLine();


                }
            }
            // 改行
            Console.WriteLine();
            Boolean endFlag = false;
            while (true) {
                Console.WriteLine("**** メニュー ****");
                Console.WriteLine("**** 一覧表示 ****");
                Console.WriteLine("**** 検索 ****");
                Console.WriteLine("**** 終了 ****");
                var menuSelect = Console.ReadLine();
                switch (menuSelect) {
                    case "1":
                        // 一覧表示処理
                        foreach (var item in kentyou) {
                            Console.WriteLine("{0}の県庁所在地は{1}です", item.Key, item.Value);
                        }
                        break;

                    case "2":
                        // 都道府県の入力
                        Console.WriteLine("都道府県:");
                        var searchPref = Console.ReadLine();
                        Console.WriteLine(searchPref + "の県庁所在地は" + kentyou[searchPref]+ "です");
                        break;

                    case "9":
                        endFlag = true; // 終了処理
                        break;
                }
                if(endFlag) {
                    break;
                }
            }

            /*Console.WriteLine("*メニュー*");
            Console.WriteLine("1:一覧表示");
            Console.WriteLine("2:検索");
            Console.WriteLine("9:終了");
            foreach (var item in kentyou) {
                Console.WriteLine("{0}の県庁所在地は{1}です", item.Key, item.Value);
            }
            var n = int.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());
            while (n == 9) {
                if (n == 1) {
                    foreach (var item in kentyou) {
                        Console.WriteLine("{0}の県庁所在地は{1}です", item.Key, item.Value);
                    }
                }
                if (n == 2) {
                    var mam = Console.ReadLine();
                }
            }*/


            /*var employeeDict = new Dictionary<int, Employee> {
                { 100, new Employee(100, "清水遼久") },
                { 112, new Employee(112, "芹沢洋和") },
                { 125, new Employee(125, "岩瀬奈央子") },
            };

            employeeDict.Add(126, new Employee ( 126, "金井琢磨" ));

            var name = employeeDict.Where(e => e.Value.Name.Contains("和"));

            foreach (var item in employeeDict.Keys){
                Console.WriteLine($"{item}");
            }

            var result = employeeDict.Remove(126);

            foreach (var item in employeeDict){
                Console.WriteLine($"{item.Key} {item.Value.Name}");
            }

            // 以下、確認のためのコード
            var emp0 = employeeDict[100];
            Console.WriteLine($"{emp0.Id} {emp0.Name}");
            var emp1 = employeeDict[112];
            Console.WriteLine($"{emp1.Id} {emp1.Name}");
            var emp2 = employeeDict[125];
            Console.WriteLine($"{emp2.Id} {emp2.Name}");
            var emp3 = employeeDict[126];
            Console.WriteLine($"{emp3.Id} {emp3.Name}");

            

            var flowerDict = new Dictionary<string, int>() {
                { "sunflower", 400 },
                { "pansy", 300 },
                { "tulip", 350 },
                { "rose", 500 },
                { "dahlia", 450 },
            };
            Console.WriteLine(flowerDict["sunflower"]);
            Console.WriteLine(flowerDict["dahlia"]);*/

        }
    }
}
