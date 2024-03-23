using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Detachment : TowSpecialRule
{
    private static new string ShortDescription = "Large regiments may be accompanied by smaller detachments.";
    private static new string LongDescription = "A unit with this special rule can be fielded as a detachment.";

    public Detachment()
        : base(TowSpecialRuleType.Detachment,
            ShortDescription,
            LongDescription)
    {

    }
}
