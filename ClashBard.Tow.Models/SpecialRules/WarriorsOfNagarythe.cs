using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class WarriorsOfNagarythe : TowSpecialRule
{
    // todo: wrong descriptions
    private static string ShortDescription = "Hatred (Dark Elves).";
    private static string LongDescription = "Units with this special rule have Hatred (Dark Elves). This represents the ancient enmity between the Shadow Warriors of Nagarythe and their dark cousins who followed Malekith into exile.";

    public WarriorsOfNagarythe()
        : base(TowSpecialRuleType.WarriorsOfNagarythe, ShortDescription, LongDescription)
    {
    }
}
