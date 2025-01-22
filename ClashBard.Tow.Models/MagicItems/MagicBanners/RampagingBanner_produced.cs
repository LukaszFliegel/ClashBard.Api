using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicBanners;

public class RampagingBanner : TowMagicBanner
{
    private const int points = 30;


    public RampagingBanner() : base(TowMagicItemBannerType.RampagingBanner, points)
    {
        SpecialRules.Add(new RampagingBannerRules());
    }
}


public class RampagingBannerRules : TowSpecialRule
{
    private static new string ShortDescription = "???";
    private static new string LongDescription = "???";

    public RampagingBannerRules()
        : base(TowSpecialRuleType.RampagingBannerRules,
            ShortDescription,
            LongDescription)
    {

    }
}

