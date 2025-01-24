using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class FeignedFlight : TowSpecialRule
{
    private static string ShortDescription = "Some units are adept at escaping from the foe and regrouping, drawing the enemy into careless charges before vanishing into the distance.";
    private static string LongDescription = "If this unit chooses to Flee (or Fire & Flee) as a charge reaction, it automatically rallies at the end of its move.";

    public FeignedFlight()
        : base(TowSpecialRuleType.FeignedFlight,
            ShortDescription,
            LongDescription)
    {

    }
}
