using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class SerratedMawNotes : TowSpecialRule
{
    private static new string ShortDescription = "One of attacks must be made with this weapon";
    private static new string LongDescription = "In combat, this model must make one of its attacks each turn with this weapon.";

    public SerratedMawNotes()
        : base(TowSpecialRuleType.SerratedMawBlackDragonNotes,
            ShortDescription,
            LongDescription)
    {

    }
}
