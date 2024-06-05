using MixologyMatrix.Domain.Entity;
using MixologyMatrix.Domain.Enums;
using System.IO;

namespace MixologyMatrix.Tests
{
    public class DrinkManagerTests
    {
        [Fact]
        public void AddDrink_ShouldAddNewNonAlcoholicDrink()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nN\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            // Act
            drinkManager.AddDrink();

            // Assert
            Assert.Single(drinks);
            var addedDrink = drinks[0];
            Assert.Equal("Cola", addedDrink.Name);
            Assert.Equal(DrinkType.NonAlcoholic, addedDrink.Type);
            Assert.Equal(DifficultyLevel.Medium, addedDrink.DifficultyLevel);
            Assert.Equal(GlassType.Martini, addedDrink.GlassType);
            Assert.Equal(FlavorProfile.Sour, addedDrink.FlavorProfile);
            Assert.Equal(OccasionType.Dinner, addedDrink.OccasionType);
        }

        [Fact]
        public void AddDrink_ShouldAddNewAlcoholicDrink()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nA\n1\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            // Act
            drinkManager.AddDrink();

            // Assert
            Assert.Single(alcoholicDrinks);
            var addedDrink = alcoholicDrinks[0];
            Assert.Equal("Cola", addedDrink.Name);
            Assert.Equal(DrinkType.Alcoholic, addedDrink.Type);
            Assert.Equal(AlcoholType.Rum, addedDrink.Alcohol);
            Assert.Equal(DifficultyLevel.Medium, addedDrink.DifficultyLevel);
            Assert.Equal(GlassType.Martini, addedDrink.GlassType);
            Assert.Equal(FlavorProfile.Sour, addedDrink.FlavorProfile);
            Assert.Equal(OccasionType.Dinner, addedDrink.OccasionType);
        }

        [Fact]
        public void EditDrink_Should_UpdateDrinkName_WhenNewNameIsProvided_Alcoholic()
        {
            //Arange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nA\n1\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var editConsoleInput = new StringReader("1\nEditNameAlcoholicDrink\nA\n\n\n\n\n\n\n\n\n");
            Console.SetIn(editConsoleInput);

            // Act
            drinkManager.EditDrink();

            // Assert
            var editedDrink = alcoholicDrinks[0];
            Assert.Equal("EditNameAlcoholicDrink", editedDrink.Name);
        }

        [Fact]
        public void EditDrink_Should_UpdateDrinkName_WhenNoNewNameIsProvided_Alcoholic()
        {
            //Arange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nA\n1\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var editConsoleInput = new StringReader("1\n\nA\n\n\n\n\n\n\n\n\n");
            Console.SetIn(editConsoleInput);

            // Act
            drinkManager.EditDrink();

            // Assert
            var editedDrink = alcoholicDrinks[0];
            Assert.Equal("Cola", editedDrink.Name);
        }

        [Fact]
        public void EditDrink_Should_UpdateDrinkTypeToAlcoholic_WhenTypeIsProvidedAsNonAlcoholic()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nN\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var editConsoleInput = new StringReader("1\n\nA\n1\n\n\n\n\n\n\n\n");
            Console.SetIn(editConsoleInput);

            // Act
            drinkManager.EditDrink();

            //Assert
            Assert.Single(alcoholicDrinks);
            var editedDrink = alcoholicDrinks[0];
            Assert.Equal(DrinkType.Alcoholic, editedDrink.Type);
        }

        [Fact]
        public void EditDrink_Should_UpdateDrinkTypeToNonAlcoholic_WhenTypeIsProvidedAsAlcoholic()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("1\nCola\nA\n1\n1\n1\n1\n1\n1\nSugar\n\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var editConsoleInput = new StringReader("1\n\nN\n\n\n\n1\n\n\n\n");
            Console.SetIn(editConsoleInput);

            // Act
            drinkManager.EditDrink();

            //Assert
            Assert.Single(drinks);
            var editedDrink = drinks[0];
            Assert.Equal(DrinkType.NonAlcoholic, editedDrink.Type);
        }

        [Fact]
        public void EditDrink_Should_UpdateAlcoholTypeToVodka_WhenNewAlcoholTypeIsProvidedRum()
        {
            //Arange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nA\n1\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var editConsoleInput = new StringReader("1\n\nA\n0\n\n\n\n\n\n\n\n");
            Console.SetIn(editConsoleInput);

            // Act
            drinkManager.EditDrink();

            // Assert
            var editedDrink = alcoholicDrinks[0];
            Assert.Equal(AlcoholType.Vodka, editedDrink.Alcohol);
        }

        [Fact]
        public void EditDrink_Should_KeepAlcoholTypeUnchanged_WhenNoNewAlcoholTypeIsProvided()
        {
            //Arange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nA\n1\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var editConsoleInput = new StringReader("1\n\nA\n\n\n\n\n\n\n\n\n");
            Console.SetIn(editConsoleInput);

            // Act
            drinkManager.EditDrink();

            // Assert
            var editedDrink = alcoholicDrinks[0];
            Assert.Equal(AlcoholType.Rum, editedDrink.Alcohol);
        }

        [Fact]
        public void EditDrink_Should_UpdateDifficultyLevelToHard_WhenNewDifficultyLevelIsProvidedToMedium()
        {
            //Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nA\n1\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var editConsoleInput = new StringReader("1\n\nA\n\n2\n\n\n\n\n\n\n");
            Console.SetIn(editConsoleInput);

            // Act
            drinkManager.EditDrink();

            // Assert
            var editedDrink = alcoholicDrinks[0];
            Assert.Equal(DifficultyLevel.Hard, editedDrink.DifficultyLevel);
        }

        [Fact]
        public void EditDrink_Should_KeepDifficultyLevelUnchanged_WhenNoNewDifficultyLevelIsProvided()
        {
            //Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nA\n1\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var editConsoleInput = new StringReader("1\n\n\n\n\n\n\n\n\n\n\n");
            Console.SetIn(editConsoleInput);

            // Act
            drinkManager.EditDrink();

            // Assert
            var editedDrink = alcoholicDrinks[0];
            Assert.Equal(DifficultyLevel.Medium, editedDrink.DifficultyLevel);
        }

        [Fact]
        public void EditDrink_Should_UpdateGlassTypeToHighball_WhenNewGlassTypeIsProvidedMartini()
        {
            //Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nN\n1\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var editConsoleInput = new StringReader("1\n\n\n\n0\n\n\n\n\n\n");
            Console.SetIn(editConsoleInput);

            // Act
            drinkManager.EditDrink();

            // Assert
            var editedDrink = drinks[0];
            Assert.Equal(GlassType.Highball, editedDrink.GlassType);
        }

        [Fact]
        public void EditDrink_Should_KeepGlassTypeUnchanged_WhenNoNewGlassTypeIsProvided()
        {
            //Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nN\n1\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var editConsoleInput = new StringReader("1\n\n\n\n\n\n\n\n\n\n");
            Console.SetIn(editConsoleInput);

            // Act
            drinkManager.EditDrink();

            // Assert
            var editedDrink = drinks[0];
            Assert.Equal(GlassType.Martini, editedDrink.GlassType);
        }

        [Fact]
        public void EditDrink_Should_UpdateFlavorProfileToSweet_WhenNewFlavorProfileIsProvidedSour()
        {
            //Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nN\n1\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var editConsoleInput = new StringReader("1\n\n\n\n\n0\n\n\n\n\n");
            Console.SetIn(editConsoleInput);

            // Act
            drinkManager.EditDrink();

            // Assert
            var editedDrink = drinks[0];
            Assert.Equal(FlavorProfile.Sweet, editedDrink.FlavorProfile);
        }

        [Fact]
        public void EditDrink_Should_KeepFlavorProfileUnchanged_WhenNoNewFlavorProfileIsProvided()
        {
            //Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nN\n1\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var editConsoleInput = new StringReader("1\n\n\n\n\n\n\n\n\n\n");
            Console.SetIn(editConsoleInput);

            // Act
            drinkManager.EditDrink();

            // Assert
            var editedDrink = drinks[0];
            Assert.Equal(FlavorProfile.Sour, editedDrink.FlavorProfile);
        }

        [Fact]
        public void EditDrink_Should_UpdateOccasionTypeToParty_WhenNewOccasionTypeIsProvidedDinner()
        {
            //Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nN\n1\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var editConsoleInput = new StringReader("1\n\n\n\n\n\n0\n\n\n\n");
            Console.SetIn(editConsoleInput);

            // Act
            drinkManager.EditDrink();

            // Assert
            var editedDrink = drinks[0];
            Assert.Equal(OccasionType.Party, editedDrink.OccasionType);
        }

        [Fact]
        public void EditDrink_Should_KeepOccasionTypeUnchanged_WhenNoNewOccasionTypeIsProvided()
        {
            //Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nN\n1\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var editConsoleInput = new StringReader("1\n\n\n\n\n\n\n\n\n\n");
            Console.SetIn(editConsoleInput);

            // Act
            drinkManager.EditDrink();

            // Assert
            var editedDrink = drinks[0];
            Assert.Equal(OccasionType.Dinner, editedDrink.OccasionType);
        }

        [Fact]
        public void EditDrink_Should_UpdateIngredients_WhenNewIngredientsAreProvided()
        {
            //Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nN\n1\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var editConsoleInput = new StringReader("1\n\n\n\n\n\n\nWater\n\n\n");
            Console.SetIn(editConsoleInput);

            // Act
            drinkManager.EditDrink();

            // Assert
            var editedDrink = drinks[0];
            var expectedIngredients = ("Water");
            Assert.Equal(expectedIngredients, editedDrink.Ingredients);
        }

        [Fact]
        public void EditDrink_Should_UpdateSteps_WhenNewStepsAreProvided()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nN\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            // Wprowadzenie poprawnych danych do edycji napoju
            var editConsoleInput = new StringReader("1\n\n\n\n\n\n\n\nMix Remix");
            Console.SetIn(editConsoleInput);

            // Act
            drinkManager.EditDrink();

            // Assert
            var editedDrink = drinks[0];
            Assert.Equal("Mix Remix", editedDrink.Steps);
        }

        [Fact]
        public void EditDrink_Should_KeepDataUnchanged_WhenNoChangesAreMade()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nN\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            // Wprowadzenie poprawnych danych do edycji napoju
            var editConsoleInput = new StringReader("1\n\n\n\n\n\n\n\n\n");
            Console.SetIn(editConsoleInput);

            // Act
            drinkManager.EditDrink();

            // Assert
            var editedDrink = drinks[0];
            var editIngredients = "Sugar";
            var editSteps = "Mix";
            var editName = "Cola";
            Assert.Equal(editName, editedDrink.Name);
            Assert.Equal(DrinkType.NonAlcoholic, editedDrink.Type);
            Assert.Equal(DifficultyLevel.Medium, editedDrink.DifficultyLevel);
            Assert.Equal(GlassType.Martini, editedDrink.GlassType);
            Assert.Equal(FlavorProfile.Sour, editedDrink.FlavorProfile);
            Assert.Equal(OccasionType.Dinner, editedDrink.OccasionType);
            Assert.Equal(editIngredients, editedDrink.Ingredients);
            Assert.Equal(editSteps, editedDrink.Steps);
        }

        [Fact]
        public void EditDrink_Should_ReturnError_WhenDrinkIdNotFound()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nN\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            // Wprowadzenie niepoprawnego identyfikatora napoju do edycji
            var editConsoleInput = new StringReader("2");
            Console.SetIn(editConsoleInput);

            // Zapamiêtaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            drinkManager.EditDrink();

            // Przywróæ poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));

            // Pobierz wynik zapisany w konsoli
            string output = stringWriter.ToString().Trim();

            // Assert
            Assert.Contains("Drink with ID 2 not found.", output);
        }
    }
}