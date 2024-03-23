using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class RegimentalUnit : TowSpecialRule
{
    private static new string ShortDescription = "Sometimes, large units are supported in battle by smaller detachments.";
    private static new string LongDescription = "A unit with this special rule can be accompanied by detachment.";

    public RegimentalUnit()
        : base(TowSpecialRuleType.RegimentalUnit,
            ShortDescription,
            LongDescription)
    {

    }
}
