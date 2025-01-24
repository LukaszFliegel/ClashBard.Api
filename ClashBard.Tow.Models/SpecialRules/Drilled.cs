using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Drilled : TowSpecialRule
{
    private static string ShortDescription = "Free redress the rank before moving";
    private static string LongDescription = "Unless it is fleeing, a Drilled unit may perform a free redress the ranks manoeuvre immediately before moving. Once this manoeuvre is complete, the unit moves as normal. In addition, a Drilled unit can march whilst within 8\" of an enemy unit without first having to make a Leadership test. Note that any character that joins a Drilled unit is considered to be Drilled as well.";

    public Drilled()
        : base(TowSpecialRuleType.Drilled,
            ShortDescription,
            LongDescription)
    {

    }
}
