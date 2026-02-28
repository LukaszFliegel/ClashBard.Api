using ClashBard.Tow.Models.MagicItems.DarkElves;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.DarkElves.MagicArmours;

/// <summary>
/// When anointed with the blood of the foe, this armour becomes ever more endurable.
/// Infantry and cavalry only. Armour value of 5+. For each unsaved wound inflicted, improves by 1, up to 2+.
/// 30 points.
/// </summary>
public class BloodArmourTowMagicArmour : TowMagicArmour
{
    private const int points = 30;

    public BloodArmourTowMagicArmour(TowObject owner)
        : base(owner, TowDarkElvesMagicItemType.BloodArmour, points, 999)
    {
        AssignSpecialRule(new BloodArmourRules());
    }

    protected class BloodArmourRules : TowSpecialRule
    {
        private static string ShortDescription = "Infantry/cavalry only. Starts 5+. +1 per unsaved wound inflicted (max 2+)";
        private static string LongDescription = "Models whose troop type is 'infantry' or 'cavalry' only. The Blood Armour is a suit of armour that gives its wearer an armour value of 5+. For each unsaved wound the wearer inflicts, this armour value is improved by 1, to a maximum of 2+.";

        public BloodArmourRules()
            : base(TowSpecialRuleType.BloodArmourRules,
                ShortDescription,
                LongDescription,
                printName: false)
        {
        }
    }
}
