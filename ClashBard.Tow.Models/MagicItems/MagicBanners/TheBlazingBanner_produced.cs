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
    private static new string ShortDescription = "Gives unit Stubborn";
    private static new string LongDescription = "A unit carrying the Banner of Iron Resolve gains the Stubborn special rule.";

    public TheBlazingBannerRules()
        : base(TowSpecialRuleType.TheBlazingBannerRules,
            ShortDescription,
            LongDescription)
    {

    }
}

