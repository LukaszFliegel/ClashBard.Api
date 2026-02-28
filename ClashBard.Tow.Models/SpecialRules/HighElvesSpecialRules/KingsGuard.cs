using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;

public class KingsGuard : TowSpecialRule
{
    private static string ShortDescription = "Never Panic if General dies nearby.";
    private static string LongDescription = "Units with this special rule never have to take a Panic test as a result of the General being removed from play.";

    public KingsGuard()
        : base(TowSpecialRuleType.KingsGuard, ShortDescription, LongDescription)
    {
    }
}
