using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class SerratedMawsNotes : TowSpecialRule
{
    private static new string ShortDescription = "All extra At (+remaining Wn) must be made with this weapon";
    private static new string LongDescription = "In combat, this model must make each attack granted by the Extra Attacks (+remaining Wounds) special rule with this weapon.";

    public SerratedMawsNotes()
        : base(TowSpecialRuleType.SerratedMawWarHydraNotes,
            ShortDescription,
            LongDescription)
    {

    }
}
