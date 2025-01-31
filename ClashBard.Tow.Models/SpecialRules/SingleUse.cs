using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class SingleUse : TowSpecialRule
{
    private static string ShortDescription = "Single use";
    private static string LongDescription = "Single use.";

    public SingleUse()
        : base(TowSpecialRuleType.SingleUse,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}
