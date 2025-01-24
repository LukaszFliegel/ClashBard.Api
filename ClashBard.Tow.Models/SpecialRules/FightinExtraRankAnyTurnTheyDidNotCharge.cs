using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class FightinExtraRankAnyTurnTheyDidNotCharge : TowSpecialRule
{
    private static string ShortDescription = "Fight in Extra Rank any turn they did not charge";
    private static string LongDescription = "Fight in Extra Rank any turn they did not charge";

    public FightinExtraRankAnyTurnTheyDidNotCharge()
        : base(TowSpecialRuleType.FightinExtraRankanyturntheydidnotcharge,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}
