using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStore.Models
{
    public enum CustomerTypes
    {
        Casual=100,
        Bulk=20
    }
  public class Customer
    {
        public string Name { get; set; }
        public CustomerTypes TypeOfCustomer { get; set; }
        public PaymentMethods PayMethod { get; set; }


        public Customer()
        {

        }
        public Customer(string name,CustomerTypes customerTypes, PaymentMethods paymentMethods)
        {
            Name = name;
            TypeOfCustomer = customerTypes;
            PayMethod = paymentMethods;
        }
    }
}
