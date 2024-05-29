﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            #region null合体演算子
            //string code = "12345";
            //var message = GetMessage(code) ?? DefaultMessage();
            //Console.WriteLine(message);
            #endregion

            #region null条件演算子
            //Sale sale = new Sale {
            //    Amount = 10000,
            //};
            Sale sale = null;

            //「int?」はnull許容型、「?.」はnull条件演算子
            //int? ret = sale?.Amount;
            //Console.WriteLine(ret);
            #endregion


            Console.WriteLine("整数を入力:");
            string inputNum = Console.ReadLine();
            int num;
            //int num =int.Parse(inputNum);
            //Console.WriteLine("整数に変換した値:", num);

            if(int.TryParse(inputNum,out num)) {
                Console.WriteLine("変換できた:" + num );
            }
            else {
                Console.WriteLine("変換できなかった");
            }
        }

        private static object GetMessage(string code) {
            return 123;
        }

        private static object DefaultMessage() {
            return "Default Message";
        }
        //売上クラス
        public class Sale {
            // 店舗名
            public string ShopName { get; set; }

            // 商品カテゴリ
            public string ProductCategory { get; set; }

            // 売上高
            public int Amount { get; set; }
        }
    }
}
