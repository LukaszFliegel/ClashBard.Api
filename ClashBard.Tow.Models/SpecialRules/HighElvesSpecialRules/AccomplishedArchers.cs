using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;

public class AccomplishedArchers : TowSpecialRule
{
    private static string ShortDescription = "Accomplished Archers";
    private static string LongDescription = "Models with this special rule are expert marksmen, displaying superior skill with ranged weapons and gaining benefits when using bows and similar missile weapons.";

    public AccomplishedArchers()
        : base(TowSpecialRuleType.AccomplishedArchers,
              ShortDescription,
              LongDescription)
    {
    }
}
