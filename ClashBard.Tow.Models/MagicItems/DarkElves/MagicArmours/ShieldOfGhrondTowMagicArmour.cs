using ClashBard.Tow.Models.MagicItems.DarkElves;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.DarkElves.MagicArmours;

/// <summary>
/// The Daemon-faced Shield of Ghrond consumes the strength of the enemy's attacks.
/// The Shield of Ghrond is a shield. All attacks directed against its bearer suffer a -1 modifier
/// to their Strength characteristic (to a minimum of 1).
/// 40 points.
/// </summary>
public class ShieldOfGhrondTowMagicArmour : TowMagicArmour
{
    private const int points = 40;

    public ShieldOfGhrondTowMagicArmour(TowObject owner)
        : base(owner, TowDarkElvesMagicItemType.ShieldOfGhrond, points, 999)
    {
        AssignSpecialRule(new ShieldOfGhrondRules());
    }

    protected class ShieldOfGhrondRules : TowSpecialRule
    {
        private static string ShortDescription = "Shield. Attacks vs bearer suffer -1 Str (min 1)";
        private static string LongDescription = "The Shield of Ghrond is a shield. In addition, all attacks directed against its bearer suffer a -1 modifier to their Strength characteristic (to a minimum of 1).";

        public ShieldOfGhrondRules()
            : base(TowSpecialRuleType.ShieldOfGhrondRules,
                ShortDescription,
                LongDescription,
                printName: false)
        {
        }
    }
}
