using MixologyMatrixMVC.Core.Entities;
using MixologyMatrixMVC.Core.Enums;
using MixologyMatrixMVC.Core.Interfaces;

namespace MixologyMatrixMVC.Infrastructure.Repositories
{
    public class DrinkRepository : IDrinkRepository
    {
        private List<Drink> _drinks = new List<Drink>();

        public Drink GetById(int id) => _drinks.FirstOrDefault(d => d.Id == id);

        public IEnumerable<Drink> GetAll() => _drinks;

        public void Add(Drink drink) => _drinks.Add(drink);

        public void Update(Drink drink)
        {
            var index = _drinks.FindIndex(d => d.Id == drink.Id);
            if (index >= 0) _drinks[index] = drink;
        }

        public void Delete(int id) => _drinks.RemoveAll(d => d.Id == id);

        public IEnumerable<Drink> SearchByName(string name) =>
            _drinks.Where(d => d.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

        public IEnumerable<Drink> SearchByType(DrinkType drinkType) =>
            _drinks.Where(d => d.Type == drinkType);

        public IEnumerable<Drink> SearchByDifficultyLevel(DifficultyLevel difficultyLevel) =>
            _drinks.Where(d => d.DifficultyLevel == difficultyLevel);

        public IEnumerable<Drink> SearchByGlassType(GlassType glassType) =>
            _drinks.Where(d => d.GlassType == glassType);

        public IEnumerable<Drink> SearchByFlavorProfile(FlavorProfile flavorProfile) =>
            _drinks.Where(d => d.FlavorProfile == flavorProfile);

        public IEnumerable<Drink> SearchByOccasionType(OccasionType occasionType) =>
            _drinks.Where(d => d.OccasionType == occasionType);
    }
}
