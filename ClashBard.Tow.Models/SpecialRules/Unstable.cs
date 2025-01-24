using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Unstable : TowSpecialRule
{
    private static string ShortDescription = "Many evil creatures are not truly alive, but are driven instead by magic. Should the tide of battle turn, this magic can quickly fail.";
    private static string LongDescription = "If a unit with this special rule loses a round of combat, it loses one additional Wound for every combat result point by which it lost. These Wounds are lost after combat results have been calculated but before Break tests are made. If an Unstable unit contains any Unstable characters, allocate wounds to the unit until each model has been allocated one wound. Any remaining wounds are divided as equally as possible between the character(s) and the unit.";

    public Unstable()
        : base(TowSpecialRuleType.Unstable,
            ShortDescription,
            LongDescription)
    {

    }
}
