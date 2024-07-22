using MixologyMatrixMVC.Core.Entities;
using MixologyMatrixMVC.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixologyMatrixMVC.Core.Interfaces
{
    public interface IAlcoholicDrinkRepository
    {
        // CRUD Operations
        new AlcoholicDrink GetById(int id);
        new IEnumerable<AlcoholicDrink> GetAll();
        new void Add(AlcoholicDrink drink);
        new void Update(AlcoholicDrink drink);
        new void Delete(int id);

        // Search Operations
        IEnumerable<AlcoholicDrink> SearchByAlcoholType(AlcoholType alcoholType);
    }
}
