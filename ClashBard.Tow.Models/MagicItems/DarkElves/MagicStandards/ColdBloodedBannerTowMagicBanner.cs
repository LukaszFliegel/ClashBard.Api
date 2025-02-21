using ClashBard.Tow.Models.MagicItems.DarkElves;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicBanners;

public class ColdBloodedBannerTowMagicBanner : TowMagicStandard
{
    private const int points = 25;

    public ColdBloodedBannerTowMagicBanner(TowObject owner) : base(owner, TowDarkElvesMagicItemType.BannerOfHarGaneth, points)
    {
        AssignSpecialRule(new ArmourPiercingPlus1());
    }

    protected class ColdBloodedBannerRules : TowSpecialRule
    {
        private static string ShortDescription = "Single use. Extra D6 on a Ld test, doscard highest.";
        private static string LongDescription = "Single use. A unit carrying the Cold-blooded Banner may use it when making any test against its Leadership characteristic, including a Break test. When it does, it may roll an extra D6 and discard the highest result.";

        public ColdBloodedBannerRules()
            : base(TowSpecialRuleType.ColdBloodedBannerRules,
                ShortDescription,
                LongDescription,
                printName: false)
        {

        }
    }
}
