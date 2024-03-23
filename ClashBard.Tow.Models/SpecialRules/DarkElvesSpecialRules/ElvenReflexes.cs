using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class ElvenReflexes : TowSpecialRule
{
    private static new string ShortDescription = "+1 Initiative first round of combat";
    private static new string LongDescription = "A model with this special rule (but not its mount) has a +1 modifier to its Initiative characteristic (to a maximum of 10) during the first round of any combat.";

    public ElvenReflexes()
        : base(TowSpecialRuleType.ElvenReflexes,
            ShortDescription,
            LongDescription)
    {

    }
}
