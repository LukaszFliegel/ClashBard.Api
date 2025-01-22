using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class Murderous : TowSpecialRule
{
    private static new string ShortDescription = "Hand weapon reroll 1 on wound";
    private static new string LongDescription = "When engaged in combat, a model with this special rule that is fighting with a hand weapon may re-roll any rolls To Wound of a natural 1. Note that this special rule only applies to a single, non-magical hand weapon and does not apply to a model’s mount (should it have one). If the model is using two hand weapons or any other sort of weapon, this special rule ceases to apply.";

    public Murderous()
        : base(TowSpecialRuleType.Murderous,
            ShortDescription,
            LongDescription,
            printShortDescription: false) // dont print short description, since this rule is dead
    {

    }
}
