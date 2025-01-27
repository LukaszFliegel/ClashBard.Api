using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.EnchantedItems;

public class PotionOfToughnessTowEnchantedItem : TowEnchantedItem
{
    private const int points = 20;
    

    public PotionOfToughnessTowEnchantedItem(TowObject owner) : base(owner, TowMagicItemEnchantedType.PotionOfToughness, points)
    {
        AssignSpecialRule(new PotionOfToughnessRules());
        
    }
}


public class PotionOfToughnessRules : TowSpecialRule
{
    private static string ShortDescription = "xxx";
    private static string LongDescription = "xxx";

    public PotionOfToughnessRules()
        : base(TowSpecialRuleType.PotionOfToughnessRules,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}
