using MixologyMatrix.Domain.Entity;
using MixologyMatrix.Domain.Enums;

namespace MixologyMatrix.Tests
{
    public class DrinkManagerTests
    {
        [Fact]
        public void AddDrink_ShouldAddNewNonAlcoholicDrink()
        {
            //Arange
            var drink = new List<Drink>();
            var drinkManager = new DrinkManager(drink);

            var consolInput = new StringReader("Cola\nN\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consolInput);

            //Act
            drinkManager.AddDrink();

            //Assert
            Assert.Single(drink);
            var addedDrink = drink[0];
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
            //Arange
            var alcoholicDrink = new List<AlcoholicDrink>();
            var drinkManager = new DrinkManager(alcoholicDrink);

            var consolInput = new StringReader("Cola\nA\n1\n1\n1\n1\n1\n1\nSugar\nMix\n");
            Console.SetIn(consolInput);

            // Act
            drinkManager.AddDrink();

            //Assert
            Assert.Single(alcoholicDrink);
            var addedDrink = alcoholicDrink[0];
            Assert.Equal("Cola", addedDrink.Name);
            Assert.Equal(DrinkType.Alcoholic, addedDrink.Type);
            Assert.Equal(AlcoholType.Rum, addedDrink.Alcohol);
            Assert.Equal(DifficultyLevel.Medium, addedDrink.DifficultyLevel);
            Assert.Equal(GlassType.Martini, addedDrink.GlassType);
            Assert.Equal(FlavorProfile.Sour, addedDrink.FlavorProfile);
            Assert.Equal(OccasionType.Dinner, addedDrink.OccasionType);
        }
    }
}