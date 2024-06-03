using MixologyMatrix.Domain.Entity;
using MixologyMatrix.Domain.Enums;

namespace MixologyMatrix.App.Abstract
{
    public interface IDrinkSearchService
    {
        List<AlcoholicDrink> SaerchByAlcoholType(AlcoholType alcoholType);

        List<Drink> SaerchByDifficultyLevel(DifficultyLevel difficultyLevel);

        List<Drink> SaerchByFlavorProfile(FlavorProfile flavorProfile);

        List<Drink> SaerchByGlassType(GlassType glassType);

        List<Drink> SaerchByOccasionType(OccasionType occasionType);

        List<Drink> SearchByDrinkName(string name);

        List<Drink> SearchByDrinkType(DrinkType drinkType);
    }
}