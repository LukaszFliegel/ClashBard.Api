using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class MultipleShots2 : TowSpecialRule
{
    private static string ShortDescription = "Multiple Shots (2)";
    private static string LongDescription = "A weapon with this special rule can either fire a single shot as normal, or it can be fired a number of times, as shown in brackets after the name of this special rule (shown here as 'X'). If multiple shots are fired, each roll To Hit suffers an additional -1 To Hit modifier. All models in a unit equipped with weapons with this special rule must fire either a single or Multiple Shots. Where the number of Multiple Shots is generated by a dice roll, roll separately for each model.";

    public MultipleShots2()
        : base(TowSpecialRuleType.MultipleShots2,
            ShortDescription,
            LongDescription,
            printShortDescription: false)
    {

    }
}
