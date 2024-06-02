using MixologyMatrix.Domain.Entity;

namespace MixologyMatrix
{
    public class DrinkRemover
    {
        private List<Drink> drinks;

        public DrinkRemover(List<Drink> drinks)
        {
            this.drinks = drinks;
        }

        public bool RemoveDrinkByName(string name)
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

        public bool RemoveDrinkById(int id)
        {
            Drink drinkToRemove = drinks.FirstOrDefault(d => d.Id == id);
            if (drinkToRemove != null)
            {
                drinks.Remove(drinkToRemove);
                Console.WriteLine($"Drink with ID '{id}' removed successfully!");
                return true;
            }
            Console.WriteLine($"Drink with ID '{id}' not found!");
            return false;
        }

        public void DrinkRemoverMenu()
        {
            while (true)
            {
                Console.WriteLine("Choose an option to remove a drink:");
                Console.WriteLine("1. Remove by ID");
                Console.WriteLine("2. Remove by Name");
                Console.WriteLine("Enter your choice:");

                var choice = Console.ReadKey();
                Console.WriteLine();

                switch (choice.KeyChar)
                {
                    case '1':
                        Console.WriteLine("Enter the ID of the drink to remove:");
                        var drinkIdInput = Console.ReadLine();
                        if (int.TryParse(drinkIdInput, out int drinkId))
                        {
                            RemoveDrinkById(drinkId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID. Please enter a valid number.");
                        }
                        break;

                    case '2':
                        Console.WriteLine("Enter the name of the drink to remove:");
                        var drinkName = Console.ReadLine();
                        RemoveDrinkByName(drinkName);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                        break;
                }

                Console.WriteLine("Do you want to perform another remove operation? (y/n)");
                var continueChoice = Console.ReadKey();
                Console.WriteLine();

                if (continueChoice.KeyChar != 'y' && continueChoice.KeyChar != 'Y')
                {
                    break;
                }
            }
        }
    }
}