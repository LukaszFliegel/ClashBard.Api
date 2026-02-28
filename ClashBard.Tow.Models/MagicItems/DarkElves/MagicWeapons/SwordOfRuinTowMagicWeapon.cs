using ClashBard.Tow.Models.MagicItems.DarkElves;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.DarkElves.MagicWeapons;

/// <summary>
/// The wickedly sharp edge of the Sword of Ruin can cleave through armour as if it were air.
/// Combat, S, AP*. Magical Attacks.
/// No armour, Ward or Regeneration saves are permitted against wounds caused.
/// 65 points.
/// </summary>
public class SwordOfRuinTowMagicWeapon : TowMagicWeapon
{
    private const int points = 65;

    public SwordOfRuinTowMagicWeapon(TowObject owner)
        : base(owner, TowDarkElvesMagicItemType.SwordOfRuin, points, 0, TowWeaponStrength.S, 0)
    {
        AssignSpecialRule(new MagicalAttacks());
        AssignSpecialRule(new SwordOfRuinRules());
    }

    protected class SwordOfRuinRules : TowSpecialRule
    {
        private static string ShortDescription = "No armour/Ward/Regen saves";
        private static string LongDescription = "No armour, Ward or Regeneration saves are permitted against wounds caused by the Sword of Ruin.";

        public SwordOfRuinRules()
            : base(TowSpecialRuleType.SwordOfRuinRules,
                ShortDescription,
                LongDescription,
                printName: false)
        {
        }
    }
}
