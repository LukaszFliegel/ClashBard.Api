using ClashBard.Tow.Models.MagicItems.DarkElves;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.DarkElves.EnchantedItems;

/// <summary>
/// Set in black iron, this oval ruby grants mystical sight to the wearer.
/// Single use. The bearer and unit may re-roll any failed To Hit rolls in the Shooting phase.
/// 25 points.
/// </summary>
public class GuidingEyeTowEnchantedItem : TowEnchantedItem
{
    private const int points = 25;

    public GuidingEyeTowEnchantedItem(TowObject owner)
        : base(owner, TowDarkElvesMagicItemType.GuidingEye, points)
    {
        AssignSpecialRule(new SingleUse());
        AssignSpecialRule(new GuidingEyeRules());
    }

    protected class GuidingEyeRules : TowSpecialRule
    {
        private static string ShortDescription = "Single use. Bearer and unit re-roll failed To Hit in Shooting";
        private static string LongDescription = "Single use. The bearer of the Guiding Eye and any unit they have joined may re-roll any failed rolls To Hit made during the Shooting phase.";

        public GuidingEyeRules()
            : base(TowSpecialRuleType.GuidingEyeRules,
                ShortDescription,
                LongDescription,
                printName: false)
        {
        }
    }
}
