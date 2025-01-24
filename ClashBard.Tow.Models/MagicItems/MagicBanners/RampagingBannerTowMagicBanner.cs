using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicBanners;

public class RampagingBannerTowMagicBanner : TowMagicBanner
{
    private const int points = 30;


    public RampagingBannerTowMagicBanner(TowObject owner) : base(owner, TowMagicItemBannerType.RampagingBanner, points)
    {
        SpecialRules.Add(new RampagingBannerRules());
    }
}


public class RampagingBannerRules : TowSpecialRule
{
    private static string ShortDescription = "???";
    private static string LongDescription = "???";

    public RampagingBannerRules()
        : base(TowSpecialRuleType.RampagingBannerRules,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}

