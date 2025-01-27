using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class FirstCharge : TowSpecialRule
{
    private static string ShortDescription = "Target of the first charge is Disrupted";
    private static string LongDescription = "If this unit's first charge of the game is successful (i.e., if the unit makes contact with the charge target), the charge target becomes Disrupted until the end of the Combat phase of that turn.";

    public FirstCharge()
        : base(TowSpecialRuleType.FirstCharge,
            ShortDescription,
            LongDescription)
    {

    }
}
