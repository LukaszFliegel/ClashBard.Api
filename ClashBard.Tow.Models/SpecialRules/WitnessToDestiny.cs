using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class WitnessToDestiny : TowSpecialRule
{
    private static string ShortDescription = "4+ Ward save against wounds in combat.";
    private static string LongDescription = "Models with this special rule have a Ward save (4+) against wounds suffered in combat.";

    public WitnessToDestiny()
        : base(TowSpecialRuleType.WitnessToDestiny, ShortDescription, LongDescription)
    {
    }
}
