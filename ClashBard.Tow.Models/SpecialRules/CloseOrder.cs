using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class CloseOrder : TowSpecialRule
{
    private static new string ShortDescription = "The mainstay of any army is its regiments of close order infantry and cavalry.";
    private static new string LongDescription = "A unit consisting of models with this special rule may adopt a Close Order formation.";

    public CloseOrder()
        : base(TowSpecialRuleType.CloseOrder,
            ShortDescription,
            LongDescription)
    {

    }
}
