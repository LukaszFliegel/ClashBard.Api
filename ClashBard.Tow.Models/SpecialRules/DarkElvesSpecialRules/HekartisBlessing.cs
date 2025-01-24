using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class HekartisBlessing : TowSpecialRule
{
    private static string ShortDescription = "Reroll failed Casting roll";
    private static string LongDescription = "Once per game, a model with this special rule may re-roll a single failed Casting roll.";

    public HekartisBlessing()
        : base(TowSpecialRuleType.HekartisBlessing,
            ShortDescription,
            LongDescription)
    {

    }
}
