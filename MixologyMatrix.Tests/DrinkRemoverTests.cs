using MixologyMatrix.Domain.Entity;
using MixologyMatrix.Domain.Enums;

namespace MixologyMatrix.Tests
{
    public class DrinkRemoverTests
    {
        [Fact]
        public void RemoveDrinkByName_ShouldReturnTrueAndRemoveDrink_WhenDrinkIsFoundInNonAlcoholicListt()
        {
            // Arrange
            var drinks = new List<Drink> { new Drink(1, "VirginMartini", DrinkType.NonAlcoholic, "Description", "Ingredients", DifficultyLevel.Easy, GlassType.Cocktail, FlavorProfile.Sweet, OccasionType.Party) };
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkRemover = new DrinkRemover(drinks, alcoholicDrinks);

            // Act
            bool result = drinkRemover.RemoveDrinkByName("VirginMartini");

            //Assert
            Assert.True(result);
            Assert.Empty(drinks);
        }

        [Fact]
        public void RemoveDrinkByName_ShouldReturnTrueAndRemoveDrink_WhenDrinkIsFoundInAlcoholicList()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink> { new AlcoholicDrink(1, "Martini", DrinkType.Alcoholic, "Ingredients", "steps", DifficultyLevel.Easy, GlassType.Martini, FlavorProfile.Other, OccasionType.Relaxation, AlcoholType.Other) };
            var drinkRemover = new DrinkRemover(drinks, alcoholicDrinks);

            // Act
            bool result = drinkRemover.RemoveDrinkByName("Martini");

            // Assert
            Assert.True(result);
            Assert.Empty(alcoholicDrinks);
        }

        [Fact]
        public void RemoveDrinkByName_ShouldReturnFalseAndPrintMessage_WhenDrinkIsNotFound()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkRemover = new DrinkRemover(drinks, alcoholicDrinks);

            // Zapamiętaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            bool result = drinkRemover.RemoveDrinkByName("NonExistentDrink");

            // Przywróć poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            string output = stringWriter.ToString().Trim();

