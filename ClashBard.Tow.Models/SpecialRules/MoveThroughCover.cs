using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class MoveThroughCover : TowSpecialRule
{
    private static string ShortDescription = "No Mv penalty when moving through diff/dang terrain, can reroll 1 of Dangerous Terrain tests";
    private static string LongDescription = "Models with this special rule do not suffer any modifiers to their Movement characteristic for moving through difficult or dangerous terrain. In addition, a model with this special rule may re-roll any rolls of 1 when making Dangerous Terrain tests.";

    public MoveThroughCover()
        : base(TowSpecialRuleType.MoveThroughCover,
            ShortDescription,
            LongDescription)
    {

    }
}
