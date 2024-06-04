using MixologyMatrix.App.Abstract;
using MixologyMatrix.Domain.Entity;
using MixologyMatrix.Domain.Enums;
using System.Xml.Linq;

namespace MixologyMatrix.App.Concrete
{
    public class DrinkSearchService : IDrinkSearchService
    {
        private List<Drink> drinks;
        private List<AlcoholicDrink> alcoholicDrinks;

        public DrinkSearchService(List<Drink> drinks, List<AlcoholicDrink> alcoholicDrinks)
        {
            this.drinks = drinks;
            this.alcoholicDrinks = alcoholicDrinks;
        }

        public List<Drink> SearchByDrinkName(string name)
        {
            var results = drinks.Where(d => d.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            results.AddRange(alcoholicDrinks.Where(d => d.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList());
            return results;
        }

        public List<Drink> SearchByDrinkType(DrinkType drinkType)
        {
            var results = drinks.Where(d => d.Type == drinkType).ToList();
            results.AddRange(alcoholicDrinks.Where(d => d.Type == drinkType).ToList());
            return results;
        }

        public List<AlcoholicDrink> SearchByAlcoholType(AlcoholType alcoholType)
        {
            return alcoholicDrinks.Where(a => a.Alcohol == alcoholType).ToList();
        }

        public List<Drink> SearchByDifficultyLevel(DifficultyLevel difficultyLevel)
        {
            var results = drinks.Where(d => d.DifficultyLevel == difficultyLevel).ToList();
            results.AddRange(alcoholicDrinks.Where(d => d.DifficultyLevel == difficultyLevel).ToList());
            return results;
        }

        public List<Drink> SearchByGlassType(GlassType glassType)
        {
            var results = drinks.Where(g => g.GlassType == glassType).ToList();
            results.AddRange(alcoholicDrinks.Where(g => g.GlassType == glassType).ToList());
            return results;
        }

        public List<Drink> SearchByFlavorProfile(FlavorProfile flavorProfile)
        {
            var results = drinks.Where(f => f.FlavorProfile == flavorProfile).ToList();
            results.AddRange(alcoholicDrinks.Where(f => f.FlavorProfile == flavorProfile).ToList());
            return results;
        }

        public List<Drink> SearchByOccasionType(OccasionType occasionType)
        {
            var results = drinks.Where(o => o.OccasionType == occasionType).ToList();
            results.AddRange(alcoholicDrinks.Where(o => o.OccasionType == occasionType).ToList());
            return results;
        }
    }
}