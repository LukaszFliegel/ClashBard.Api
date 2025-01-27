using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class ExtraAttacksPlusRemainingWounds : TowSpecialRule
{
    private static string ShortDescription = "Extra At (+remaining Wd)";
    private static string LongDescription = "A model with this special rule has a modifier to its Attacks characteristic, as shown in brackets after the name of this special rule (shown here as '+X'). If this modifier is determined by the roll of a dice, roll when the model's combat is chosen during any Choose & Fight Combat sub-phase.";

    public ExtraAttacksPlusRemainingWounds()
        : base(TowSpecialRuleType.ExtraAttacksPlusRemainingWounds,
            ShortDescription,
            LongDescription,
            printShortDescription: false)
    {

    }
}
