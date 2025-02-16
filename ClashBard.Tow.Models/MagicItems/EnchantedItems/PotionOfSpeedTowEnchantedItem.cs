using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.EnchantedItems;

public class PotionOfSpeedTowEnchantedItem : TowEnchantedItem
{
    private const int points = 10;
    

    public PotionOfSpeedTowEnchantedItem(TowObject owner) : base(owner, TowMagicItemEnchantedType.PotionOfSpeed, points)
    {
        AssignSpecialRule(new PotionOfSpeedRules());
        
    }
}


public class PotionOfSpeedRules : TowSpecialRule
{
    private static string ShortDescription = "xxx";
    private static string LongDescription = "xxx";

    public PotionOfSpeedRules()
        : base(TowSpecialRuleType.PotionOfSpeedRules,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}
