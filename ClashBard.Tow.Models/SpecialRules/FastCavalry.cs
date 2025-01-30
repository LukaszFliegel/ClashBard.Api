using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class FastCavalry : TowSpecialRule
{
    private static string ShortDescription = "If in Open Order can Quick Turn even if marched";
    private static string LongDescription = "If all of the models (including characters) within a unit arrayed in an Open Order formation have this special rule, the unit may perform its Quick Turn even if it marched.";

    public FastCavalry()
        : base(TowSpecialRuleType.FastCavalry,
            ShortDescription,
            LongDescription)
    {

    }
}
