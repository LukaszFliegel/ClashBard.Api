using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class CloseOrder : TowSpecialRule
{
    private static string ShortDescription = "Close order";
    private static string LongDescription = "A unit consisting of models with this special rule may adopt a Close Order formation.";

    public CloseOrder()
        : base(TowSpecialRuleType.CloseOrder,
            ShortDescription,
            LongDescription, 
            printShortDescription: false)
    {

    }
}
