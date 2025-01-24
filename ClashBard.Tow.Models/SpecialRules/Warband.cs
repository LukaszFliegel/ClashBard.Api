using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Warband : TowSpecialRule
{
    private static string ShortDescription = "A warband is an unruly mob, keen for the fray but easily dismayed when things go poorly.";
    private static string LongDescription = "Unless it is fleeing, a Warband gains a positive (+) modifier to its Leadership characteristic equal to its current Rank Bonus, up to a maximum of Leadership 10. However, a Warband cannot use this modifier to its Leadership should it ever choose to make a Restraint test. In addition, if the majority of the models in a unit have this special rule, it may re-roll its Charge roll. Note that unless a character also has this special rule, their Leadership cannot be modified by this special rule. A Warband can use either its own modified Leadership, the modified Leadership of a Warband character, or the unmodified Leadership of a non-Warband character, whichever is the higher.";

    public Warband()
        : base(TowSpecialRuleType.Warband,
            ShortDescription,
            LongDescription)
    {

    }
}
