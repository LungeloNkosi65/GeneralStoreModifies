using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStore.Models
{
    public abstract class Product
    {
        public string ProductName { get; set; }
        public decimal SellPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TaxPercent { get; set; }
        public DateTime DatePuechased { get; set; }


        public Product(string name, int quantity,decimal taxPercent)
        {
            ProductName = name;
            Quantity = quantity;
            TaxPercent = taxPercent;
        }

        public abstract bool CanSell();
       
    }
}
