using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixologyMatrix
{
    public class DrinkSearchService
    {
        private List<Drink> drinks; 

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
        public List<Drink> SaerchByAlcoholType(AlcoholType alcoholType)
        {
            return drinks.Where(a => a.Alcohol == alcoholType).ToList();
        }

        public List<Drink> SaerchByDifficultyLevel(DifficultyLevel difficultyLevel)
        {
            return drinks.Where(d => d.DifficultyLevel == difficultyLevel).ToList();
        }

        public List<Drink> SaerchByGlassType(GlassType  glassType)
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
