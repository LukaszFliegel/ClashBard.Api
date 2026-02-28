using ClashBard.Tow.Models.MagicItems.DarkElves;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.DarkElves.MagicWeapons;

/// <summary>
/// A single blow from this huge, black-bladed weapon can cut any opponent in half.
/// Combat, S, AP-2. Killing Blow, Magical Attacks, Strike Last.
/// A roll of 2+ To Wound is always a success.
/// 70 points.
/// </summary>
public class ExecutionersAxeTowMagicWeapon : TowMagicWeapon
{
    private const int points = 70;

    public ExecutionersAxeTowMagicWeapon(TowObject owner)
        : base(owner, TowDarkElvesMagicItemType.ExecutionersAxe, points, 0, TowWeaponStrength.S, 2)
    {
        AssignSpecialRule(new KillingBlow());
        AssignSpecialRule(new MagicalAttacks());
        AssignSpecialRule(new StrikeLast());
        AssignSpecialRule(new ExecutionersAxeRules());
    }

    protected class ExecutionersAxeRules : TowSpecialRule
    {
        private static string ShortDescription = "2+ To Wound";
        private static string LongDescription = "When making a roll To Wound for a hit caused with the Executioner's Axe, a roll of 2+ is always a success, regardless of the target's Toughness.";

        public ExecutionersAxeRules()
            : base(TowSpecialRuleType.ExecutionersAxeRules,
                ShortDescription,
                LongDescription,
                printName: false)
        {
        }
    }
}
