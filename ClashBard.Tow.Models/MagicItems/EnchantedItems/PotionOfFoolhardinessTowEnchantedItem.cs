using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.EnchantedItems;

public class PotionOfFoolhardinessTowEnchantedItem : TowEnchantedItem
{
    private const int points = 5;
    

    public PotionOfFoolhardinessTowEnchantedItem(TowObject owner) : base(owner, TowMagicItemEnchantedType.PotionOfFoolhardiness, points)
    {
        AssignSpecialRule(new PotionOfFoolhardinessRules());
        
    }
}


public class PotionOfFoolhardinessRules : TowSpecialRule
{
    private static string ShortDescription = "xxx";
    private static string LongDescription = "xxx";

    public PotionOfFoolhardinessRules()
        : base(TowSpecialRuleType.PotionOfFoolhardinessRules,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}
