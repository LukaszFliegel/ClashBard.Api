using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Horde : TowSpecialRule
{
    private static string ShortDescription = "+1 max rank bonus";
    private static string LongDescription = "A unit with this special rule may increase the maximum Rank Bonus it can claim (as determined by its troop type) by one.";

    public Horde()
        : base(TowSpecialRuleType.Horde,
            ShortDescription,
            LongDescription)
    {

    }
}
