using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicBanners;

public class RazorStandard : TowMagicBanner
{
    private const int points = 40;


    public RazorStandard() : base(TowMagicItemBannerType.RazorStandard, points)
    {
        SpecialRules.Add(new RazorStandardRules());
    }
}


public class RazorStandardRules : TowSpecialRule
{
    private static new string ShortDescription = "Gives unit Stubborn";
    private static new string LongDescription = "A unit carrying the Banner of Iron Resolve gains the Stubborn special rule.";

    public RazorStandardRules()
        : base(TowSpecialRuleType.RazorStandardRules,
            ShortDescription,
            LongDescription)
    {

    }
}
