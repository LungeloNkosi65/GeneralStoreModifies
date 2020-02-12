using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStore.Models
{
   public class Supplier
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public List<SupplierProduct> SupplierProducts { get; set; }

        public Supplier()
        {
            SupplierProducts = new List<SupplierProduct>()
            {
                new SupplierProduct(new Drink("Dragon",12,0.1M,DrinkTypes.NonAlcoholic),13),
                new SupplierProduct(new Drink("Castle Light",30,0.15M,DrinkTypes.Alcohol),25)
            };
        }

        public Supplier(string name,string location,List<SupplierProduct> supplierProducts)
        {
            Name = name;
            Location = location;
            SupplierProducts = supplierProducts;
        }
    }
}
