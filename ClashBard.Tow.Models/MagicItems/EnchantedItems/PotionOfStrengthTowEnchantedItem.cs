using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.EnchantedItems;

public class PotionOfStrengthTowEnchantedItem : TowEnchantedItem
{
    private const int points = 25;
    

    public PotionOfStrengthTowEnchantedItem() : base(TowMagicItemEnchantedType.PotionOfStrength, points)
    {
        SpecialRules.Add(new PotionOfStrengthRules());
        
    }
}


public class PotionOfStrengthRules : TowSpecialRule
{
    private static string ShortDescription = "xxx";
    private static string LongDescription = "xxx";

    public PotionOfStrengthRules()
        : base(TowSpecialRuleType.PotionOfStrengthRules,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}
