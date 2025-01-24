using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class FireAndFlee : TowSpecialRule
{
    private static string ShortDescription = "The boldest of warriors armed with missile weapons will face down a charging enemy with volleys of fire, before turning and fleeing at the last possible moment.";
    private static string LongDescription = "A unit with this special rule that is also armed with missile weapons may declare that it will 'Fire & Flee' as a charge reaction: Fire & Flee. The unit launches a volley of weapons fire before turning to flee from the enemy. If a unit with this special rule is armed with missile weapons and can draw a line of sight to the charging unit, it may declare that it will Fire & Flee. The unit will Stand & Shoot before turning tail and fleeing from the charge. However, due to the time spent shooting at the charging foe, when making its Flee roll the unit rolls two D6 and discards the lowest result. If both dice roll the same result, discard either. Note that, if the distance between this unit and the charging unit is less than the Movement characteristic of the charging unit, this unit must either Hold or Flee.";

    public FireAndFlee()
        : base(TowSpecialRuleType.FireAndFlee,
            ShortDescription,
            LongDescription)
    {

    }
}
