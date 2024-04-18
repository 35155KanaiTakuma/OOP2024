using SampleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSample {
    internal class Program {
        static void Main(string[] args) {

            Product dorayaki = new Product(98, "どら焼き", 210);
            Product karinto = new Product(123, "かりんとう", 180);
            Product daihuku = new Product(235, "大福", 200);

            int dorayakiTax = dorayaki.GetTax();
            

            int price = karinto.Price;  // 税抜きの金額
            int taxIncluded = karinto.GetPriceIncludingTax();   //税込みの金額

            int daihukuPrice = daihuku.Price;
            int daihukuTaxIncluded = daihuku.GetPriceIncludingTax();

            Console.WriteLine(karinto.Name + "の税込み金額" + 
                taxIncluded + "円" + "（税抜き" + price　+ "円)");

            Console.WriteLine(daihuku.Name + "の税込み金額" +
                daihukuTaxIncluded + "円" + "（税抜き" + daihukuPrice + "円)");

            Console.WriteLine($"{dorayakiTax}円");

        }
    }
}
