using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicBanners;

public class RazorStandardTowMagicBanner : TowMagicBanner
{
    private const int points = 40;


    public RazorStandardTowMagicBanner(TowObject owner) : base(owner, TowMagicItemBannerType.RazorStandard, points)
    {
        SpecialRules.Add(new RazorStandardRules());
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

