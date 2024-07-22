using MixologyMatrixMVC.Core.Enums;
using System.Text;

namespace MixologyMatrixMVC.Core.Entities
{
    public class Drink
    {
        public int Id { get; set; }
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
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Name: {Name}");
            stringBuilder.AppendLine($"Type: {Type}");
            stringBuilder.AppendLine($"Ingredients: {Ingredients}");
            stringBuilder.AppendLine($"Steps: {Steps}");
            stringBuilder.AppendLine($"Difficulty Level: {DifficultyLevel}");
            stringBuilder.AppendLine($"Glass Type: {GlassType}");
            stringBuilder.AppendLine($"Flavor Profile: {FlavorProfile}");
            stringBuilder.AppendLine($"Occasion Type: {OccasionType}");

            return stringBuilder.ToString();
        }
    }
}
