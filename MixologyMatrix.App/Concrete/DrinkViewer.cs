using MixologyMatrix.Domain.Entity;

namespace MixologyMatrix
{
    public class DrinkViewer
    {
        private List<Drink> drinks;
        private List<AlcoholicDrink> alcoholicDrink;

        public DrinkViewer(List<Drink> drinks, List<AlcoholicDrink> alcoholicDrink)
        {
            this.drinks = drinks;
            this.alcoholicDrink = alcoholicDrink;
        }

        public void DisplayDrinkDetails(Drink drink)
        {
            Console.WriteLine($"ID: {drink.Id}");
            Console.WriteLine($"Name: {drink.Name}");
            Console.WriteLine($"Type: {drink.Type}");
            Console.WriteLine($"Ingredients: {drink.Ingredients}");
            Console.WriteLine($"Steps: {drink.Steps}");
            if (drink is AlcoholicDrink alcoholicDrink)
            {
                Console.WriteLine($"Alcohol: {alcoholicDrink.Alcohol}");
            }
            Console.WriteLine($"Difficulty Level: {drink.DifficultyLevel}");
            Console.WriteLine($"Glass Type: {drink.GlassType}");
            Console.WriteLine($"Flavor Profile: {drink.FlavorProfile}");
            Console.WriteLine($"Occasion Type: {drink.OccasionType}");
            Console.WriteLine(new string('-', 20));
        }

        public void ListAllDrinks()
        {
            if ((drinks == null || drinks.Count == 0) && (alcoholicDrink == null || alcoholicDrink.Count == 0))
            {
                Console.WriteLine("No drinks available");
                return;
            }

            Console.WriteLine("Listing all drink recipes");

            if (drinks != null && drinks.Count > 0)
            {
                foreach (var drink in drinks)
                {
                    Console.WriteLine($"- {drink.Name} (ID: {drink.Id})");
                    DisplayDrinkDetails(drink);
                }
            }

            if (alcoholicDrink != null && alcoholicDrink.Count > 0)
            {
                foreach (var drink in alcoholicDrink)
                {
                    Console.WriteLine($"- {drink.Name} (ID: {drink.Id})");
                    DisplayDrinkDetails(drink);
                }
            }
        }
    }
}