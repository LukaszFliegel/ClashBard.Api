using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class DarkRunes : TowSpecialRule
{
    private static new string ShortDescription = "5+ Ward for non-magical";
    private static new string LongDescription = "This unit has a 5+ Ward save against any wounds suffered that were caused by a nonmagical enemy attack.";

    public DarkRunes()
        : base(TowSpecialRuleType.CursedCoven,
            ShortDescription,
            LongDescription)
    {

    }
}
