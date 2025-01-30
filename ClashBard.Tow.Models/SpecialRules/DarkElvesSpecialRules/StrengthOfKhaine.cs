using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class StrengthOfKhaine : TowSpecialRule
{
    private static string ShortDescription = "Blessing of Khaine: Cleaving Blow";
    private static string LongDescription = "Even if engaged in combat, this model can cast the following Bound spell, with a Power Level of 2. Type: Enchantment, Casting Value: 9+, Range: Self, Effect: Until your next Start of Turn sub-phase, this model and every friendly Death Hag, unit of Witch Elves or unit of Sisters of Slaughter that is within its Command range gains one of the following: 1) Fury of Khaine (the Furious Charge special rule) 2) Strength of Khaine (the Cleaving Blow special rule) 3) Bloodshield of Khaine (a 5+ Ward save against any wounds suffered)";

    public StrengthOfKhaine()
        : base(TowSpecialRuleType.StrengthOfKhaine,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}
