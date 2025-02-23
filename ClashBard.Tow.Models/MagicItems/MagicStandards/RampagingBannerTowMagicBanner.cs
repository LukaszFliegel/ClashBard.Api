using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicBanners;

public class RampagingBannerTowMagicBanner : TowMagicStandard
{
    private const int points = 30;


    public RampagingBannerTowMagicBanner(TowObject owner) : base(owner, TowMagicItemBannerType.RampagingBanner, points)
    {
        AssignSpecialRule(new RampagingBannerRules());
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

