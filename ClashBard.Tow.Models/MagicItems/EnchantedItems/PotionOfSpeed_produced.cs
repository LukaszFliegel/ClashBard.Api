using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.EnchantedItems;

public class PotionOfSpeed : TowEnchantedItem
{
    private const int points = 10;
    

    public PotionOfSpeed() : base(TowMagicItemEnchantedType.PotionOfSpeed, points)
    {
        SpecialRules.Add(new PotionOfSpeedRules());
        
    }
}


public class PotionOfSpeedRules : TowSpecialRule
{
    private static new string ShortDescription = "xxx";
    private static new string LongDescription = "xxx";

    public PotionOfSpeedRules()
        : base(TowSpecialRuleType.PotionOfSpeedRules,
            ShortDescription,
            LongDescription)
    {

    }
}
