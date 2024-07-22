using MixologyMatrixMVC.Core.Entities;
using MixologyMatrixMVC.Core.Enums;
using MixologyMatrixMVC.Core.Interfaces;

namespace MixologyMatrixMVC.Infrastructure.Repositories
{
    public class AlcoholicDrinkRepository : IAlcoholicDrinkRepository
    {
        private List<AlcoholicDrink> _alcoholicDrinks = new List<AlcoholicDrink>();
        public AlcoholicDrink GetById(int id) => _alcoholicDrinks.FirstOrDefault(d => d.Id == id);

        public IEnumerable<AlcoholicDrink> GetAll() => _alcoholicDrinks;

        public void Add(AlcoholicDrink drink) => _alcoholicDrinks.Add(drink);

        public void Update(AlcoholicDrink drink)
        {
            var index = _alcoholicDrinks.FindIndex(d => d.Id == drink.Id);
            if (index >= 0) _alcoholicDrinks[index] = drink;
        }

        public void Delete(int id) => _alcoholicDrinks.RemoveAll(d => d.Id == id);

        public IEnumerable<AlcoholicDrink> SearchByAlcoholType(AlcoholType alcoholType) =>
            _alcoholicDrinks.Where(d => d.Alcohol == alcoholType);
    }
}
