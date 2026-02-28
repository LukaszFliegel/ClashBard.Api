using ClashBard.Tow.Models.MagicItems.DarkElves;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.DarkElves.EnchantedItems;

/// <summary>
/// When a Black Dragon egg is eaten, the properties of the Dragon are temporarily passed on.
/// Single use. Bearer gains T6 and noxious breath until end of turn.
/// 35 points.
/// </summary>
public class BlackDragonEggTowEnchantedItem : TowEnchantedItem
{
    private const int points = 35;

    public BlackDragonEggTowEnchantedItem(TowObject owner)
        : base(owner, TowDarkElvesMagicItemType.BlackDragonEgg, points)
    {
        AssignSpecialRule(new SingleUse());
        AssignSpecialRule(new BlackDragonEggRules());
    }

    protected class BlackDragonEggRules : TowSpecialRule
    {
        private static string ShortDescription = "Single use. Until end of turn: T=6, gain noxious breath";
        private static string LongDescription = "Single use. During the Command sub-phase of their turn, the bearer of a Black Dragon Egg can consume it. Until the end of that turn, the model has a Toughness characteristic of 6 (which cannot be improved further) and gains noxious breath (see Warhammer: The Old World rulebook).";

        public BlackDragonEggRules()
            : base(TowSpecialRuleType.BlackDragonEggRules,
                ShortDescription,
                LongDescription,
                printName: false)
        {
        }
    }
}
