using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStore.Models
{
    public enum DrinkTypes
    {
        Alcohol,
        NonAlcoholic
    }
    public class Drink : Product
    {
        public DrinkTypes TypesOfDrink { get; set; }
        public Drink(string name, int quantity, decimal taxPercent,DrinkTypes drinkTypes)
            : base(name, quantity, taxPercent)
        {
            TypesOfDrink = drinkTypes;
        }
        
        public override bool CanSell()
        {
            return true;
        }
    }
}
