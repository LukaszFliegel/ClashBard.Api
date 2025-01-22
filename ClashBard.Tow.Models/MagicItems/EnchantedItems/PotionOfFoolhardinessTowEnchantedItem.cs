using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.EnchantedItems;

public class PotionOfFoolhardinessTowEnchantedItem : TowEnchantedItem
{
    private const int points = 5;
    

    public PotionOfFoolhardinessTowEnchantedItem() : base(TowMagicItemEnchantedType.PotionOfFoolhardiness, points)
    {
        SpecialRules.Add(new PotionOfFoolhardinessRules());
        
    }
}


public class PotionOfFoolhardinessRules : TowSpecialRule
{
    private static new string ShortDescription = "xxx";
    private static new string LongDescription = "xxx";

    public PotionOfFoolhardinessRules()
        : base(TowSpecialRuleType.PotionOfFoolhardinessRules,
            ShortDescription,
            LongDescription)
    {

    }
}
