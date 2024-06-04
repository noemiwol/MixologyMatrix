using MixologyMatrix.Domain.Entity;
using MixologyMatrix.Domain.Enums;

namespace MixologyMatrix.App.Abstract
{
    public interface IDrinkSearchService
    {
        List<AlcoholicDrink> SearchByAlcoholType(AlcoholType alcoholType);

        List<Drink> SearchByDifficultyLevel(DifficultyLevel difficultyLevel);

        List<Drink> SearchByFlavorProfile(FlavorProfile flavorProfile);

        List<Drink> SearchByGlassType(GlassType glassType);

        List<Drink> SearchByOccasionType(OccasionType occasionType);

        List<Drink> SearchByDrinkName(string name);

        List<Drink> SearchByDrinkType(DrinkType drinkType);
    }   
}