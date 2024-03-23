using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class RandomAttacks : TowSpecialRule
{
    private static new string ShortDescription = "Not all creatures fight with discipline; many flail about in careless abandon with unpredictable results.";
    private static new string LongDescription = "Models with this special rule do not have a normal Attacks characteristic. Instead, a dice roll is given (D3+1, for example). Each time a model with this special rule attacks in combat, roll the dice to determine the number of attacks it will make, then roll To Hit as normal. If a fighting rank contains more than one model with this special rule, roll separately for each, unless specified otherwise.";

    public RandomAttacks()
        : base(TowSpecialRuleType.RandomAttacks,
            ShortDescription,
            LongDescription)
    {

    }
}
