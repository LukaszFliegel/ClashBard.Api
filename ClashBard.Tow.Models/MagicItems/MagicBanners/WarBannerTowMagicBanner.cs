using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicBanners;

public class WarBannerTowMagicBanner : TowMagicBanner
{
    private const int points = 25;


    public WarBannerTowMagicBanner(TowObject owner) : base(owner, TowMagicItemBannerType.WarBanner, points)
    {
        SpecialRules.Add(new WarBannerRules());
    }
}


public class WarBannerRules : TowSpecialRule
{
    private static string ShortDescription = "+1 CR";
    private static string LongDescription = "When calculating its combat result, a unit carrying the War Banner may claim an additional bonus of +1 combat result point.";

    public WarBannerRules()
        : base(TowSpecialRuleType.WarBannerRules,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}

