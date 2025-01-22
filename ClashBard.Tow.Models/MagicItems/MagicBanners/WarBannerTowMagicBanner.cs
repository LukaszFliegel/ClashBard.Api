using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicBanners;

public class WarBannerTowMagicBanner : TowMagicBanner
{
    private const int points = 25;


    public WarBannerTowMagicBanner() : base(TowMagicItemBannerType.WarBanner, points)
    {
        SpecialRules.Add(new WarBannerRules());
    }
}


public class WarBannerRules : TowSpecialRule
{
    private static new string ShortDescription = "+1 CR";
    private static new string LongDescription = "When calculating its combat result, a unit carrying the War Banner may claim an additional bonus of +1 combat result point.";

    public WarBannerRules()
        : base(TowSpecialRuleType.WarBannerRules,
            ShortDescription,
            LongDescription)
    {

    }
}

