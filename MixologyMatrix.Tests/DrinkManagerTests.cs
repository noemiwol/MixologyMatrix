using MixologyMatrix.Domain.Entity;
using MixologyMatrix.Domain.Enums;

namespace MixologyMatrix.Tests
{
    public class DrinkManagerTests
    {
        [Fact]
        public void AddDrink_ShouldAddNewNonAlcoholicDrink()
        {
            // Arrange
            var drinks = new List<Drink>(); // Pusta lista napojów
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
            var drinks = new List<Drink>(); // Pusta lista napojów
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
        public void EditDrink_Should_UpdateDrinkName_WhenNewNameIsProvided_ForAl()
        {
            //Arange
            var drinks = new List<Drink>(); // Pusta lista napojów
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(drinks, alcoholicDrinks);

            var consolInput = new StringReader("Cola\nA\n1\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consolInput);

            drinkManager.AddDrink();

            var editConsilInput = new StringReader("1\nEditNameAlcoholicDrink\nA\n1\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(editConsilInput);

            // Act
            drinkManager.EditDrink();

            // Assert
            var editedDrink = alcoholicDrinks[0];
            Assert.Equal("EditNameAlcoholicDrink", editedDrink.Name);
            Assert.Equal(DrinkType.Alcoholic, editedDrink.Type);
            Assert.Equal(AlcoholType.Rum, editedDrink.Alcohol);
            Assert.Equal(DifficultyLevel.Medium, editedDrink.DifficultyLevel);
            Assert.Equal(GlassType.Martini, editedDrink.GlassType);
            Assert.Equal(FlavorProfile.Sour, editedDrink.FlavorProfile);
            Assert.Equal(OccasionType.Dinner, editedDrink.OccasionType);

        }
    }
}