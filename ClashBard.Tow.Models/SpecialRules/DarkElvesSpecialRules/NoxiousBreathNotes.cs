using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class NoxiousBreathNotes : TowSpecialRule
{
    private static new string ShortDescription = "No ASv permitted (WSv and Reg allowed). If wound suffered: -1 to WS until next turn.";
    private static new string LongDescription = "Until your next Start of Turn sub-phase, every model in a unit that suffers one or more unsaved wounds from this weapon suffers a -1 modifier to its Weapon Skill characteristic (to a minimum of 1). No armour save is permitted against wounds caused by this weapon (Ward and Regeneration saves can be attempted as normal).";

    public NoxiousBreathNotes()
        : base(TowSpecialRuleType.NoxiousBreathNotes,
            ShortDescription,
            LongDescription)
    {

    }
}
