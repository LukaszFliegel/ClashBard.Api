using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Flammable : TowSpecialRule
{
    private static new string ShortDescription = "Some creatures are especially vulnerable to fire. Once flame has been set to their flesh, it will burn out of control.";
    private static new string LongDescription = "A model with this special rule cannot make a Regeneration save against a wound caused by a Flaming attack.";

    public Flammable()
        : base(TowSpecialRuleType.Flammable,
            ShortDescription,
            LongDescription)
    {

    }
}
