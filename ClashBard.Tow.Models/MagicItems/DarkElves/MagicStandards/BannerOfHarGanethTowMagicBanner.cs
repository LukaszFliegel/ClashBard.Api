using ClashBard.Tow.Models.MagicItems.DarkElves;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicBanners;

public class BannerOfHarGanethTowMagicBanner : TowMagicStandard
{
    private const int points = 25;

    public BannerOfHarGanethTowMagicBanner(TowObject owner) : base(owner, TowDarkElvesMagicItemType.BannerOfHarGaneth, points)
    {
        AssignSpecialRule(new ArmourPiercingPlus1());
    }
}
