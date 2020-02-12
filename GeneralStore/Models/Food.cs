using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStore.Models
{
    public enum FoodTypes
    {
        Perishable,
        NonPerishable
    }
    public class Food : Product
    {
        public FoodTypes TypOfFood { get; set; }

        public Food(string name, int quantity, decimal taxPercent,  FoodTypes foodTypes )
            : base(name, quantity, taxPercent)
        {
            TypOfFood = foodTypes;
        }
        public override bool CanSell()
        {
            if (TypOfFood == FoodTypes.Perishable && (DatePuechased-DateTime.Now.Date).TotalDays>7)
            {
                return false;
            }
            return true;
        }
    }
}
