using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class BlackLotusForbiddenPoisonRules : TowSpecialRule
{
    private static string ShortDescription = "-1 Ld for each usaved wounds (for the rest of the game)";
    private static string LongDescription = "For each unsaved Wound inflicted upon them by this character, enemy characters suffer a -1 modifier to their Leadership characteristic for the remainder of the game.";

    public BlackLotusForbiddenPoisonRules()
        : base(TowSpecialRuleType.BlackLotus,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}
