using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class FirstCharge : TowSpecialRule
{
    private static new string ShortDescription = "The thundering charge of heavily armed and armoured warriors, freshly arrived upon the battlefield and eager for the fray, is devastating to the cowering foe.";
    private static new string LongDescription = "If this unit's first charge of the game is successful (i.e., if the unit makes contact with the charge target), the charge target becomes Disrupted until the end of the Combat phase of that turn.";

    public FirstCharge()
        : base(TowSpecialRuleType.FirstCharge,
            ShortDescription,
            LongDescription)
    {

    }
}
