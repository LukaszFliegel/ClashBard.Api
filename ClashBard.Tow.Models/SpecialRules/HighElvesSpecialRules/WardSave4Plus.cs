using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;

public class WardSave4Plus : TowSpecialRule
{
    private static string ShortDescription = "4+ ward save";
    private static string LongDescription = "This model has a 4+ ward save.";

    public WardSave4Plus()
        : base(TowSpecialRuleType.WardSave,
            ShortDescription,
            LongDescription)
    {

    }
}
