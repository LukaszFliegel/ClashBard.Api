using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class BlessingsOfKhaine : TowSpecialRule
{
    private static new string ShortDescription = "Bound Spell Level 2";
    private static new string LongDescription = "Even if engaged in combat, this model can cast the following Bound spell, with a Power Level of 2: Type: Enchantment | Casting Value: 9+ | Range: Self | Effect: Until your next Start of Turn sub-phase, this model and every friendly Death Hag, unit of Witch Elves or unit of Sisters of Slaughter that is within its Command range gains one of the following: Fury of Khaine (the Furious Charge special rule) / Strength of Khaine (the Cleaving Blow special rule) / Bloodshield of Khaine (a 5+ Ward save against any wounds suffered)";

    public BlessingsOfKhaine()
        : base(TowSpecialRuleType.BlessingsOfKhaine,
            ShortDescription,
            LongDescription)
    {

    }
}
