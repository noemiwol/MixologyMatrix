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
        private static int nextId = 1;
        private DrinkSearchService searchService;

        public DrinkManager(List<Drink> drinks)
        {
            this.drinks = drinks;
            this.searchService = new DrinkSearchService(drinks);
        }
        public void DisplayDrinkDetails(Drink drink)
        {
            Console.WriteLine($"ID: {drink.Id}");
            Console.WriteLine($"Name: {drink.Name}");
            Console.WriteLine($"Type: {drink.Type}");
            Console.WriteLine($"Ingredients: {drink.Ingredients}");
            Console.WriteLine($"Steps: {drink.Steps}");
            if(drink is AlcoholicDrink alcoholicDrink)
            {
                Console.WriteLine($"Alcohol: {alcoholicDrink.Alcohol}");
            } 
            Console.WriteLine($"Difficulty Level: {drink.DifficultyLevel}");
            Console.WriteLine($"Glass Type: {drink.GlassType}");
            Console.WriteLine($"Flavor Profile: {drink.FlavorProfile}");
            Console.WriteLine($"Occasion Type: {drink.OccasionType}");
            Console.WriteLine(new string('-', 20));
        }
        public void AddDrink()
        {
            Console.WriteLine("Adding a new drink recipe...");

            Console.Write("Enter the name of the drink: ");
            string name = Console.ReadLine();

            Console.WriteLine("Is the drink alcoholic or non-alcoholic? (A/N)");
            string typeInput = Console.ReadLine().ToUpper();
            DrinkType type = (typeInput == "A") ? DrinkType.Alcoholic : DrinkType.NonAlcoholic;

            AlcoholType alcohol = AlcoholType.None;
            if(type == DrinkType.Alcoholic)
            {
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
                break;
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
               break;
            }
            

            Console.Write("Enter the ingredients of the drink: ");
            string ingredients = Console.ReadLine();

            Console.Write("Enter the steps of the drink: ");
            string steps = Console.ReadLine();

            int newDrinkId = nextId++;
            Drink newDrink;
            if (type == DrinkType.Alcoholic)
            {
                newDrink = new AlcoholicDrink(newDrinkId, name, type, ingredients, steps, difficultyLevel, glassType, flavorProfile, occasionType, alcohol);
            }
            else
            {
                newDrink = new Drink(newDrinkId, name, type, ingredients, steps, difficultyLevel, glassType, flavorProfile, occasionType);
            }
            drinks.Add(newDrink);
            Console.WriteLine("New drink added successfully!");
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
            string name = Console.ReadLine();

            List<Drink> foundDrinks = searchService.SearchByDrinkName(name);

            if (foundDrinks.Count > 0)
            {
                Console.WriteLine($"Found {foundDrinks.Count} drink(s) with the name '{name}':");
                foreach (var drink in foundDrinks)
                {
                    Console.WriteLine($"- {drink.Name}");
                    DisplayDrinkDetails(drink);
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
            List<Drink> foundDrinks = searchService.SearchByDrinkType(drinkType);

            if (foundDrinks.Count > 0)
            {
                Console.WriteLine($"Found {foundDrinks.Count} drink(s) with the type '{drinkType}':");
                foreach (var drink in foundDrinks)
                {
                    Console.WriteLine($"- {drink.Name}");
                    DisplayDrinkDetails(drink); // Wywołanie metody wyświetlającej szczegóły drinku
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
                    DisplayDrinkDetails(drink);
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

            List<AlcoholicDrink> matchingDrinks = searchService.SaerchByAlcoholType(alcoholType);

            if (matchingDrinks.Count > 0)
            {
                Console.WriteLine($"Found {matchingDrinks.Count} drink(s) with the alcohol type '{alcoholType}':");
                foreach (var drink in matchingDrinks)
                {
                    Console.WriteLine($"- {drink.Name}");
                    DisplayDrinkDetails(drink);
                }
            }
            else
            {
                Console.WriteLine($"No drinks found with the alcohol type '{alcoholType}'.");
            }

            // Cast the list of AlcoholicDrink to a list of Drink
            return matchingDrinks.Cast<Drink>().ToList();
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

            List<Drink> foundDrinks = searchService.SaerchByDifficultyLevel(difficultyLevel);

            if (foundDrinks.Count > 0)
            {
                Console.WriteLine($"Found {foundDrinks.Count} drink(s) with the difficulty level '{difficultyLevel}':");
                foreach (var drink in foundDrinks)
                {
                    Console.WriteLine($"- {drink.Name}");
                    DisplayDrinkDetails(drink); 
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
                List<Drink> foundDrinks = searchService.SaerchByGlassType(glassType);

                if (foundDrinks.Count > 0)
                {
                    Console.WriteLine($"Found {foundDrinks.Count} drink(s) with the glass type '{glassType}':");
                    foreach (var drink in foundDrinks)
                    {
                        Console.WriteLine($"- {drink.Name}");
                        DisplayDrinkDetails(drink); 
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
            string input = Console.ReadLine();
            FlavorProfile profile;
            if (Enum.TryParse(input, out profile))
            {
                List<Drink> foundDrinks = searchService.SaerchByFlavorProfile(profile);

                if (foundDrinks.Count > 0)
                {
                    Console.WriteLine($"Found {foundDrinks.Count} drink(s) with the flavor profile '{profile}':");
                    foreach (var drink in foundDrinks)
                    {
                        Console.WriteLine($"- {drink.Name}");
                        DisplayDrinkDetails(drink); 
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
            if (Enum.TryParse(input, out occasionType))
            {
                List<Drink> foundDrinks = searchService.SaerchByOccasionType(occasionType);

                if (foundDrinks.Count > 0)
                {
                    Console.WriteLine($"Found {foundDrinks.Count} drink(s) with the occasion type '{occasionType}':");
                    foreach (var drink in foundDrinks)
                    {
                        Console.WriteLine($"- {drink.Name}");
                        DisplayDrinkDetails(drink);
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

        public void ListAllDrinks()
        {
            if(drinks.Count == 0)
            {
                Console.WriteLine("No drinks available");
                return;
            }

            Console.WriteLine("Listing all drink recipes ");
            foreach (var drink in drinks)
            {
                Console.WriteLine($"- {drink.Name}");
                DisplayDrinkDetails(drink);
            }
        }

        public void EditDrink()
        {
            ListAllDrinks();
            Console.WriteLine("Enter the ID of the drink you want to edit:");
            int drinkId;
            if (!int.TryParse(Console.ReadLine(), out drinkId))
            {
                Console.WriteLine("Invalid ID format. Please enter a valid number.");
                return;
            }

            Drink drinkToEdit = drinks.FirstOrDefault(d => d.Id == drinkId);
            if (drinkToEdit == null)
            {
                Console.WriteLine($"Drink with ID {drinkId} not found.");
                return;
            }

            Console.WriteLine("Editing Drink:");
            DisplayDrinkDetails(drinkToEdit);

            Console.Write("Enter the new name of the drink (or press Enter to keep current): ");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {
                drinkToEdit.Name = name;
            }

            Console.WriteLine("Is the drink alcoholic or non-alcoholic? (A/N or press Enter to keep current)");
            string typeInput = Console.ReadLine().ToUpper();
            if (!string.IsNullOrEmpty(typeInput))
            {
                DrinkType type = (typeInput == "A") ? DrinkType.Alcoholic : DrinkType.NonAlcoholic;
                drinkToEdit.Type = type;
            }

            if(drinkToEdit.Type == DrinkType.Alcoholic && drinkToEdit is AlcoholicDrink alcoholicDrink)
            {
                AlcoholType alcohol;
            while (true)
            {
                Console.WriteLine("Select the alcohol type (or press Enter to keep current):");
                foreach (AlcoholType alcoholType in Enum.GetValues(typeof(AlcoholType)))
                {
                    Console.WriteLine($"{(int)alcoholType}. {alcoholType}");
                }

                Console.Write("Enter the number corresponding to the alcohol type: ");
                string alcoholInput = Console.ReadLine();
                if (string.IsNullOrEmpty(alcoholInput)) break;

                int alcoholIndex;
                if (!int.TryParse(alcoholInput, out alcoholIndex) || !Enum.IsDefined(typeof(AlcoholType), alcoholIndex))
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number corresponding to the alcohol type.");
                    continue;
                }

                alcohol = (AlcoholType)alcoholIndex;
                alcoholicDrink.Alcohol = alcohol;
                break;
            }

         }
            
            DifficultyLevel difficultyLevel;
            while (true)
            {
                Console.WriteLine("Select the difficulty level (or press Enter to keep current):");
                foreach (DifficultyLevel difficulty in Enum.GetValues(typeof(DifficultyLevel)))
                {
                    Console.WriteLine($"{(int)difficulty}. {difficulty}");
                }

                Console.Write("Enter the number corresponding to the difficulty level: ");
                string difficultyInput = Console.ReadLine();
                if (string.IsNullOrEmpty(difficultyInput)) break;

                int difficultyLevelIndex;
                if (!int.TryParse(difficultyInput, out difficultyLevelIndex) || !Enum.IsDefined(typeof(DifficultyLevel), difficultyLevelIndex))
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number corresponding to the difficulty level.");
                    continue;
                }

                difficultyLevel = (DifficultyLevel)difficultyLevelIndex;
                drinkToEdit.DifficultyLevel = difficultyLevel;
                break;
            }

            GlassType glassType;
            while (true)
            {
                Console.WriteLine("Select the glass type (or press Enter to keep current):");
                foreach (GlassType glass in Enum.GetValues(typeof(GlassType)))
                {
                    Console.WriteLine($"{(int)glass}. {glass}");
                }

                Console.Write("Enter the number corresponding to the glass type: ");
                string glassInput = Console.ReadLine();
                if (string.IsNullOrEmpty(glassInput)) break;

                int glassIndex;
                if (!int.TryParse(glassInput, out glassIndex) || !Enum.IsDefined(typeof(GlassType), glassIndex))
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number corresponding to the glass type.");
                    continue;
                }

                glassType = (GlassType)glassIndex;
                drinkToEdit.GlassType = glassType;
                break;
            }

            FlavorProfile flavorProfile;
            while (true)
            {
                Console.WriteLine("Select the flavor profile (or press Enter to keep current):");
                foreach (FlavorProfile flavor in Enum.GetValues(typeof(FlavorProfile)))
                {
                    Console.WriteLine($"{(int)flavor}. {flavor}");
                }

                Console.Write("Enter the number corresponding to the flavor profile: ");
                string flavorInput = Console.ReadLine();
                if (string.IsNullOrEmpty(flavorInput)) break;

                int flavorIndex;
                if (!int.TryParse(flavorInput, out flavorIndex) || !Enum.IsDefined(typeof(FlavorProfile), flavorIndex))
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number corresponding to the flavor profile.");
                    continue;
                }

                flavorProfile = (FlavorProfile)flavorIndex;
                drinkToEdit.FlavorProfile = flavorProfile;
                break;
            }

            OccasionType occasionType;
            while (true)
            {
                Console.WriteLine("Select the occasion type (or press Enter to keep current):");
                foreach (OccasionType occasion in Enum.GetValues(typeof(OccasionType)))
                {
                    Console.WriteLine($"{(int)occasion}. {occasion}");
                }

                Console.Write("Enter the number corresponding to the occasion type: ");
                string occasionInput = Console.ReadLine();
                if (string.IsNullOrEmpty(occasionInput)) break;

                int occasionIndex;
                if (!int.TryParse(occasionInput, out occasionIndex) || !Enum.IsDefined(typeof(OccasionType), occasionIndex))
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number corresponding to the occasion type.");
                    continue;
                }
                occasionType = (OccasionType)occasionIndex;
                drinkToEdit.OccasionType = occasionType;
                break;
            }

            Console.Write("Enter the new ingredients of the drink (or press Enter to keep current): ");
            string ingredients = Console.ReadLine();
            if (!string.IsNullOrEmpty(ingredients))
            {
                drinkToEdit.Ingredients = ingredients;
            }

            Console.Write("Enter the new steps of the drink (or press Enter to keep current): ");
            string steps = Console.ReadLine();
            if (!string.IsNullOrEmpty(steps))
            {
                drinkToEdit.Steps = steps;
            }

            Console.WriteLine($"Drink ID {drinkId} updated successfully!");
        }

    }
}
