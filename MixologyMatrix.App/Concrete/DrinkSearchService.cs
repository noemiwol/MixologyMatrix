using MixologyMatrix.App.Abstract;
using MixologyMatrix.Domain.Entity;
using MixologyMatrix.Domain.Enums;

namespace MixologyMatrix.App.Concrete
{
    public class DrinkSearchService : IDrinkSearchService
    {
        private List<Drink> drinks;
        private List<AlcoholicDrink> drinks_;

        public DrinkSearchService(List<Drink> drinks)
        {
            this.drinks = drinks;
        }

        public List<Drink> SearchByDrinkName(string name)
        {
            return drinks.Where(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Drink> SearchByDrinkType(DrinkType drinkType)
        {
            return drinks.Where(d => d.Type == drinkType).ToList();
        }

        public List<AlcoholicDrink> SaerchByAlcoholType(AlcoholType alcoholType)
        {
            return drinks.OfType<AlcoholicDrink>().Where(a => a.Alcohol == alcoholType).ToList();
        }

        public List<Drink> SaerchByDifficultyLevel(DifficultyLevel difficultyLevel)
        {
            return drinks.Where(d => d.DifficultyLevel == difficultyLevel).ToList();
        }

        public List<Drink> SaerchByGlassType(GlassType glassType)
        {
            return drinks.Where(g => g.GlassType == glassType).ToList();
        }

        public List<Drink> SaerchByFlavorProfile(FlavorProfile flavorProfile)
        {
            return drinks.Where(f => f.FlavorProfile == flavorProfile).ToList();
        }

        public List<Drink> SaerchByOccasionType(OccasionType occasionType)
        {
            return drinks.Where(o => o.OccasionType == occasionType).ToList();
        }
    }
}