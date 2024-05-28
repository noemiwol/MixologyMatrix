using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixologyMatrix
{
    public class DrinkManager
    {
        private List<Drink> drinks;
        private DrinkSearchService searchService;

        public DrinkManager(List<Drink> drinks)
        {
            this.drinks = drinks;
            this.searchService = new DrinkSearchService(drinks);
        }

        public void AddDrink()
        {
            Console.WriteLine("Adding a new drink recipe...");

            Console.Write("Enter the name of the drink: ");
            string name = Console.ReadLine();

            Console.WriteLine("Is the drink alcoholic or non-alcoholic? (A/N)");
            string typeInput = Console.ReadLine().ToUpper();
            DrinkType type = (typeInput == "A") ? DrinkType.Alcoholic : DrinkType.NonAlcoholic;
            AlcoholType alcohol;
            while (true)
            {
                Console.WriteLine("Select the alcohol type:");
                foreach (AlcoholType alcoholType in Enum.GetValues(typeof(AlcoholType)))
                {
                    Console.WriteLine($"{(int)alcoholType}. {alcoholType}");
                }

                Console.Write("Enter the number corresponding to the alcohol type: ");

                int alcoholIndex;
                if (!int.TryParse(Console.ReadLine(), out alcoholIndex) || !Enum.IsDefined(typeof(AlcoholType), alcoholIndex))
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number corresponding to the alcohol type.");
                    continue;
                }

                alcohol = (AlcoholType)alcoholIndex;
                break;
            }

            DifficultyLevel difficultyLevel;

            while (true)
            {
                Console.WriteLine("Select the difficulty level:");
                foreach (DifficultyLevel difficulty in Enum.GetValues(typeof(DifficultyLevel)))
                {
                    Console.WriteLine($"{(int)difficulty}. {difficulty}");
                }

                Console.Write("Enter the number corresponding to the difficulty level: ");

                int difficultyLevelIndex;
                if (!int.TryParse(Console.ReadLine(), out difficultyLevelIndex) || !Enum.IsDefined(typeof(DifficultyLevel), difficultyLevelIndex))
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number corresponding to the difficulty level.");
                    continue;
                }

                difficultyLevel = (DifficultyLevel)difficultyLevelIndex;
                break;
            }

            GlassType glassType;
            while (true)
            {
                Console.WriteLine("Select the glass type");
                foreach (GlassType glass in Enum.GetValues(typeof(GlassType)))
                {
                    Console.WriteLine($"{(int)glass}.{glass}");
                }

                Console.WriteLine("Enter the number corresponding to the glasss type");

                int glassIndex;
                if(!int.TryParse(Console.ReadLine(), out glassIndex) || !Enum.IsDefined(typeof(GlassType), glassIndex))
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number corresponding to the  glasss type.");
                    continue;
                }
                glassType = (GlassType)glassIndex;
                break ;

            }

            FlavorProfile flavorProfile;
            while (true)
            {
                Console.WriteLine("Select the flavor profile");
                foreach (FlavorProfile flavor in Enum.GetValues(typeof(FlavorProfile)))
                {
                    Console.WriteLine($"{(int)flavor}.{flavor}");
                }

                Console.WriteLine("Enter the number corresponding to the flavor profile");
                int flavorIndex;
                if(!int.TryParse(Console.ReadLine(), out flavorIndex) || !Enum.IsDefined(typeof(FlavorProfile), flavorIndex))
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number corresponding to the  glasss type.");
                    continue;
                }
                flavorProfile = (FlavorProfile)flavorIndex;
            }


            OccasionType occasionType;
            while (true)
            {
                Console.WriteLine("Select the occasion type");
                foreach (OccasionType occasion in Enum.GetValues(typeof(OccasionType)))
                {
                    Console.WriteLine($"{(int)occasion}.{occasion}");
                }

                Console.WriteLine("Enter the number corresponding to the occasion type");
                int occasionIndex;
                if(!int.TryParse(Console.ReadLine(), out occasionIndex) || !Enum.IsDefined(typeof(OccasionType), occasionIndex))
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number corresponding to the  occasion type.");
                    continue;
                }
               occasionType = (OccasionType)occasionIndex;
            }
            

            Console.Write("Enter the ingredients of the drink: ");
            string ingredients = Console.ReadLine();

            Console.Write("Enter the steps of the drink: ");
            string steps = Console.ReadLine();

            Drink newDrink = new Drink(name, type, ingredients, alcohol, difficultyLevel, glassType, flavorProfile, occasionType);

            drinks.Add(newDrink);
            Console.WriteLine("New drink added successfully!");
        }

        public void SearchDrinks()
        {
            Console.WriteLine("Choose a filter to search by:");
            Console.WriteLine("1. Drink Name");
            Console.WriteLine("2. Drink Type");
            Console.WriteLine("3. Alcohol Type");
            Console.WriteLine("4. Difficulty Level");
            Console.WriteLine("5. Glass Type");
            Console.WriteLine("6. Flavor Profile");
            Console.WriteLine("7. Occasion Type");
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
                    results = SearchByDifficultyLevel();
                    break;
                case '5':
                    results = SearchByGlassType();
                    break;
                case '6':
                    results = SearchByFlavorProfile();
                    break;
                case '7':
                    results = SearchByOccasionType();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    return;
            }

            Console.WriteLine("Search results:");
            foreach (var drink in results)
            {
                Console.WriteLine(drink.Name);
            }
        }
        private List<Drink> SearchByDrinkName()
        {
            Console.WriteLine("Enter the name of the drink:");
            string name = Console.ReadLine();

            List<Drink> foundDrinks = searchService.SearchByDrinkName(name);

            if (foundDrinks.Count > 0)
            {
                Console.WriteLine($"Found {foundDrinks.Count} drink(s) with the name '{name}':");
                foreach (var drink in foundDrinks)
                {
                    Console.WriteLine($"- {drink.Name}");
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
            if(typeInput == "A")
            {
                drinkType = DrinkType.Alcoholic;
            }
            else if(typeInput == "N")
            {
                drinkType = DrinkType.NonAlcoholic;
            }
            else
            {
                Console.WriteLine("Invalid type");
                return new List<Drink>();
            }
            return searchService.SearchByDrinkType(drinkType);
        }

        private List<Drink> SearchByAlcoholType()
        {
            Console.WriteLine("Enter alcohol type (e.g., Vodka, Rum, Whiskey):");
            string input = Console.ReadLine();
            AlcoholType alcoholType;
            if (Enum.TryParse(input, out alcoholType))
            {
                return searchService.SaerchByAlcoholType(alcoholType);
            }
            Console.WriteLine("Invalid type");
            return new List<Drink>();
        }
        private List<Drink> SearchByDifficultyLevel()
        {
            Console.WriteLine("Enter difficulty level (Easy, Medium, Hard): (E/M/H)");
            string typeInput = Console.ReadLine().ToUpper();

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

            return searchService.SaerchByDifficultyLevel(difficultyLevel);
        }
        private List<Drink> SearchByGlassType()
        {
            Console.WriteLine("Enter glass type (e.g., Highball, Martini):");
            string input = Console.ReadLine();
            GlassType glassType;
            if (Enum.TryParse(input, out glassType))
            {
                return searchService.SaerchByGlassType(glassType);
            }
            Console.WriteLine("Invalid type");
            return new List<Drink>();
        }
        private List<Drink> SearchByFlavorProfile()
        {
            Console.WriteLine("Enter flavor profile (e.g., Sweet, Sour):");
            string input = Console.ReadLine();
            FlavorProfile profile;
            if (Enum.TryParse(input, out profile))
            {
                return searchService.SaerchByFlavorProfile(profile);
            }
            Console.WriteLine("Invalid type");
            return new List<Drink>();
        }
        private List<Drink> SearchByOccasionType()
        {
            Console.WriteLine("Enter occasion type (e.g., Party, Dinner):");
            string input = Console.ReadLine();
            OccasionType occasionType;
            if(Enum.TryParse(input,out occasionType))
            {
                return searchService.SaerchByOccasionType(occasionType);
            }
            Console.WriteLine("Invalid type");
            return new List<Drink>();
        }
    }
}
