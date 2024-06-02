using MixologyMatrix.Domain.Common;
using MixologyMatrix.Domain.Enums;

namespace MixologyMatrix.Domain.Entity
{
    public class Drink : BaseEntity
    {
        public string Name { get; set; }
        public DrinkType Type { get; set; }
        public string Ingredients { get; set; }
        public string Steps { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
        public GlassType GlassType { get; set; }
        public FlavorProfile FlavorProfile { get; set; }
        public OccasionType OccasionType { get; set; }

        public Drink(int id, string name, DrinkType type, string ingredients, string steps, DifficultyLevel difficultyLevel, GlassType glassType, FlavorProfile flavorProfile, OccasionType occasionType)
        {
            Id = id;
            Name = name;
            Type = type;
            Ingredients = ingredients;
            Steps = steps;
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