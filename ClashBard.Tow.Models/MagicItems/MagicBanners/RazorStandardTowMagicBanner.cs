using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicBanners;

public class RazorStandardTowMagicBanner : TowMagicBanner
{
    private const int points = 40;


    public RazorStandardTowMagicBanner() : base(TowMagicItemBannerType.RazorStandard, points)
    {
        SpecialRules.Add(new RazorStandardRules());
    }
}


public class RazorStandardRules : TowSpecialRule
{
    private static new string ShortDescription = "???";
    private static new string LongDescription = "???";

    public RazorStandardRules()
        : base(TowSpecialRuleType.RazorStandardRules,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}

