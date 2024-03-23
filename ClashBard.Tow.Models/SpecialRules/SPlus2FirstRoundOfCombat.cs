using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class SPlus2FirstRoundOfCombat : TowSpecialRule
{
    private static new string ShortDescription = "S+2 first round of combat only";
    private static new string LongDescription = "S+2 first round of combat only";

    public SPlus2FirstRoundOfCombat()
        : base(TowSpecialRuleType.SPlus2FirstRoundOfCombat,
            ShortDescription,
            LongDescription)
    {

    }
}
