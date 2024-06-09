using MixologyMatrix.Domain.Entity;

namespace MixologyMatrix.Tests
{
    public class DrinkSearchManagerTests
    {
        [Fact]
        public void DrinkSearchManager_ShouldReturnEmptyList_WhenDrinkNameDoesNotExist()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);
            var drinkSearchManager = new DrinkSearchManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("VirginMartini\nN\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var searchConsoleInput = new StringReader("coal");
            Console.SetIn(searchConsoleInput);

            // Zapamiętaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            var foundDrinks = drinkSearchManager.SearchByDrinkName();

            // Przywróć poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));

            // Pobierz wynik zapisany w konsoli
            string output = stringWriter.ToString().Trim();

            // Assert
            Assert.Single(drinks);
            Assert.Empty(foundDrinks);
            Assert.Contains("No drinks found with the name 'coal'.", output);
        }

        [Fact]
        public void DrinkSearchManager_ShouldReturnDrinkByName_WhenNameExists()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);
            var drinkSearchManager = new DrinkSearchManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("VirginMartini\nN\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var searchConsoleInput = new StringReader("VirginMartini");
            Console.SetIn(searchConsoleInput);

            // Zapamiętaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            var foundDrinks = drinkSearchManager.SearchByDrinkName();

            // Przywróć poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));

            // Pobierz wynik zapisany w konsoli
            string output = stringWriter.ToString().Trim();

            // Assert
            Assert.Single(drinks);
            Assert.NotEmpty(foundDrinks);
            Assert.Contains("Found 1 drink(s) with the name 'VirginMartini':", output);
            Assert.Contains("- VirginMartini", output);
        }

        [Fact]
        public void DrinkSearchManager_ShouldReturnEmptyList_WhenDrinkTypeIsInvalid()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);
            var drinkSearchManager = new DrinkSearchManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("VirginMartini\nN\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var searchConsoleInput = new StringReader("Winko");
            Console.SetIn(searchConsoleInput);

            // Zapamiętaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            var foundDrinks = drinkSearchManager.SearchByDrinkType();

            // Przywróć poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));

            // Pobierz wynik zapisany w konsoli
            string output = stringWriter.ToString().Trim();

            // Assert
            Assert.Contains("Invalid type", output);
        }

        [Fact]
        public void DrinkSearchManager_ShouldReturnEmptyList_WhenAlcoholTypeIsInvalid()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);
            var drinkSearchManager = new DrinkSearchManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("VirginMartini\nN\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var searchConsoleInput = new StringReader("Winko");
            Console.SetIn(searchConsoleInput);

            // Zapamiętaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            var foundDrinks = drinkSearchManager.SearchByAlcoholType();

            // Przywróć poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));

            // Pobierz wynik zapisany w konsoli
            string output = stringWriter.ToString().Trim();

            // Assert
            Assert.Contains("Invalid type", output);
        }

        [Fact]
        public void DrinkSearchManager_ShouldReturnEmptyList_WhenAlcoholTypeDoesNotExist()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);
            var drinkSearchManager = new DrinkSearchManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("VirginMartini\nN\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var searchConsoleInput = new StringReader("A");
            Console.SetIn(searchConsoleInput);

            // Zapamiętaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            var foundDrinks = drinkSearchManager.SearchByDrinkType();

            // Przywróć poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));

            // Pobierz wynik zapisany w konsoli
            string output = stringWriter.ToString().Trim();

            // Assert
            Assert.Single(drinks);
            Assert.Empty(foundDrinks);
            Assert.Contains("No drinks found with the type 'Alcoholic'", output);
        }

        [Fact]
        public void DrinkSearchManager_ShouldReturnDrinksByAlcoholType_WhenTypeExists()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);
            var drinkSearchManager = new DrinkSearchManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nA\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            // Act
            drinkManager.AddDrink();

            var searchConsoleInput = new StringReader("A");
            Console.SetIn(searchConsoleInput);

            // Zapamiętaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            var foundDrinks = drinkSearchManager.SearchByDrinkType();

            // Przywróć poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));

            // Pobierz wynik zapisany w konsoli
            string output = stringWriter.ToString().Trim();

            // Assert
            Assert.Single(alcoholicDrinks);
            Assert.NotEmpty(foundDrinks);
            Assert.Contains("Found 1 drink(s) with the type 'Alcoholic'", output);
        }

        [Fact]
        public void DrinkSearchManager_ShouldReturnNonAlcoholicDrinks_WhenTypeExists()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);
            var drinkSearchManager = new DrinkSearchManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("VirginMartini\nN\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var searchConsoleInput = new StringReader("N");
            Console.SetIn(searchConsoleInput);

            // Zapamiętaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            var foundDrinks = drinkSearchManager.SearchByDrinkType();

            // Przywróć poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));

            // Pobierz wynik zapisany w konsoli
            string output = stringWriter.ToString().Trim();

            // Assert
            Assert.Single(drinks);
            Assert.NotEmpty(foundDrinks);
            Assert.Contains("Found 1 drink(s) with the type 'NonAlcoholic'", output);
        }

        [Fact]
        public void DrinkSearchManager_ShouldReturnEmptyList_WhenNonAlcoholicTypeDoesNotExist()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);
            var drinkSearchManager = new DrinkSearchManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nA\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var searchConsoleInput = new StringReader("N");
            Console.SetIn(searchConsoleInput);

            // Zapamiętaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            var foundDrinks = drinkSearchManager.SearchByDrinkType();

            // Przywróć poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));

            // Pobierz wynik zapisany w konsoli
            string output = stringWriter.ToString().Trim();

            // Assert
            Assert.Single(alcoholicDrinks);
            Assert.Empty(foundDrinks);
            Assert.Contains("No drinks found with the type 'NonAlcoholic'", output);
        }

        [Fact]
        public void DrinkSearchManager_ShouldReturnEmptyList_WhenDifficultyLevelIsInvalid()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);
            var drinkSearchManager = new DrinkSearchManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("VirginMartini\nN\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var searchConsoleInput = new StringReader("Winko");
            Console.SetIn(searchConsoleInput);

            // Zapamiętaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            var foundDrinks = drinkSearchManager.SearchByDifficultyLevel();

            // Przywróć poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));

            // Pobierz wynik zapisany w konsoli
            string output = stringWriter.ToString().Trim();

            // Assert
            Assert.Contains("Invalid type", output);
        }

        [Fact]
        public void DrinkSearchManager_ShouldReturnDrinksByDifficultyLevel_WhenLevelExists()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);
            var drinkSearchManager = new DrinkSearchManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nA\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var searchConsoleInput = new StringReader("M");
            Console.SetIn(searchConsoleInput);

            // Zapamiętaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //Act
            var foundDrinks = drinkSearchManager.SearchByDifficultyLevel();

            // Przywróć poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));

            // Pobierz wynik zapisany w konsoli
            string output = stringWriter.ToString().Trim();

            //Assert
            Assert.Single(alcoholicDrinks);
            Assert.NotEmpty(foundDrinks);
            Assert.Contains("Found 1 drink(s) with the difficulty level 'Medium'", output);
        }

        [Fact]
        public void DrinkSearchManager_ShouldReturnEmptyList_WhenDifficultyLevelDoesNotExist()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);
            var drinkSearchManager = new DrinkSearchManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nA\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var searchConsoleInput = new StringReader("E");
            Console.SetIn(searchConsoleInput);

            // Zapamiętaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //Act
            var foundDrinks = drinkSearchManager.SearchByDifficultyLevel();

            // Przywróć poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));

            // Pobierz wynik zapisany w konsoli
            string output = stringWriter.ToString().Trim();

            //Assert
            Assert.Single(alcoholicDrinks);
            Assert.Empty(foundDrinks);
            Assert.Contains("No drinks found with the difficulty level 'Easy'.", output);
        }

        [Fact]
        public void DrinkSearchManager_ShouldReturnEmptyList_WhenGlassTypeIsInvalid()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);
            var drinkSearchManager = new DrinkSearchManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("VirginMartini\nN\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var searchConsoleInput = new StringReader("Winko");
            Console.SetIn(searchConsoleInput);

            // Zapamiętaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            var foundDrinks = drinkSearchManager.SearchByGlassType();

            // Przywróć poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));

            // Pobierz wynik zapisany w konsoli
            string output = stringWriter.ToString().Trim();

            // Assert
            Assert.Contains("Invalid type", output);
        }

        [Fact]
        public void DrinkSearchManager_ShouldReturnDrinksByGlassType_WhenTypeExists()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);
            var drinkSearchManager = new DrinkSearchManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nA\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var searchConsoleInput = new StringReader("Martini");
            Console.SetIn(searchConsoleInput);

            // Zapamiętaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //Act
            var foundDrinks = drinkSearchManager.SearchByGlassType();

            // Przywróć poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));

            // Pobierz wynik zapisany w konsoli
            string output = stringWriter.ToString().Trim();

            //Assert
            Assert.Single(alcoholicDrinks);
            Assert.NotEmpty(foundDrinks);
            Assert.Contains("Found 1 drink(s) with the glass type 'Martini'", output);
        }

        [Fact]
        public void DrinkSearchManager_ShouldReturnEmptyList_WhenGlassTypeDoesNotExist()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);
            var drinkSearchManager = new DrinkSearchManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nA\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var searchConsoleInput = new StringReader("Highball");
            Console.SetIn(searchConsoleInput);

            // Zapamiętaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //Act
            var foundDrinks = drinkSearchManager.SearchByGlassType();

            // Przywróć poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));

            // Pobierz wynik zapisany w konsoli
            string output = stringWriter.ToString().Trim();

            //Assert
            Assert.Single(alcoholicDrinks);
            Assert.Empty(foundDrinks);
            Assert.Contains("No drinks found with the glass type 'Highball'.", output);
        }

        [Fact]
        public void DrinkSearchManager_ShouldReturnEmptyList_WhenFlavorProfileIsInvalid()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);
            var drinkSearchManager = new DrinkSearchManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("VirginMartini\nN\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var searchConsoleInput = new StringReader("Winko");
            Console.SetIn(searchConsoleInput);

            // Zapamiętaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            var foundDrinks = drinkSearchManager.SearchByFlavorProfile();

            // Przywróć poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));

            // Pobierz wynik zapisany w konsoli
            string output = stringWriter.ToString().Trim();

            // Assert
            Assert.Contains("Invalid type", output);
        }

        [Fact]
        public void DrinkSearchManager_ShouldReturnDrinksByFlavorProfile_WhenProfileExists()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);
            var drinkSearchManager = new DrinkSearchManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nA\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var searchConsoleInput = new StringReader("Sour");
            Console.SetIn(searchConsoleInput);

            // Zapamiętaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //Act
            var foundDrinks = drinkSearchManager.SearchByFlavorProfile();

            // Przywróć poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));

            // Pobierz wynik zapisany w konsoli
            string output = stringWriter.ToString().Trim();

            //Assert
            Assert.Single(alcoholicDrinks);
            Assert.NotEmpty(foundDrinks);
            Assert.Contains("Found 1 drink(s) with the flavor profile 'Sour'", output);
        }

        [Fact]
        public void DrinkSearchManager_ShouldReturnEmptyList_WhenFlavorProfileDoesNotExist()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);
            var drinkSearchManager = new DrinkSearchManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nA\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var searchConsoleInput = new StringReader("Sweet");
            Console.SetIn(searchConsoleInput);

            // Zapamiętaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //Act
            var foundDrinks = drinkSearchManager.SearchByFlavorProfile();

            // Przywróć poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));

            // Pobierz wynik zapisany w konsoli
            string output = stringWriter.ToString().Trim();

            //Assert
            Assert.Single(alcoholicDrinks);
            Assert.Empty(foundDrinks);
            Assert.Contains("No drinks found with the flavor profile 'Sweet'.", output);
        }

        [Fact]
        public void DrinkSearchManager_ShouldReturnEmptyList_WhenOccasionTypeIsInvalid()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);
            var drinkSearchManager = new DrinkSearchManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("VirginMartini\nN\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var searchConsoleInput = new StringReader("Winko");
            Console.SetIn(searchConsoleInput);

            // Zapamiętaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            var foundDrinks = drinkSearchManager.SearchByOccasionType();

            // Przywróć poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));

            // Pobierz wynik zapisany w konsoli
            string output = stringWriter.ToString().Trim();

            // Assert
            Assert.Contains("Invalid type", output);
        }

        [Fact]
        public void DrinkSearchManager_ShouldReturnDrinksByOccasionType_WhenTypeExists()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);
            var drinkSearchManager = new DrinkSearchManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nA\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var searchConsoleInput = new StringReader("Dinner");
            Console.SetIn(searchConsoleInput);

            // Zapamiętaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //Act
            var foundDrinks = drinkSearchManager.SearchByOccasionType();

            // Przywróć poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));

            // Pobierz wynik zapisany w konsoli
            string output = stringWriter.ToString().Trim();

            //Assert
            Assert.Single(alcoholicDrinks);
            Assert.NotEmpty(foundDrinks);
            Assert.Contains("Found 1 drink(s) with the occasion type 'Dinner'", output);
        }

        [Fact]
        public void DrinkSearchManager_ShouldReturnEmptyList_WhenOccasionTypeDoesNotExist()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);
            var drinkSearchManager = new DrinkSearchManager(drinks, alcoholicDrinks);

            var consoleInput = new StringReader("Cola\nA\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consoleInput);

            drinkManager.AddDrink();

            var searchConsoleInput = new StringReader("Party");
            Console.SetIn(searchConsoleInput);

            // Zapamiętaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //Act
            var foundDrinks = drinkSearchManager.SearchByOccasionType();

            // Przywróć poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));

            // Pobierz wynik zapisany w konsoli
            string output = stringWriter.ToString().Trim();

            //Assert
            Assert.Single(alcoholicDrinks);
            Assert.Empty(foundDrinks);
            Assert.Contains("No drinks found with the occasion type 'Party'.", output);
        }
    }
}