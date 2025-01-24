using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class OpenOrder : TowSpecialRule
{
    private static string ShortDescription = "Many regiments adopt an open formation, increasing their manoeuvrability.";
    private static string LongDescription = "A unit consisting of models with this special rule may adopt an Open Order formation.";

    public OpenOrder()
        : base(TowSpecialRuleType.OpenOrder,
            ShortDescription,
            LongDescription)
    {

    }
}
