using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;

public class HatredDarkElves : TowSpecialRule
{
    private static string ShortDescription = "Hatred against Dark Elves";
    private static string LongDescription = "This model has the Hatred special rule when fighting against Dark Elves.";

    public HatredDarkElves()
        : base(TowSpecialRuleType.HatredDarkElves,
            ShortDescription,
            LongDescription)
    {

    }
}
