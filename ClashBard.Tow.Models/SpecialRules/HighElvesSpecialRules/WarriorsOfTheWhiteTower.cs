using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;

public class WarriorsOfTheWhiteTower : TowSpecialRule
{
    private static string ShortDescription = "Strike First & Cleaving Blow.";
    private static string LongDescription = "Models with this special rule have the Strike First and Cleaving Blow special rules, representing their supreme mastery of the blade taught in the White Tower of Hoeth.";

    public WarriorsOfTheWhiteTower()
        : base(TowSpecialRuleType.WarriorsOfTheWhiteTower, ShortDescription, LongDescription)
    {
    }
}
