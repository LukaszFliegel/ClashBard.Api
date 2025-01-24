using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class ReserveMove : TowSpecialRule
{
    private static string ShortDescription = "Warriors that excel at hit and run warfare advance quickly, unleashing a deadly volley before withdrawing.";
    private static string LongDescription = "Unless it charged, marched or fled during the Movement phase of its turn, a unit with this special rule may make a Reserve move at the end of the Shooting phase of its turn, after all shooting has been resolved. A unit making a Reserve move moves as described in the Basic Movement rules. It may manoeuvre normally, but cannot march.";

    public ReserveMove()
        : base(TowSpecialRuleType.ReserveMove,
            ShortDescription,
            LongDescription)
    {

    }
}
