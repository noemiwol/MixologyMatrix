using MixologyMatrix.App.Concrete;
using MixologyMatrix.Domain.Entity;
using MixologyMatrix.Domain.Enums;

namespace MixologyMatrix
{
    public class DrinkSearchManager
    {
        private DrinkViewer viewer;
        private List<Drink> drinks;
        private List<AlcoholicDrink> alcoholicDrinks;
        private DrinkSearchService searchService;
        public DrinkSearchManager(List<Drink> drinks, List<AlcoholicDrink> alcoholicDrinks)
        {
            this.drinks = drinks;
            this.searchService = new DrinkSearchService(drinks, alcoholicDrinks);
            this.viewer = new DrinkViewer(drinks, alcoholicDrinks);
            this.alcoholicDrinks = alcoholicDrinks;
        }

        public void SearchDrinks()
        {
            Console.WriteLine("Choose a filter to search by:");
            Console.WriteLine("1. Drink Name");
            Console.WriteLine("2. Drink Type");
            Console.WriteLine("3. Alcohol Type");
            Console.WriteLine("4. Non-Alcohol Drink Type");
            Console.WriteLine("5. Difficulty Level");
            Console.WriteLine("6. Glass Type");
            Console.WriteLine("7. Flavor Profile");
            Console.WriteLine("8. Occasion Type");
            Console.WriteLine("Enter your choice:");

            var choice = Console.ReadKey();
            Console.WriteLine();

            List<Drink> results = new List<Drink>();

            if (!char.IsDigit(choice.KeyChar) || choice.KeyChar < '1' || choice.KeyChar > '7')
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 7.");
                return;
            }

            switch (choice.KeyChar)
            {
                case '1':
                    results = SearchByDrinkName();
                    break;

                case '2':
                    results = SearchByDrinkType();
                    break;

                case '3':
                    results = SearchByAlcoholType();
                    break;

                case '4':
                    results = SearchByNonAlcoholType();
                    break;

                case '5':
                    results = SearchByDifficultyLevel();
                    break;

                case '6':
                    results = SearchByGlassType();
                    break;

                case '7':
                    results = SearchByFlavorProfile();
                    break;

                case '8':
                    results = SearchByOccasionType();
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    return;
            }
        }

        private List<Drink> SearchByDrinkName()
        {
            Console.WriteLine("Enter the name of the drink:");
            var name = Console.ReadLine();

            List<Drink> foundDrinks = searchService.SearchByDrinkName(name);

            if (foundDrinks.Count > 0)
            {
                Console.WriteLine($"Found {foundDrinks.Count} drink(s) with the name '{name}':");
                foreach (var drink in foundDrinks)
                {
                    Console.WriteLine($"- {drink.Name}");
                    viewer.DisplayDrinkDetails(drink);
                }
            }
            else
            {
                Console.WriteLine($"No drinks found with the name '{name}'.");
            }

            return foundDrinks;
        }

        private List<Drink> SearchByDrinkType()
        {
            Console.WriteLine("Enter drink type: alcoholic or non-alcoholic? (A/N)");
            string typeInput = Console.ReadLine().ToUpper();

            DrinkType drinkType;
            if (typeInput == "A")
            {
                drinkType = DrinkType.Alcoholic;
            }
            else if (typeInput == "N")
            {
                drinkType = DrinkType.NonAlcoholic;
            }
            else
            {
                Console.WriteLine("Invalid type");
                return new List<Drink>();
            }
            List<Drink> foundDrinks = searchService.SearchByDrinkType(drinkType);

            if (foundDrinks.Count > 0)
            {
                Console.WriteLine($"Found {foundDrinks.Count} drink(s) with the type '{drinkType}':");
                foreach (var drink in foundDrinks)
                {
                    Console.WriteLine($"- {drink.Name}");
                    viewer.DisplayDrinkDetails(drink);
                }
            }
            else
            {
                Console.WriteLine($"No drinks found with the type '{drinkType}'.");
            }

            return foundDrinks;
        }

        public List<Drink> SearchByNonAlcoholType()
        {
            List<Drink> nonAlcoholicDrinks = drinks.Where(d => d.Type == DrinkType.NonAlcoholic).ToList();

            if (nonAlcoholicDrinks.Count > 0)
            {
                Console.WriteLine($"Found {nonAlcoholicDrinks.Count} non-alcoholic drink(s):");
                foreach (var drink in nonAlcoholicDrinks)
                {
                    Console.WriteLine($"- {drink.Name}");
                    viewer.DisplayDrinkDetails(drink);
                }
            }
            else
            {
                Console.WriteLine("No non-alcoholic drinks found.");
            }

            return nonAlcoholicDrinks;
        }

