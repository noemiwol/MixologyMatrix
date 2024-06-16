using MixologyMatrix.Domain.Entity;
using MixologyMatrix.Domain.Enums;

namespace MixologyMatrix.Tests
{
    public class DrinkViewerTests
    {
        [Fact]
        public void DisplayDrinkDetails_ShouldPrintDrinkDetails_WhenDrinkIsNonAlcoholic()
        {
            // Arrange
            var drinks = new List<Drink> {
             new Drink(1, "VirginMartini", DrinkType.NonAlcoholic, "Ingredients", "Steps", DifficultyLevel.Easy, GlassType.Cocktail, FlavorProfile.Sweet, OccasionType.Party)};
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var displayDrink = new DrinkViewer(drinks, alcoholicDrinks);

            // Utwórz StringWriter do przechwytywania wyjścia konsoli
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act: Przechwyć wyjście z metody DisplayDrinkDetails
                displayDrink.DisplayDrinkDetails(drinks.First());

                // Znormalizuj oczekiwane wyjście przy użyciu Environment.NewLine
                string expectedOutput = $"ID: 1{Environment.NewLine}Name: VirginMartini{Environment.NewLine}Type: NonAlcoholic{Environment.NewLine}Ingredients: Ingredients{Environment.NewLine}Steps: Steps{Environment.NewLine}Difficulty Level: Easy{Environment.NewLine}Glass Type: Cocktail{Environment.NewLine}Flavor Profile: Sweet{Environment.NewLine}Occasion Type: Party{Environment.NewLine}--------------------";

                // Assert: Sprawdź, czy znormalizowane oczekiwane wyjście jest równe z znormalizowanym rzeczywistym wyjściem do konsoli
                Assert.Equal(expectedOutput, sw.ToString().Trim());
            }
        }

        [Fact]
        public void DisplayDrinkDetails_ShouldPrintDrinkDetails_WhenDrinkIsAlcoholic()
        {
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink> { new AlcoholicDrink(1, "Martini", DrinkType.Alcoholic, "Ingredients", "Steps", DifficultyLevel.Easy, GlassType.Martini, FlavorProfile.Other, OccasionType.Relaxation, AlcoholType.Other) };
            var displayDrink = new DrinkViewer(drinks, alcoholicDrinks);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act: Przechwyć wyjście z metody DisplayDrinkDetails
                displayDrink.DisplayDrinkDetails(alcoholicDrinks.First());

                // Znormalizuj oczekiwane wyjście przy użyciu Environment.NewLine
                string expectedOutput = $"ID: 1{Environment.NewLine}Name: Martini{Environment.NewLine}Type: Alcoholic{Environment.NewLine}Ingredients: Ingredients{Environment.NewLine}Steps: Steps{Environment.NewLine}Difficulty Level: Easy{Environment.NewLine}Glass Type: Martini{Environment.NewLine}Flavor Profile: Other{Environment.NewLine}Occasion Type: Relaxation{Environment.NewLine}Alcohol: Other{Environment.NewLine}--------------------";

                // Assert: Sprawdź, czy znormalizowane oczekiwane wyjście jest równe z znormalizowanym rzeczywistym wyjściem do konsoli
                Assert.Equal(expectedOutput, sw.ToString().Trim());
            }
        }

        [Fact]
        public void DisplayDrinkDetails_ShouldHandleNullIngredientsAndSteps_WhenDrinkIsNonAlcoholic()
        {
            // Arrange
            var drinks = new List<Drink> {
                new Drink(1, "VirginMartini", DrinkType.NonAlcoholic, null, null, DifficultyLevel.Easy, GlassType.Cocktail, FlavorProfile.Sweet, OccasionType.Party)
            };
            var alcoholicDrinks = new List<AlcoholicDrink>();
            var displayDrink = new DrinkViewer(drinks, alcoholicDrinks);

            // Utwórz StringWriter do przechwytywania wyjścia konsoli
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act: Przechwyć wyjście z metody DisplayDrinkDetails
                displayDrink.DisplayDrinkDetails(drinks.First());

                // Znormalizuj oczekiwane wyjście przy użyciu Environment.NewLine
                string expectedOutput = $"ID: 1{Environment.NewLine}Name: VirginMartini{Environment.NewLine}Type: NonAlcoholic{Environment.NewLine}Ingredients: {Environment.NewLine}Steps: {Environment.NewLine}Difficulty Level: Easy{Environment.NewLine}Glass Type: Cocktail{Environment.NewLine}Flavor Profile: Sweet{Environment.NewLine}Occasion Type: Party{Environment.NewLine}--------------------";

                // Assert: Sprawdź, czy znormalizowane oczekiwane wyjście jest równe z znormalizowanym rzeczywistym wyjściem do konsoli
                Assert.Equal(expectedOutput, sw.ToString().Trim());
            }
        }

        [Fact]
        public void DisplayDrinkDetails_ShouldHandleNullIngredientsAndStep_WhenDrinkIsAlcoholic()
        {
            var drinks = new List<Drink>();
            var alcoholicDrinks = new List<AlcoholicDrink> { new AlcoholicDrink(1, "Martini", DrinkType.Alcoholic, null, null, DifficultyLevel.Easy, GlassType.Martini, FlavorProfile.Other, OccasionType.Relaxation, AlcoholType.Other) };
            var displayDrink = new DrinkViewer(drinks, alcoholicDrinks);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act: Przechwyć wyjście z metody DisplayDrinkDetails
                displayDrink.DisplayDrinkDetails(alcoholicDrinks.First());

                // Znormalizuj oczekiwane wyjście przy użyciu Environment.NewLine
                string expectedOutput = $"ID: 1{Environment.NewLine}Name: Martini{Environment.NewLine}Type: Alcoholic{Environment.NewLine}Ingredients: {Environment.NewLine}Steps: {Environment.NewLine}Difficulty Level: Easy{Environment.NewLine}Glass Type: Martini{Environment.NewLine}Flavor Profile: Other{Environment.NewLine}Occasion Type: Relaxation{Environment.NewLine}Alcohol: Other{Environment.NewLine}--------------------";

                // Assert: Sprawdź, czy znormalizowane oczekiwane wyjście jest równe z znormalizowanym rzeczywistym wyjściem do konsoli
                Assert.Equal(expectedOutput, sw.ToString().Trim());
            }
        }
    }
}