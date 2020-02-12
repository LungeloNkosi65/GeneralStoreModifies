using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStore.Models
{
   public class SupplierProduct
    {
        public Product Products { get; set; }
        public decimal CostPrice { get; set; }

        public SupplierProduct(Product product,decimal costPrice)
        {
            Products = product;
            CostPrice = costPrice;
        }
    }
}
