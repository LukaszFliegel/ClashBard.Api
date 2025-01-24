using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Veteran : TowSpecialRule
{
    private static string ShortDescription = "Veteran warriors have seen and done it all, and it takes a lot to unsettle them.";
    private static string LongDescription = "If the majority of the models in a unit have this special rule, the unit may re-roll any failed Leadership test. Note that a Break test is not a Leadership test.";

    public Veteran()
        : base(TowSpecialRuleType.Veteran,
            ShortDescription,
            LongDescription)
    {

    }
}
