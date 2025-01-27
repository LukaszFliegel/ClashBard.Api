using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class FightInExtraRank : TowSpecialRule
{
    private static string ShortDescription = "Fight in extra rank";
    private static string LongDescription = "A model with this special rule may make a supporting attacks. Certain weapons, such as thrusting or throwing spears, allow warriors not in the fighting rank to attack from behind their comrades.";

    public FightInExtraRank()
        : base(TowSpecialRuleType.FightInExtraRank,
            ShortDescription,
            LongDescription,
            printInSummary: false)
    {

    }
}
