using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class FuriousCharge : TowSpecialRule
{
    private static new string ShortDescription = "Some creatures charge with such fury, the very ground shakes beneath their feet.";
    private static new string LongDescription = "During a turn in which it made a charge move of 3\" or more, a model with this special rule gains a +1 modifier to its Attacks characteristic.";

    public FuriousCharge()
        : base(TowSpecialRuleType.FuriousCharge,
            ShortDescription,
            LongDescription)
    {

    }
}
