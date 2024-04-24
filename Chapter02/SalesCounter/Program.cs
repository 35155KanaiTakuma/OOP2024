using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCounter {
    internal class Program {
        static void Main(string[] args) {
            List<Sale> shopdates = ReadSale(@"C:\Users\infosys\source\repos\OOP2024\Chapter02\SalesCounter\bin\Debug\date\Sales.csv");

            // 戻り値のコレクションを一件ずつ出力する
            foreach (Sale date in shopdates) {
                Console .WriteLine("店名:{0} カテゴリー:{1} 売上:{2}",date.ShopName,date.ProductCategory,date.Amount);
                
                Console.WriteLine(date.ShopName + " " + date.ProductCategory + " " + date.Amount);

                Console.WriteLine($"店名:{date.ShopName} カテゴリー:{date.ProductCategory} 売上:{date.Amount}");
            }
        }

        // 売り上げデータを読み込み、Saleオブジェクトのリストを返す
        static List<Sale> ReadSale(string filePath) {
            List<Sale> sales = new List<Sale>();
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines) 
            {
                string[] items = line.Split(',');
                Sale sale = new Sale {
                    ShopName = items[0],
                    ProductCategory = items[1],
                    Amount = int.Parse(items[2])
                };
                sales.Add(sale);
            }
            return sales;
        }
    }
}

