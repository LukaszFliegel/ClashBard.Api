using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class FightInExtraRank : TowSpecialRule
{
    private static new string ShortDescription = "A model with this special rule may make a supporting attacks. Certain weapons, such as thrusting or throwing spears, allow warriors not in the fighting rank to attack from behind their comrades.";
    private static new string LongDescription = "A model with this special rule may make a supporting attacks. Certain weapons, such as thrusting or throwing spears, allow warriors not in the fighting rank to attack from behind their comrades.";

    public FightInExtraRank()
        : base(TowSpecialRuleType.FightInExtraRank,
            ShortDescription,
            LongDescription)
    {

    }
}
