using ClashBard.Tow.Models.MagicItems.DarkElves;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicBanners;

/// <summary>
/// Anointed with the blood of an Ulthuan Elf, this banner exudes a sense of bitter determination.
/// When calculating combat result during a turn in which the unit charged, may claim an additional +D3 combat result points.
/// 40 points.
/// </summary>
public class StandardOfSlaughterTowMagicBanner : TowMagicStandard
{
    private const int points = 40;

    public StandardOfSlaughterTowMagicBanner(TowObject owner)
        : base(owner, TowDarkElvesMagicItemType.StandardOfSlaughter, points)
    {
        AssignSpecialRule(new StandardOfSlaughterRules());
    }

    protected class StandardOfSlaughterRules : TowSpecialRule
    {
        private static string ShortDescription = "When charging: +D3 combat result points";
        private static string LongDescription = "When calculating its combat result during a turn in which it charged, a unit carrying the Standard of Slaughter may claim an additional bonus of +D3 combat result points.";

        public StandardOfSlaughterRules()
            : base(TowSpecialRuleType.StandardOfSlaughterRules,
                ShortDescription,
                LongDescription,
                printName: false)
        {
        }
    }
}
