using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class SandAPTurnUserCharged : TowSpecialRule
{
    private static string ShortDescription = "S and AP only on turn user charged";
    private static string LongDescription = "S and AP only on turn user charged";

    public SandAPTurnUserCharged()
        : base(TowSpecialRuleType.SandAPTurnUserCharged,
            ShortDescription,
            LongDescription)
    {

    }
}
