using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Swiftstride : TowSpecialRule
{
    private static new string ShortDescription = "+3\" to declarable charge and +D6 modifier to charge roll";
    private static new string LongDescription = "A unit with this special rule increases its maximum possible charge range by 3\" and, when it makes a Charge, Flee or Pursuit roll, may apply a +D6 modifier to the result.";

    public Swiftstride()
        : base(TowSpecialRuleType.Swiftstride,
            ShortDescription,
            LongDescription, 
            printShortDescription: false)
    {

    }
}
