using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class LargeTarget : TowSpecialRule
{
    private static new string ShortDescription = "Monstrous creatures tower above the battlefield, visible to all for leagues around.";
    private static new string LongDescription = "Enemy models never suffer To Hit modifiers for full or partial cover when shooting at models with this special rule. In addition, a model can draw a line of sight to a model with this special rule over or through other models, and vice versa.";

    public LargeTarget()
        : base(TowSpecialRuleType.LargeTarget,
            ShortDescription,
            LongDescription)
    {

    }
}
