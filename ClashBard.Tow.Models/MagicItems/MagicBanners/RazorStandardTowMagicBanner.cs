using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicBanners;

public class RazorStandardTowMagicBanner : TowMagicStandard
{
    private const int points = 40;


    public RazorStandardTowMagicBanner(TowObject owner) : base(owner, TowMagicItemBannerType.RazorStandard, points)
    {
        AssignSpecialRule(new RazorStandardRules());
    }
}


public class RazorStandardRules : TowSpecialRule
{
    private static string ShortDescription = "???";
    private static string LongDescription = "???";

    public RazorStandardRules()
        : base(TowSpecialRuleType.RazorStandardRules,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}

