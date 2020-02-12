using GeneralStore.LogicLayer;
using GeneralStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var Shopright = new StoreLogic();
            var sellingLogic = new SellingLogic();
            var Lungelo = new Supplier();
            var product1 = new Drink("Dragon", 5, 0.1M,DrinkTypes.NonAlcoholic);
            var prodBought1 = new Drink("Dragon", 5, 0.1M, DrinkTypes.NonAlcoholic);
            var customer1 = new Customer("Lungelo", CustomerTypes.Bulk,PaymentMethods.Cash);



            Shopright.ProcessSupplierOrder(Lungelo, product1, 5);
            Console.WriteLine();
            Shopright.ProcessSale(customer1, prodBought1, 2);

            Console.WriteLine();
            sellingLogic.ProcessPayment(prodBought1, customer1, 1100, PaymentMethods.Cash);

            Console.WriteLine();
            Shopright.OpenSTore();

            //sellingLogic.EnterCustomerInfo();
            Console.ReadKey();


        }
    }
}
