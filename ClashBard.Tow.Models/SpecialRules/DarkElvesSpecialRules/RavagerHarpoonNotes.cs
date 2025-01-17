using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class RavagerHarpoonNotes : TowSpecialRule
{
    private static new string ShortDescription = "One of the Beastmaster Crew may fire this weapon instead of their repeater crossbow.";
    private static new string LongDescription = "During the Shooting phase, one of the Beastmaster Crew may fire this weapon instead of their repeater crossbow.";

    public RavagerHarpoonNotes()
        : base(TowSpecialRuleType.RavagerHarpoonNotes,
            ShortDescription,
            LongDescription)
    {

    }
}
