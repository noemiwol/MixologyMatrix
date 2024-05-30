using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixologyMatrix
{
    public enum DrinkType
    {
        Alcoholic,
        NonAlcoholic
    }

    public enum AlcoholType
    {
        Vodka,
        Rum,
        Whiskey,
        Tequila,
        Gin,
        Brandy,
        Liqueur,
        Other,
        None
    }

    public enum DifficultyLevel
    {
        Easy,
        Medium,
        Hard
    }

    public enum GlassType
    {
        Highball,
        Martini,
        Collins,
        OldFashioned,
        Shot,
        Wine,
        Cocktail,
        Other
    }

    public enum FlavorProfile
    {
        Sweet,
        Sour,
        Bitter,
        Spicy,
        Fruity,
        Herbal,
        Savory,
        Other
    }

    public enum OccasionType
    {
        Party,
        Dinner,
        Celebration,
        Relaxation,
        SpecialEvent,
        Other
    }
}