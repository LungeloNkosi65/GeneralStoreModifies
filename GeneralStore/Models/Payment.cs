using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStore.Models
{
    public enum PaymentMethods
    {
        Card,
        Cash,
        Portal
    }
    public class Payment
    {
        public PaymentMethods PayMethod { get; set; }
        public Customer PayCustomer { get; set; }
        public List<Product> ProductsPayingFor = new List<Product>();
        public decimal Amount { get; set; }
        public Payment(PaymentMethods paymentMethods,Customer customer,List<Product> products,decimal amount)
        {
            PayMethod = paymentMethods;
            PayCustomer = customer;
            ProductsPayingFor = products;
            Amount = amount;
        }
        public Payment(PaymentMethods paymentMethods, Customer customer,Product product, decimal amount)
        {
            PayMethod = paymentMethods;
            PayCustomer = customer;
            ProductsPayingFor.Add(product);
            Amount = amount;
        }
    }
}
