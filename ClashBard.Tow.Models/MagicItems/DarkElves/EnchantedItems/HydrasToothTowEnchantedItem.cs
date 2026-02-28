using ClashBard.Tow.Models.MagicItems.DarkElves;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.DarkElves.EnchantedItems;

/// <summary>
/// Fangs are taken from the maw of a slain Hydra and crafted into deadly throwing weapons.
/// A missile weapon: 9", S, AP-3. Magical Attacks, Move &amp; Shoot, Quick Shot.
/// Can target a specific model within the target unit (champion or character).
/// 30 points.
/// </summary>
public class HydrasToothTowEnchantedItem : TowEnchantedItem
{
    private const int points = 30;

    public HydrasToothTowEnchantedItem(TowObject owner)
        : base(owner, TowDarkElvesMagicItemType.HydrasTooth, points)
    {
        AssignSpecialRule(new MagicalAttacks());
        AssignSpecialRule(new HydrasToothRules());
    }

    protected class HydrasToothRules : TowSpecialRule
    {
        private static string ShortDescription = "9\" S AP-3. Move & Shoot, Quick Shot. Can target specific model";
        private static string LongDescription = "Hydra's Tooth is a missile weapon with the following profile: 9\", S, AP-3, Magical Attacks, Move & Shoot, Quick Shot. This weapon can target a specific model within the target unit, such as a champion or a character.";

        public HydrasToothRules()
            : base(TowSpecialRuleType.HydrasToothRules,
                ShortDescription,
                LongDescription,
                printName: false)
        {
        }
    }
}
