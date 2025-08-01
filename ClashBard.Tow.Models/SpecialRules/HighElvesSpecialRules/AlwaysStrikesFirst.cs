using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;

public class AlwaysStrikesFirst : TowSpecialRule
{
    private static string ShortDescription = "Always strikes first in combat";
    private static string LongDescription = "A model with this special rule always strikes first in close combat, regardless of Initiative or charging.";

    public AlwaysStrikesFirst()
        : base(TowSpecialRuleType.AlwaysStrikesFirst,
            ShortDescription,
            LongDescription)
    {

    }
}
