using System.ComponentModel;

namespace MixologyMatrix
{
    public class Program
    {
        static List<Drink> drinks = new List<Drink>();
        static DrinkManager drinkManager = new DrinkManager(drinks);
        static DrinkRemover drinkRemover = new DrinkRemover(drinks);
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the MixMaster - your personal library of drink recipes!");
            Console.WriteLine("Discover the world of unique cocktails and non-alcoholic drinks, add your favorite recipes, edit and experiment with new flavors.");
            Console.WriteLine("Start your journey to the world of mixology now and create perfect drinks for every occasion!!");
            Console.WriteLine();

            MenuActionService menuActionService = new MenuActionService();
            menuActionService = Initialize(menuActionService);
            while (true)
            {
                var mainMenu = menuActionService.GetMenuActionsByMenuName("Main");
                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
                }
                Console.WriteLine("Enter your choice and press Enter:");
                var operation = Console.ReadKey();
                char operationKey = operation.KeyChar;
                Console.WriteLine("");
                if (!char.IsDigit(operationKey))
                {
                    Console.WriteLine("Invalid action. Please enter a number corresponding to the menu option.");
                    continue;
                }
                int chosenOption = int.Parse(operationKey.ToString());
                if(chosenOption < 1 || chosenOption > mainMenu.Count)
                {
                    Console.WriteLine("Invalid action. Please enter a number corresponding to the menu option.");
                    continue;
                }
                Console.WriteLine();
                switch (operation.KeyChar)
                {
                    case '1':
                        drinkManager.SearchDrinks();
                        break;
                    case '2':
                        drinkManager.AddDrink();
                        break;
                    case '3':
                        drinkManager.EditDrink();
                        break;
                    case '4':
                        drinkRemover.DrinkRemoverMenu();
                        break;
                    case '5':
                        drinkManager.ListAllDrinks();
                        break;
                    case '6':
                        Console.WriteLine("Exiting the program...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Action you entered does not exist. Please try again.");
                        break;
                }
            }
           

        }

        private static MenuActionService Initialize(MenuActionService menuActionService)
        {
            menuActionService.AddNewAction(1, "Search for a drink recipe", "Main");
            menuActionService.AddNewAction(2, "Add a new drink recipe", "Main");
            menuActionService.AddNewAction(3, "Edit a drink recipee", "Main");
            menuActionService.AddNewAction(4, "Remove an existing drink recipe", "Main");
            menuActionService.AddNewAction(5, "List all drink recipes", "Main");
            menuActionService.AddNewAction(6, "Exit", "Main");
            return menuActionService;
        }
    }
}
