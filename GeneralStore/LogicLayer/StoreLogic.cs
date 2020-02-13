using GeneralStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStore.LogicLayer
{
   public class StoreLogic
    {
        public List<Product> AvailableProducts { get; set; }
        public List<Product> Cart;
        public StoreLogic()
        {
            Cart = new List<Product>();
            AvailableProducts = new List<Product>()
            {  new Drink("Heinekn",12,0.1M,DrinkTypes.NonAlcoholic),
               new Drink("Castle Light",30,0.15M,DrinkTypes.Alcohol)
            };
        }
        public void ProcessSupplierOrder(Supplier supplier,Product product, int quantity)
        {
            foreach (var item in supplier.SupplierProducts)
            {
                if(item.Products.ProductName==product.ProductName && item.Products.Quantity >= quantity)
                {
                    item.Products.Quantity -= quantity;
                    AddToStock(product, quantity, item.CostPrice);
                    Console.WriteLine(item.Products.Quantity);
                    Console.WriteLine("Order succesfully proccessed");
                    return;
                }
            }
            Console.WriteLine("Supplier is curently out of stock for "+ product.ProductName);
        }
        public void AddToStock(Product product,int quantity,decimal costPrice)
        {
            foreach (var item in AvailableProducts)
            {
                if (item.ProductName == product.ProductName)
                {
                    item.Quantity += quantity;
                    item.SellPrice = costPrice;
                    item.DatePuechased = DateTime.Now.Date;
                    return;
                }

            }
            product.SellPrice = costPrice;
            product.Quantity = quantity;
            AvailableProducts.Add(product);
        }
        public void ProcessSale(Customer customer,Product product, int quantity)
        {
            foreach (var item in AvailableProducts)
            {
                if(item.ProductName==product.ProductName && item.Quantity >= product.Quantity)
                {
                    if (item.CanSell())
                    {
                        item.Quantity -= quantity;
                        CalcAmount(product, quantity, customer);
                        Console.WriteLine("Purchase successfull for " + product.ProductName);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Purchase successfull for " + product.ProductName + "at hlaf price "+ CalcAmount(product, quantity, customer)/2);
                        return;
                    }
                }
            }
            Console.WriteLine("Purchase unsuccessfull for " + product.ProductName);
        }
        public decimal CalcAmount(Product product, int quantity,Customer customer)
        {
            decimal markupAmount = (product.SellPrice * ((decimal)customer.TypeOfCustomer / 100));
            return (markupAmount + (markupAmount * product.TaxPercent))*quantity;
        }


       




        public void Sell(Customer customer,Product product, int quantity)
        {

        }
    }
}
