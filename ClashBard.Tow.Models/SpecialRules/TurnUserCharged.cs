using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class TurnUserCharged : TowSpecialRule
{
    private static string ShortDescription = "Turn user charged only";
    private static string LongDescription = "Turn user charged only";

    public TurnUserCharged()
        : base(TowSpecialRuleType.TurnUserCharged,
            ShortDescription,
            LongDescription)
    {

    }
}
