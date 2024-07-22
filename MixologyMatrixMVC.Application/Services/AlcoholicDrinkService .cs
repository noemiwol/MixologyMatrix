using MixologyMatrixMVC.Core.Entities;
using MixologyMatrixMVC.Core.Enums;
using MixologyMatrixMVC.Core.Interfaces;
using MixologyMatrixMVC.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace MixologyMatrixMVC.Infrastructure.Repositories
{
    public class AlcoholicDrinkRepository : IAlcoholicDrinkRepository
    {
        private readonly ApplicationDbContext _context;

        public AlcoholicDrinkRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public AlcoholicDrink GetById(int id)
        {
            return _context.AlcoholicDrinks.Find(id);
        }

        public IEnumerable<AlcoholicDrink> GetAll()
        {
            return _context.AlcoholicDrinks.ToList();
        }

        public void Add(AlcoholicDrink drink)
        {
            _context.AlcoholicDrinks.Add(drink);
            _context.SaveChanges();
        }

        public void Update(AlcoholicDrink drink)
        {
            _context.AlcoholicDrinks.Update(drink);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var drink = _context.AlcoholicDrinks.Find(id);
            if (drink != null)
            {
                _context.AlcoholicDrinks.Remove(drink);
                _context.SaveChanges();
            }
        }

        public IEnumerable<AlcoholicDrink> SearchByAlcoholType(AlcoholType alcoholType)
        {
            return _context.AlcoholicDrinks.Where(d => d.Alcohol == alcoholType).ToList();
        }
    }
}
