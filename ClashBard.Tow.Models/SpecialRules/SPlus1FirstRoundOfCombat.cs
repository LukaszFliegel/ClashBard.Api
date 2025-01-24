using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class SPlus1FirstRoundOfCombat : TowSpecialRule
{
    private static string ShortDescription = "S+1 first round of combat only";
    private static string LongDescription = "S+1 first round of combat only";

    public SPlus1FirstRoundOfCombat()
        : base(TowSpecialRuleType.SPlus1FirstRoundOfCombat,
            ShortDescription,
            LongDescription)
    {

    }
}
