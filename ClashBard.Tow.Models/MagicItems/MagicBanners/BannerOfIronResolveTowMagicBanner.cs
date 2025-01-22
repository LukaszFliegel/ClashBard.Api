using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicBanners;

public class BannerOfIronResolveTowMagicBanner : TowMagicBanner
{
    private const int points = 50;


    public BannerOfIronResolveTowMagicBanner() : base(TowMagicItemBannerType.BannerOfIronResolve, points)
    {
        SpecialRules.Add(new BannerOfIronResolveRules());
    }
}


public class BannerOfIronResolveRules : TowSpecialRule
{
    private static new string ShortDescription = "Gives unit Stubborn";
    private static new string LongDescription = "A unit carrying the Banner of Iron Resolve gains the Stubborn special rule.";

    public BannerOfIronResolveRules()
        : base(TowSpecialRuleType.BannerOfIronResolveRules,
            ShortDescription,
            LongDescription)
    {

    }
}

