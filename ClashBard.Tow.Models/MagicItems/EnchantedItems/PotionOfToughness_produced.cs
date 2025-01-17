using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.EnchantedItems;

public class PotionOfToughness : TowEnchantedItem
{
    private const int points = 20;
    

    public PotionOfToughness() : base(TowMagicItemEnchantedType.PotionOfToughness, points)
    {
        SpecialRules.Add(new PotionOfToughnessRules());
        
    }
}


public class PotionOfToughnessRules : TowSpecialRule
{
    private static new string ShortDescription = "xxx";
    private static new string LongDescription = "xxx";

    public PotionOfToughnessRules()
        : base(TowSpecialRuleType.PotionOfToughnessRules,
            ShortDescription,
            LongDescription)
    {

    }
}
