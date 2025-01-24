using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class CavernousMawNotes : TowSpecialRule
{
    private static string ShortDescription = "One of attacks must be made with this weapon";
    private static string LongDescription = "In combat, this model must make one of its attacks each turn with this weapon";

    public CavernousMawNotes()
        : base(TowSpecialRuleType.CavernousMawNotes,
            ShortDescription,
            LongDescription)
    {

    }
}
