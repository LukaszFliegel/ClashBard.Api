using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.EnchantedItems;

public class HealingPotionTowEnchantedItem : TowEnchantedItem
{
    private const int points = 35;
    

    public HealingPotionTowEnchantedItem() : base(TowMagicItemEnchantedType.HealingPotion, points)
    {
        SpecialRules.Add(new HealingPotionRules());
        
    }
}


public class HealingPotionRules : TowSpecialRule
{
    private static new string ShortDescription = "xxx";
    private static new string LongDescription = "xxx";

    public HealingPotionRules()
        : base(TowSpecialRuleType.HealingPotionRules,
            ShortDescription,
            LongDescription)
    {

    }
}
