using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class FightinExtraRankOnTurnUserCharged : TowSpecialRule
{
    private static new string ShortDescription = "Fight in Extra Rank on turn user charged";
    private static new string LongDescription = "Fight in Extra Rank on turn user charged";

    public FightinExtraRankOnTurnUserCharged()
        : base(TowSpecialRuleType.FightinExtraRankonturnusercharged,
            ShortDescription,
            LongDescription)
    {

    }
}
