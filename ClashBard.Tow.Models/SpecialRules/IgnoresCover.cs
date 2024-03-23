using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class IgnoresCover : TowSpecialRule
{
    private static new string ShortDescription = "Even dense cover offers no safe haven from a skilled marksman wielding a wellcrafted weapon.";
    private static new string LongDescription = "If a model making a shooting attack has this special rule, it ignores any To Hit modifiers caused by partial or full cover.";

    public IgnoresCover()
        : base(TowSpecialRuleType.IgnoresCover,
            ShortDescription,
            LongDescription)
    {

    }
}
