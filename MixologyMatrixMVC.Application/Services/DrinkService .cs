using MixologyMatrixMVC.Core.Entities;
using MixologyMatrixMVC.Core.Enums;
using MixologyMatrixMVC.Core.Interfaces;
using System.Collections.Generic;

namespace MixologyMatrixMVC.Application.Services
{
    public class DrinkService : IDrinkService
    {
        private readonly IDrinkRepository _drinkRepository;

        public DrinkService(IDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }

        public Drink GetById(int id)
        {
            return _drinkRepository.GetById(id);
        }

        public IEnumerable<Drink> GetAll()
        {
            return _drinkRepository.GetAll();
        }

        public void Add(Drink drink)
        {
            _drinkRepository.Add(drink);
        }

        public void Update(Drink drink)
        {
            _drinkRepository.Update(drink);
        }

        public void Delete(int id)
        {
            _drinkRepository.Delete(id);
        }

        public IEnumerable<Drink> SearchByName(string name)
        {
            return _drinkRepository.SearchByName(name);
        }

        public IEnumerable<Drink> SearchByType(DrinkType drinkType)
        {
            return _drinkRepository.SearchByType(drinkType);
        }

        public IEnumerable<Drink> SearchByDifficultyLevel(DifficultyLevel difficultyLevel)
        {
            return _drinkRepository.SearchByDifficultyLevel(difficultyLevel);
        }

        public IEnumerable<Drink> SearchByGlassType(GlassType glassType)
        {
            return _drinkRepository.SearchByGlassType(glassType);
        }

        public IEnumerable<Drink> SearchByFlavorProfile(FlavorProfile flavorProfile)
        {
            return _drinkRepository.SearchByFlavorProfile(flavorProfile);
        }

        public IEnumerable<Drink> SearchByOccasionType(OccasionType occasionType)
        {
            return _drinkRepository.SearchByOccasionType(occasionType);
        }
    }
}
