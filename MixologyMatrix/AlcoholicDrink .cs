﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixologyMatrix
{
    public class AlcoholicDrink : Drink
    {
        public AlcoholType Alcohol { get; set; }
        public AlcoholicDrink(int id, string name, DrinkType type, string ingredients, string steps,
                          DifficultyLevel difficultyLevel, GlassType glassType, FlavorProfile flavorProfile,
                          OccasionType occasionType, AlcoholType alcohol)
        : base(id, name, type, ingredients, steps, difficultyLevel, glassType, flavorProfile, occasionType)
        {
            Alcohol = alcohol;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Alcohol: {Alcohol}";
        }

    }
}
