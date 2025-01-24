using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class ExtraAttacksPlus1 : TowSpecialRule
{
    private static string ShortDescription = "Through fury, extra limbs, or being armed to the teeth, this warrior can strike more blows.";
    private static string LongDescription = "A model with this special rule has a modifier to its Attacks characteristic, as shown in brackets after the name of this special rule (shown here as '+X'). If this modifier is determined by the roll of a dice, roll when the model's combat is chosen during any Choose & Fight Combat sub-phase.";

    public ExtraAttacksPlus1()
        : base(TowSpecialRuleType.ExtraAttacksPlus1,
            ShortDescription,
            LongDescription)
    {

    }
}
