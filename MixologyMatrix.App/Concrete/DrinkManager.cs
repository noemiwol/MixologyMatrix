using MixologyMatrix.App.Concrete;
using MixologyMatrix.Domain.Entity;
using MixologyMatrix.Domain.Enums;

namespace MixologyMatrix
{
    public class DrinkManager
    {
        private List<AlcoholicDrink> alcoholicDrinks = new List<AlcoholicDrink>();
        private List<Drink> drinks = new List<Drink>();
        private int nextId = 1;
        private DrinkSearchService searchService;
        private DrinkViewer viewer;
        public DrinkManager(List<Drink> drinks, List<AlcoholicDrink> alcoholicDrinks)
        {
            this.drinks = drinks;
            this.alcoholicDrinks = alcoholicDrinks;
            this.viewer = new DrinkViewer(drinks, alcoholicDrinks); 
            this.searchService = new DrinkSearchService(drinks, alcoholicDrinks); 
        }

        /*public DrinkManager(List<AlcoholicDrink> alcoholicDrink)
        {
            this.alcoholicDrinks = alcoholicDrink;
        }

        public DrinkManager(List<Drink> drinks, DrinkViewer viewer)
        {
            this.drinks = drinks;
            this.viewer = viewer;
            this.searchService = new DrinkSearchService(drinks);
        }

        public DrinkManager(List<AlcoholicDrink> alcoholicDrink, DrinkViewer viewer)
        {
            this.alcoholicDrink = alcoholicDrink;
            this.viewer = viewer;
        }*/

        public void AddDrink()
        {
            Console.WriteLine("Adding a new drink recipe...");

            Console.Write("Enter the name of the drink: ");
            var name = Console.ReadLine();


            Console.WriteLine("Is the drink alcoholic or non-alcoholic? (A/N)");
            var typeInput = Console.ReadLine().ToUpper();
            DrinkType type = (typeInput == "A") ? DrinkType.Alcoholic : DrinkType.NonAlcoholic;

            AlcoholType alcohol = AlcoholType.None;
            if (type == DrinkType.Alcoholic)
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
                if (!int.TryParse(Console.ReadLine(), out glassIndex) || !Enum.IsDefined(typeof(GlassType), glassIndex))
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number corresponding to the  glasss type.");
                    continue;
                }
                glassType = (GlassType)glassIndex;
                break;
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
                if (!int.TryParse(Console.ReadLine(), out flavorIndex) || !Enum.IsDefined(typeof(FlavorProfile), flavorIndex))
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
                if (!int.TryParse(Console.ReadLine(), out occasionIndex) || !Enum.IsDefined(typeof(OccasionType), occasionIndex))
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number corresponding to the  occasion type.");
                    continue;
                }
                occasionType = (OccasionType)occasionIndex;
                break;
            }

            Console.Write("Enter the ingredients of the drink: ");
            var ingredients = Console.ReadLine();

            Console.Write("Enter the steps of the drink: ");
            var steps = Console.ReadLine();

            var newDrinkId = nextId++;
            if (type == DrinkType.Alcoholic)
            {
                var newAlcoholicDrink = new AlcoholicDrink(newDrinkId, name, type, ingredients, steps, difficultyLevel, glassType, flavorProfile, occasionType, alcohol);
                alcoholicDrinks.Add(newAlcoholicDrink); 
            }
            else
            {
                var newDrink = new Drink(newDrinkId, name, type, ingredients, steps, difficultyLevel, glassType, flavorProfile, occasionType);
                drinks.Add(newDrink);
            }
            Console.WriteLine("New drink added successfully!");
        }

        public void EditDrink()
        {
            if ((drinks == null || drinks.Count == 0) && (alcoholicDrinks == null || alcoholicDrinks.Count == 0))
            {
                Console.WriteLine("No drinks available to edit.");
                return;
            }

            var viewer = new DrinkViewer(drinks, alcoholicDrinks);
            viewer.ListAllDrinks();
            Console.WriteLine("Enter the ID of the drink you want to edit:");
            int drinkId;
            if (!int.TryParse(Console.ReadLine(), out drinkId))
            {
                Console.WriteLine("Invalid ID format. Please enter a valid number.");
                return;
            }

            Drink drinkToEdit = drinks.FirstOrDefault(d => d.Id == drinkId) ?? alcoholicDrinks.FirstOrDefault(d => d.Id == drinkId);
            if (drinkToEdit == null)
            {
                Console.WriteLine($"Drink with ID {drinkId} not found.");
                return;
            }

            Console.WriteLine("Editing Drink:");
            viewer.DisplayDrinkDetails(drinkToEdit);

            Console.Write("Enter the new name of the drink (or press Enter to keep current): ");
            var name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {
                drinkToEdit.Name = name;
            }

            Console.WriteLine("Is the drink alcoholic or non-alcoholic? (A/N or press Enter to keep current)");
            var typeInput = Console.ReadLine().ToUpper();
            if (!string.IsNullOrEmpty(typeInput))
            {
                DrinkType type = (typeInput == "A") ? DrinkType.Alcoholic : DrinkType.NonAlcoholic;
                drinkToEdit.Type = type;
            }

            if (drinkToEdit.Type == DrinkType.Alcoholic && drinkToEdit is AlcoholicDrink alcoholicDrink)
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
                    var alcoholInput = Console.ReadLine();
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
                var difficultyInput = Console.ReadLine();
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
                var flavorInput = Console.ReadLine();
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
                var occasionInput = Console.ReadLine();
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
            var ingredients = Console.ReadLine();
            if (!string.IsNullOrEmpty(ingredients))
            {
                drinkToEdit.Ingredients = ingredients;
            }

            Console.Write("Enter the new steps of the drink (or press Enter to keep current): ");
            var steps = Console.ReadLine();
            if (!string.IsNullOrEmpty(steps))
            {
                drinkToEdit.Steps = steps;
            }

            Console.WriteLine($"Drink ID {drinkId} updated successfully!");
        }
    }
}