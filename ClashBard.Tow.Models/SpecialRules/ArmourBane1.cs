using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class ArmourBane1 : TowSpecialRule
{
    private static string ShortDescription = "+1 AP on roll 6";
    private static string LongDescription = "If a model with this special rule rolls a natural 6 when making a roll To Wound, the Armour Piercing characteristic of its weapon is improved by the amount shown in brackets after the name of this special rule (shown here as 'X'). For example, if a natural 6 is rolled when rolling To Wound with a weapon that has an AP of ' - ' and the Armour Bane (1) special rule, its AP counts as being -1 when making an Armour Save roll against that wound.";

    public ArmourBane1()
        : base(TowSpecialRuleType.ArmourBane1,
            ShortDescription,
            LongDescription,
            printShortDescription: false)
    {

    }
}
