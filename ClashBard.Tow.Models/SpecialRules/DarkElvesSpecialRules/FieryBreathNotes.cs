using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class FieryBreathNotes : TowSpecialRule
{
    private static string ShortDescription = "S = remaining Wn";
    private static string LongDescription = "The Strength characteristic of this weapon is equal to this model’s remaining Wounds.";

    public FieryBreathNotes()
        : base(TowSpecialRuleType.FieryBreathNotes,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}
