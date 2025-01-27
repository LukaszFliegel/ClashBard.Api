using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.EnchantedItems;

public class PotionOfStrengthTowEnchantedItem : TowEnchantedItem
{
    private const int points = 25;
    

    public PotionOfStrengthTowEnchantedItem(TowObject owner) : base(owner, TowMagicItemEnchantedType.PotionOfStrength, points)
    {
        AssignSpecialRule(new PotionOfStrengthRules());
        
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
