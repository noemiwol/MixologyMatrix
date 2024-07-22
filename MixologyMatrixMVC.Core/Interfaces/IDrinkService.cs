using MixologyMatrixMVC.Core.Entities;
using MixologyMatrixMVC.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixologyMatrixMVC.Core.Interfaces
{
    public interface IDrinkService
    {
        // CRUD Operations
        Drink GetById(int id);
        IEnumerable<Drink> GetAll();
        void Add(Drink drink);
        void Update(Drink drink);
        void Delete(int id);

        // Search Operations
        IEnumerable<Drink> SearchByName(string name);
        IEnumerable<Drink> SearchByType(DrinkType drinkType);
        IEnumerable<Drink> SearchByDifficultyLevel(DifficultyLevel difficultyLevel);
        IEnumerable<Drink> SearchByGlassType(GlassType glassType);
        IEnumerable<Drink> SearchByFlavorProfile(FlavorProfile flavorProfile);
        IEnumerable<Drink> SearchByOccasionType(OccasionType occasionType);
    }
}
