using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class StonyStare : TowSpecialRule
{
    private static string ShortDescription = "Enemy models in base contact must make I test. D3S2 hits with no ASv if failed.";
    private static string LongDescription = "At the start of each Combat phase, enemy models in base contact with this model must make an Initiative test. If this test is failed, they suffer D3 Strength 2 hits, with no armour save permitted (Ward and Regeneration saves can be attempted as normal).";

    public StonyStare()
        : base(TowSpecialRuleType.StonyStare,
            ShortDescription,
            LongDescription)
    {

    }
}
