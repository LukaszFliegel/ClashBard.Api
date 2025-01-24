using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class StrikeLast : TowSpecialRule
{
    private static string ShortDescription = "Some warriors are incredibly slow and ponderous by nature, whilst others may be encumbered by massive weapons that slow them down.";
    private static string LongDescription = "During the Combat phase, a model with this special rule that is engaged in combat reduces its Initiative characteristic to 1 (before any other modifiers are applied). If a model has both this rule and Strike First, the two rules cancel one another out.";

    public StrikeLast()
        : base(TowSpecialRuleType.StrikeLast,
            ShortDescription,
            LongDescription)
    {

    }
}
