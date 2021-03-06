﻿using GeneralStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStore.LogicLayer
{
   public class SellingLogic
    {
        public StoreLogic storeLogic;
        public List<Payment> payments;
        public SellingLogic()
        {
            storeLogic = new StoreLogic();
            payments = new List<Payment>();

        }
        public void ProcessPayment(Product product, Customer customer, decimal amount, PaymentMethods paymentMethods)
        {
          
            if (amount >= storeLogic.CalcAmount(product,product.Quantity,customer))
            {
                Console.WriteLine("Payment SuccessFull for "+ product.ProductName);
                payments.Add(new Payment(paymentMethods, customer, product, amount));
            }
        }

        public void OpenSTore()
        {
            string input = "false";
            Console.WriteLine("\n------------------WELCOME!!!!------------------");
            Console.WriteLine("\n\nPlease indicate action to be made:");
            Console.WriteLine("\nPlace supply order: order");
            Console.WriteLine("\nPlace sale: sale");

            do
            {
                input = Console.ReadLine();
                switch (input)
                {
                    case "order":
                        //
                        break;
                    case "sale":
                        //
                        Customer customer = new Customer();
                        customer = EnterCustomerInfo(customer,input);
                        AddToCart(input, customer);
                        break;
                    default:
                        //
                        input = "false";
                        break;
                }
            } while (input == "false");
        }
        public Customer EnterCustomerInfo(Customer customer, string input)
        {
            customer = new Customer();
            do
            {
                Console.WriteLine("Enter customer name");
                input =Console.ReadLine().ToUpper();
                if (input.All(Char.IsLetter))
                {
                    customer.Name = input;
                    break;
                }
                else
                {
                    Console.WriteLine("\nPlease enter  valid customer name");
                    break;

                }
            } while (true);
            //Customer Type Check
            do
            {
                Console.WriteLine("\n Enter customer type from the following:");
                foreach (var item in Enum.GetNames(typeof(CustomerTypes)))
                {
                    Console.WriteLine("\n " + item);
                }
                Console.WriteLine();
                input = Console.ReadLine();
                if (Enum.IsDefined(typeof(CustomerTypes), input))
                {
                    customer.TypeOfCustomer = (CustomerTypes)Enum.Parse(typeof(CustomerTypes), input);
                    break;
                }
            } while (true);

            //paymentCheck
            do
            {
                Console.WriteLine("\n Select paymenth method from the following");

                foreach (var item in Enum.GetNames(typeof(PaymentMethods)))
                {
                    Console.WriteLine("\n"+item);
                }
                Console.WriteLine();
                input = Console.ReadLine();

                if (Enum.IsDefined(typeof(PaymentMethods), input))
                {
                    customer.PayMethod = (PaymentMethods)Enum.Parse(typeof(PaymentMethods), input);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid payment method, please enter valid paymenth method");
                }

            } while (true);
            return customer;
        }
        public void CartTotal()
        {
            decimal total = 0;
            foreach (var item in storeLogic.Cart)
            {
                total += item.SellPrice;
            }
            Console.WriteLine("Cart Total "+ total);
        }

        public void AddToCart(string input,Customer customer)
        {
            Product cartItem;
            Console.WriteLine("Eneter items to buy from the following itmes ");
            for (int i = 0; i < storeLogic.AvailableProducts.Count(); i++)
            {
                Console.WriteLine($"\n({i}) {storeLogic.AvailableProducts[i].ProductName}: R{storeLogic.CalcAmount( storeLogic.AvailableProducts[i],1,customer)} ({storeLogic.AvailableProducts[i].Quantity} available)");
            }


            do
            {
                if (input == "-1")
                {
                    break;
                }
                else if(input.All(Char.IsDigit)&& int.Parse(input)< storeLogic.AvailableProducts.Count)
                {
                    cartItem = (Product)storeLogic.AvailableProducts[int.Parse(input)];
                    if (storeLogic.Cart.Exists(x => x.ProductName == cartItem.ProductName))
                    {
                        cartItem.Quantity += int.Parse(input);
                    }
                }

            } while (true);

        }
    }
}
