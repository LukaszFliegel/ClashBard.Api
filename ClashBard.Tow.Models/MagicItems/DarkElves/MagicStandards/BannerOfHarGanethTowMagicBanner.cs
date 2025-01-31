using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicBanners;

public class BannerOfHarGanethTowMagicBanner : TowMagicStandard
{
    private const int points = 25;

    public BannerOfHarGanethTowMagicBanner(TowObject owner) : base(owner, TowMagicItemBannerType.BannerOfIronResolve, points)
    {
        AssignSpecialRule(new ArmourPiercingPlus1());
    }
}
