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
    private static new string ShortDescription = "Gives unit Stubborn";
    private static new string LongDescription = "A unit carrying the Banner of Iron Resolve gains the Stubborn special rule.";

    public RampagingBannerRules()
        : base(TowSpecialRuleType.RampagingBannerRules,
            ShortDescription,
            LongDescription)
    {

    }
}

