using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicBanners;

public class WarBanner : TowMagicBanner
{
    private const int points = 25;


    public WarBanner() : base(TowMagicItemBannerType.WarBanner, points)
    {
        SpecialRules.Add(new WarBannerRules());
    }
}


public class WarBannerRules : TowSpecialRule
{
    private static new string ShortDescription = "Gives unit Stubborn";
    private static new string LongDescription = "A unit carrying the Banner of Iron Resolve gains the Stubborn special rule.";

    public WarBannerRules()
        : base(TowSpecialRuleType.WarBannerRules,
            ShortDescription,
            LongDescription)
    {

    }
}

