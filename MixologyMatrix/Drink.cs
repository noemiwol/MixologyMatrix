using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixologyMatrix
{
    public class Drink
    {
        public string Name { get; set; }
        public DrinkType Type { get; set; }
        public string Ingredients { get; set; }
        public AlcoholType Alcohol { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
        public GlassType GlassType { get; set; }
        public FlavorProfile FlavorProfile { get; set; }
        public OccasionType OccasionType { get; set; }

        public Drink(string name, DrinkType type, string ingredients, AlcoholType alcohol, DifficultyLevel difficultyLevel, GlassType glassType, FlavorProfile flavorProfile, OccasionType occasionType)
        {
            Name = name;
            Type = type;
            Ingredients = ingredients;
            Alcohol = alcohol;
            DifficultyLevel = difficultyLevel;
            GlassType = glassType;
            FlavorProfile = flavorProfile;
            OccasionType = occasionType;
        }
    

    public override string ToString()
        {
            return $"{Name} ({Type}): {Ingredients}";
        }
    }
}
