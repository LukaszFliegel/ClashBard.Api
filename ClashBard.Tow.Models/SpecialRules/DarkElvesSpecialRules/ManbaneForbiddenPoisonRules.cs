using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class ManbaneForbiddenPoisonRules : TowSpecialRule
{
    private static string ShortDescription = "4+ always success on To Wound roll";
    private static string LongDescription = "When this character makes a roll To Wound, a roll of 4+ is always a success, regardless of the target’s Toughness.";

    public ManbaneForbiddenPoisonRules()
        : base(TowSpecialRuleType.Manbane,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}
