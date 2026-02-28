using ClashBard.Tow.Models.MagicItems.DarkElves;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicBanners;

/// <summary>
/// The personal banner of the Dread-King proclaims his reign over the Elven Kingdoms.
/// Unit gains Stubborn. When calculating combat result, the unit may claim an additional +1 combat result point.
/// 65 points.
/// </summary>
public class BannerOfNagarytheTowMagicBanner : TowMagicStandard
{
    private const int points = 65;

    public BannerOfNagarytheTowMagicBanner(TowObject owner)
        : base(owner, TowDarkElvesMagicItemType.BannerOfNagarythe, points)
    {
        AssignSpecialRule(new Stubborn());
        AssignSpecialRule(new BannerOfNagarytheRules());
    }

    protected class BannerOfNagarytheRules : TowSpecialRule
    {
        private static string ShortDescription = "Stubborn. +1 combat result point";
        private static string LongDescription = "A unit carrying the Banner of Nagarythe gains the Stubborn special rule. In addition, when calculating its combat result, the unit may claim an additional bonus of +1 combat result point.";

        public BannerOfNagarytheRules()
            : base(TowSpecialRuleType.BannerOfNagarytheRules,
                ShortDescription,
                LongDescription,
                printName: false)
        {
        }
    }
}
