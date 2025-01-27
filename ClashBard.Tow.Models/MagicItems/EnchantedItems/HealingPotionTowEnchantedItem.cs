using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.EnchantedItems;

public class HealingPotionTowEnchantedItem : TowEnchantedItem
{
    private const int points = 35;
    

    public HealingPotionTowEnchantedItem(TowObject owner) : base(owner, TowMagicItemEnchantedType.HealingPotion, points)
    {
        AssignSpecialRule(new HealingPotionRules());
        
    }
}


public class HealingPotionRules : TowSpecialRule
{
    private static string ShortDescription = "xxx";
    private static string LongDescription = "xxx";

    public HealingPotionRules()
        : base(TowSpecialRuleType.HealingPotionRules,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}
