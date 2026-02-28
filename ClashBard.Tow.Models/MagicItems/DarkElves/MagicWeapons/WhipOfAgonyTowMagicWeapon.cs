using ClashBard.Tow.Models.MagicItems.DarkElves;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.DarkElves.MagicWeapons;

/// <summary>
/// An heirloom of the feared Beastlords of clan Rakarth, the Whip of Agony inflicts enduring torment upon its victims.
/// Combat, S+1, AP-1. Magical Attacks, Strike First.
/// High Beastmasters only. Enemy models that suffer unsaved wounds suffer -1 Toughness for the remainder of the game.
/// 30 points.
/// </summary>
public class WhipOfAgonyTowMagicWeapon : TowMagicWeapon
{
    private const int points = 30;

    public WhipOfAgonyTowMagicWeapon(TowObject owner)
        : base(owner, TowDarkElvesMagicItemType.WhipOfAgony, points, 0, TowWeaponStrength.Splus1, 1)
    {
        AssignSpecialRule(new MagicalAttacks());
        AssignSpecialRule(new StrikeFirst());
        AssignSpecialRule(new WhipOfAgonyRules());
    }

    protected class WhipOfAgonyRules : TowSpecialRule
    {
        private static string ShortDescription = "High Beastmasters only. -1 T per unsaved wound (min 1)";
        private static string LongDescription = "High Beastmasters only. Any enemy model that suffers one or more unsaved wounds from the Whip of Agony suffers a -1 modifier to its Toughness characteristic (to a minimum of 1) for the remainder of the game.";

        public WhipOfAgonyRules()
            : base(TowSpecialRuleType.WhipOfAgonyRules,
                ShortDescription,
                LongDescription,
                printName: false)
        {
        }
    }
}
