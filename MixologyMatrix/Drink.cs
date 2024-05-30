using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixologyMatrix
{
    public class Drink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DrinkType Type { get; set; }
        public string Ingredients { get; set; }
        public string Steps { get; set; }
        public AlcoholType Alcohol { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
        public GlassType GlassType { get; set; }
        public FlavorProfile FlavorProfile { get; set; }
        public OccasionType OccasionType { get; set; }

        public Drink(int id,string name, DrinkType type, string ingredients, string steps, AlcoholType alcohol, DifficultyLevel difficultyLevel, GlassType glassType, FlavorProfile flavorProfile, OccasionType occasionType)
        {
            Id = id;
            Name = name;
            Type = type;
            Ingredients = ingredients;
            Steps = steps;
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
