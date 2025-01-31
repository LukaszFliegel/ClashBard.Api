using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicBanners;

public class TheBlazingBannerTowMagicBanner : TowMagicStandard
{
    private const int points = 25;


    public TheBlazingBannerTowMagicBanner(TowObject owner) : base(owner, TowMagicItemBannerType.TheBlazingBanner, points)
    {
        AssignSpecialRule(new TheBlazingBannerRules());
    }
}


public class TheBlazingBannerRules : TowSpecialRule
{
    private static string ShortDescription = "???";
    private static string LongDescription = "???";

    public TheBlazingBannerRules()
        : base(TowSpecialRuleType.TheBlazingBannerRules,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}

