using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.EnchantedItems;

public class PotionOfStrength : TowEnchantedItem
{
    private const int points = 25;
    

    public PotionOfStrength() : base(TowMagicItemEnchantedType.PotionOfStrength, points)
    {
        SpecialRules.Add(new PotionOfStrengthRules());
        
    }
}


public class PotionOfStrengthRules : TowSpecialRule
{
    private static new string ShortDescription = "xxx";
    private static new string LongDescription = "xxx";

    public PotionOfStrengthRules()
        : base(TowSpecialRuleType.PotionOfStrengthRules,
            ShortDescription,
            LongDescription)
    {

    }
}
