using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixologyMatrix
{
    public class DrinkRemover
    {
        private List<Drink> drinks;

        public DrinkRemover(List<Drink> drinks)
        {
            this.drinks = drinks;
        }

        public bool RemoveDrink(string name)
        {
            Drink drinkToRemove = drinks.FirstOrDefault(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (drinkToRemove != null)
            {
                drinks.Remove(drinkToRemove);
                Console.WriteLine($"Drink '{name}' removed successfully!");
                return true;
            }
            else
            {
                Console.WriteLine($"Drink '{name}' not found!");
                return false;
            }
        }
    }
}