            // Assert
            Assert.False(result);
            Assert.Contains("Drink 'NonExistentDrink' not found!", output);
        }

        [Fact]
        public void RemoveDrinkByName_ShouldIgnoreCase_WhenSearchingForDrink()
        {
            // Arrange
            var drinks = new List<Drink> { new Drink(1, "Virgin Martini", DrinkType.NonAlcoholic, "Description", "Ingredients", DifficultyLevel.Easy, GlassType.Cocktail, FlavorProfile.Sweet, OccasionType.Party) };
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkRemover = new DrinkRemover(drinks, alcoholicDrinks);

            // Act
            bool result = drinkRemover.RemoveDrinkByName("virgin martini");

            //Assert
            Assert.True(result);
            Assert.Empty(drinks);
        }

        [Fact]
        public void RemoveDrinkByName_ShouldPrintSuccessMessage_WhenDrinkIsRemovedFromNonAlcoholicList()
        {
            // Arrange
            var drinks = new List<Drink> { new Drink(1, "Virgin Martini", DrinkType.NonAlcoholic, "Description", "Ingredients", DifficultyLevel.Easy, GlassType.Cocktail, FlavorProfile.Sweet, OccasionType.Party) };
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkRemover = new DrinkRemover(drinks, alcoholicDrinks);

            // Zapamiętaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            bool result = drinkRemover.RemoveDrinkByName("Virgin Martini");

            // Przywróć poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            string output = stringWriter.ToString().Trim();

            //Assert
            Assert.True(result);
            Assert.Empty(drinks);
            Assert.Contains("Drink 'Virgin Martini' removed successfully!", output);
        }

        [Fact]
        public void RemoveDrinkByName_ShouldPrintSuccessMessage_WhenDrinkIsRemovedFromAlcoholicList()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink> { new AlcoholicDrink(1, "Martini", DrinkType.Alcoholic, "Ingredients", "steps", DifficultyLevel.Easy, GlassType.Martini, FlavorProfile.Other, OccasionType.Relaxation, AlcoholType.Other) };
            var drinkRemover = new DrinkRemover(drinks, alcoholicDrinks);

            // Zapamiętaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            bool result = drinkRemover.RemoveDrinkByName("Martini");

            // Przywróć poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            string output = stringWriter.ToString().Trim();

            // Assert
            Assert.True(result);
            Assert.Empty(alcoholicDrinks);
            Assert.Contains("Drink 'Martini' removed successfully!", output);
        }

        [Fact]
        public void RemoveDrinkByName_ShouldPrintNotFoundMessage_WhenDrinkIsNotFoundInEitherList()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkRemover = new DrinkRemover(drinks, alcoholicDrinks);

            // Zapamiętaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            bool result = drinkRemover.RemoveDrinkByName("NonExistentDrink");

            // Przywróć poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            string output = stringWriter.ToString().Trim();

            // Assert
            Assert.Contains("Drink 'NonExistentDrink' not found!", output);
        }

        [Fact]
        public void RemoveDrinkById_ShouldReturnTrueAndRemoveNonAlcoholicDrink_WhenDrinkExistsInNonAlcoholicList()
        {
            // Arrange
            var drinks = new List<Drink> { new Drink(1, "VirginMartini", DrinkType.NonAlcoholic, "Description", "Ingredients", DifficultyLevel.Easy, GlassType.Cocktail, FlavorProfile.Sweet, OccasionType.Party) };
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkRemover = new DrinkRemover(drinks, alcoholicDrinks);

            // Act
            bool result = drinkRemover.RemoveDrinkById(1);

            //Assert
            Assert.True(result);
            Assert.Empty(drinks);
        }

        [Fact]
        public void RemoveDrinkById_ShouldReturnTrueAndRemoveAlcoholicDrink_WhenDrinkExistsInAlcoholicList()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink> { new AlcoholicDrink(1, "Martini", DrinkType.Alcoholic, "Ingredients", "steps", DifficultyLevel.Easy, GlassType.Martini, FlavorProfile.Other, OccasionType.Relaxation, AlcoholType.Other) };
            var drinkRemover = new DrinkRemover(drinks, alcoholicDrinks);

            // Act
            bool result = drinkRemover.RemoveDrinkById(1);

            // Assert
            Assert.True(result);
            Assert.Empty(alcoholicDrinks);
        }

        [Fact]
        public void RemoveDrinkById_ShouldReturnFalse_WhenDrinkDoesNotExist()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkRemover = new DrinkRemover(drinks, alcoholicDrinks);

            // Zapamiętaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            bool result = drinkRemover.RemoveDrinkById(1);

            // Przywróć poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            string output = stringWriter.ToString().Trim();

            // Assert
            Assert.False(result);
            Assert.Contains("Drink with ID '1' not found!", output);
        }

        [Fact]
        public void RemoveDrinkById_ShouldReturnFalse_WhenIdIsNegative()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkRemover = new DrinkRemover(drinks, alcoholicDrinks);

            // Zapamiętaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            bool result = drinkRemover.RemoveDrinkById(-1);

            // Przywróć poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            string output = stringWriter.ToString().Trim();

            // Assert
            Assert.False(result);
            Assert.Contains("Drink with ID '-1' not found!", output);
        }

        [Fact]
        public void RemoveDrinkById_ShouldReturnFalse_WhenIdIsZero()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkRemover = new DrinkRemover(drinks, alcoholicDrinks);

            // Zapamiętaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            bool result = drinkRemover.RemoveDrinkById(0);

            // Przywróć poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            string output = stringWriter.ToString().Trim();

            // Assert
            Assert.False(result);
            Assert.Contains("Drink with ID '0' not found!", output);
        }

        [Fact]
        public void RemoveDrinkById_ShouldPrintNotFoundMessage_WhenDrinkDoesNotExist()
        {
            // Arrange
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkRemover = new DrinkRemover(drinks, alcoholicDrinks);

            // Zapamiętaj stan konsoli
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            bool result = drinkRemover.RemoveDrinkById(0);

            // Przywróć poprzedni stan konsoli
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            string output = stringWriter.ToString().Trim();

            // Assert
            Assert.Contains("Drink with ID '0' not found!", output);
        }
    }
}