using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class CloseOrder : TowSpecialRule
{
    private static new string ShortDescription = "Close order";
    private static new string LongDescription = "A unit consisting of models with this special rule may adopt a Close Order formation.";

    public CloseOrder()
        : base(TowSpecialRuleType.CloseOrder,
            ShortDescription,
            LongDescription, 
            false)
    {

    }
}
