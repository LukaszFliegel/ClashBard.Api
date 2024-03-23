using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class SeaDragonCloak : TowSpecialRule
{
    private static new string ShortDescription = "+1 armor save vs non-magical shooting";
    private static new string LongDescription = "A model with this special rule improves its armour value by 1 (to a maximum of 2+) against non-magical shooting attacks.";

    public SeaDragonCloak()
        : base(TowSpecialRuleType.SeaDragonCloak,
            ShortDescription,
            LongDescription)
    {

    }
}
