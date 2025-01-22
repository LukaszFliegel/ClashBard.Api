using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicBanners;

public class TheBlazingBanner : TowMagicBanner
{
    private const int points = 25;


    public TheBlazingBanner() : base(TowMagicItemBannerType.TheBlazingBanner, points)
    {
        SpecialRules.Add(new TheBlazingBannerRules());
    }
}


public class TheBlazingBannerRules : TowSpecialRule
{
    private static new string ShortDescription = "???";
    private static new string LongDescription = "???";

    public TheBlazingBannerRules()
        : base(TowSpecialRuleType.TheBlazingBannerRules,
            ShortDescription,
            LongDescription)
    {

    }
}

