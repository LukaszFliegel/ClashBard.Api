using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicBanners;

public class BannerOfIronResolveTowMagicBanner : TowMagicStandard
{
    private const int points = 50;


    public BannerOfIronResolveTowMagicBanner(TowObject owner) : base(owner, TowMagicItemBannerType.BannerOfIronResolve, points)
    {
        AssignSpecialRule(new BannerOfIronResolveRules());
    }

    protected class BannerOfIronResolveRules : TowSpecialRule
    {
        private static string ShortDescription = "Gives unit Stubborn";
        private static string LongDescription = "A unit carrying the Banner of Iron Resolve gains the Stubborn special rule.";

        public BannerOfIronResolveRules()
            : base(TowSpecialRuleType.BannerOfIronResolveRules,
                ShortDescription,
                LongDescription,
                printName: false)
        {

        }
    }
}
