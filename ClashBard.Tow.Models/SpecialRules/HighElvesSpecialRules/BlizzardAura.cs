using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;

public class BlizzardAura : TowSpecialRule
{
    private static string ShortDescription = "Blizzard Aura";
    private static string LongDescription = "All enemy units within 6\" of one or more models with this special rule suffer a -1 modifier to their Ballistic Skill characteristic (to a minimum of 1). In addition, all enemy models within 6\" of one or more models with this special rule suffer a -1 modifier to their Initiative characteristic when making To Hit rolls in combat (to a minimum of 1).";

    public BlizzardAura()
        : base(TowSpecialRuleType.BlizzardAura,
            ShortDescription,
            LongDescription,
            printShortDescription: false)
    {

    }
}
