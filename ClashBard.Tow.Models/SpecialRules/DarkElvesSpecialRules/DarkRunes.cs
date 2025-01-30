using ClashBard.Tow.Models;
using ClashBard.Tow.Models.Armors.Interfaces;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class DarkRunes : TowSpecialRule, IWardSaveImprover
{
    private static string ShortDescription = "5+ Ward for non-magical";
    private static string LongDescription = "This unit has a 5+ Ward save against any wounds suffered that were caused by a nonmagical enemy attack.";

    public DarkRunes()
        : base(TowSpecialRuleType.DarkRunes,
            ShortDescription,
            LongDescription)
    {

    }

    public int? MeleeWardSaveBaseline => 5;

    public int MeleeWardSaveImprovement => 0;

    public int? RangedWardSaveBaseline => 5;

    public int RangedWardSaveImprovement => 0;

    public bool AsteriskOnWardSave => true;
}