        private List<Drink> SearchByAlcoholType()
        {
            Console.WriteLine("Enter alcohol type (e.g., Vodka, Rum, Whiskey):");
            string input = Console.ReadLine();
            if (!Enum.TryParse(input, true, out AlcoholType alcoholType))
            {
                Console.WriteLine("Invalid alcohol type.");
                return new List<Drink>();
            }

            List<AlcoholicDrink> matchingDrinks = searchService.SearchByAlcoholType(alcoholType);

            if (matchingDrinks.Count > 0)
            {
                Console.WriteLine($"Found {matchingDrinks.Count} drink(s) with the alcohol type '{alcoholType}':");
                foreach (var drink in matchingDrinks)
                {
                    Console.WriteLine($"- {drink.Name}");
                    viewer.DisplayDrinkDetails(drink);
                }
            }
            else
            {
                Console.WriteLine($"No drinks found with the alcohol type '{alcoholType}'.");
            }

            return matchingDrinks.Cast<Drink>().ToList();
        }

        private List<Drink> SearchByDifficultyLevel()
        {
            Console.WriteLine("Enter difficulty level (Easy, Medium, Hard): (E/M/H)");
            var typeInput = Console.ReadLine().ToUpper();

            DifficultyLevel difficultyLevel;
            if (typeInput == "E")
            {
                difficultyLevel = DifficultyLevel.Easy;
            }
            else if (typeInput == "M")
            {
                difficultyLevel = DifficultyLevel.Medium;
            }
            else if (typeInput == "H")
            {
                difficultyLevel = DifficultyLevel.Hard;
            }
            else
            {
                Console.WriteLine("Invalid type");
                return new List<Drink>();
            }

            List<Drink> foundDrinks = searchService.SearchByDifficultyLevel(difficultyLevel);

            if (foundDrinks.Count > 0)
            {
                Console.WriteLine($"Found {foundDrinks.Count} drink(s) with the difficulty level '{difficultyLevel}':");
                foreach (var drink in foundDrinks)
                {
                    Console.WriteLine($"- {drink.Name}");
                    viewer.DisplayDrinkDetails(drink);
                }
            }
            else
            {
                Console.WriteLine($"No drinks found with the difficulty level '{difficultyLevel}'.");
            }

            return foundDrinks;
        }

        private List<Drink> SearchByGlassType()
        {
            Console.WriteLine("Enter glass type (e.g., Highball, Martini):");
            string input = Console.ReadLine();
            GlassType glassType;
            if (Enum.TryParse(input, out glassType))
            {
                List<Drink> foundDrinks = searchService.SearchByGlassType(glassType);

                if (foundDrinks.Count > 0)
                {
                    Console.WriteLine($"Found {foundDrinks.Count} drink(s) with the glass type '{glassType}':");
                    foreach (var drink in foundDrinks)
                    {
                        Console.WriteLine($"- {drink.Name}");
                        viewer.DisplayDrinkDetails(drink);
                    }
                }
                else
                {
                    Console.WriteLine($"No drinks found with the glass type '{glassType}'.");
                }

                return foundDrinks;
            }
            Console.WriteLine("Invalid type");
            return new List<Drink>();
        }


        private List<Drink> SearchByFlavorProfile()
        {
            Console.WriteLine("Enter flavor profile (e.g., Sweet, Sour):");
            var input = Console.ReadLine();
            FlavorProfile profile;
            if (Enum.TryParse(input, true, out profile))
            {
                List<Drink> foundDrinks = searchService.SearchByFlavorProfile(profile);

                if (foundDrinks.Count > 0)
                {
                    Console.WriteLine($"Found {foundDrinks.Count} drink(s) with the flavor profile '{profile}':");
                    foreach (var drink in foundDrinks)
                    {
                        Console.WriteLine($"- {drink.Name}");
                        viewer.DisplayDrinkDetails(drink);
                    }
                }
                else
                {
                    Console.WriteLine($"No drinks found with the flavor profile '{profile}'.");
                }

                return foundDrinks;
            }
            Console.WriteLine("Invalid type");
            return new List<Drink>();
        }


        private List<Drink> SearchByOccasionType()
        {
            Console.WriteLine("Enter occasion type (e.g., Party, Dinner):");
            string input = Console.ReadLine();
            OccasionType occasionType;
            if (Enum.TryParse(input, true, out occasionType))
            {
                List<Drink> foundDrinks = searchService.SearchByOccasionType(occasionType);

                if (foundDrinks.Count > 0)
                {
                    Console.WriteLine($"Found {foundDrinks.Count} drink(s) with the occasion type '{occasionType}':");
                    foreach (var drink in foundDrinks)
                    {
                        Console.WriteLine($"- {drink.Name}");
                        viewer.DisplayDrinkDetails(drink);
                    }
                }
                else
                {
                    Console.WriteLine($"No drinks found with the occasion type '{occasionType}'.");
                }

                return foundDrinks;
            }
            Console.WriteLine("Invalid type");
            return new List<Drink>();
        }

    }
}