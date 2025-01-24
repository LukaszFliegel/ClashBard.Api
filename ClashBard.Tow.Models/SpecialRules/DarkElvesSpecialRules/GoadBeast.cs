using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class GoadBeast : TowSpecialRule
{
    private static string ShortDescription = "Target monster +D3 attacks";
    private static string LongDescription = "During the Command sub-phase of their turn, this character may goad a single friendly model whose troop type is ‘monster’ and that is within their Command range (including their own mount). Until the end of this turn, that model gains a +D3 modifier to its Attacks characteristic (to a maximum of 10).";

    public GoadBeast()
        : base(TowSpecialRuleType.GoadBeast,
            ShortDescription,
            LongDescription)
    {

    }
}
