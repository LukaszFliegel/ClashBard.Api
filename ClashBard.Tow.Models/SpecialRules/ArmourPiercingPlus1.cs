using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class ArmourPiercingPlus1 : TowSpecialRule
{
    private static string ShortDescription = "+1 AP";
    private static string LongDescription = "+1 AP";

    public ArmourPiercingPlus1()
        : base(TowSpecialRuleType.ArmourPiercingPlus1,
            ShortDescription,
            LongDescription,
            printShortDescription: false)
    {

    }
}
