using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class StrikeFirst : TowSpecialRule
{
    private static new string ShortDescription = "I is 10 in combat";
    private static new string LongDescription = "During the Combat phase, a model with this special rule that is engaged in combat improves its Initiative characteristic to 10 (before any other modifiers are applied). If a model has both this rule and Strike Last, the two rules cancel one another out.";

    public StrikeFirst()
        : base(TowSpecialRuleType.StrikeFirst,
            ShortDescription,
            LongDescription,
            printShortDescription: false)
    {

    }
}
