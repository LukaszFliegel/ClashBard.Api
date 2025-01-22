using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.EnchantedItems;

public class FlyingCarpetTowEnchantedItem : TowEnchantedItem
{
    private const int points = 40;
    

    public FlyingCarpetTowEnchantedItem() : base(TowMagicItemEnchantedType.FlyingCarpet, points)
    {
        SpecialRules.Add(new FlyingCarpetRules());
        
    }
}


public class FlyingCarpetRules : TowSpecialRule
{
    private static new string ShortDescription = "xxx";
    private static new string LongDescription = "xxx";

    public FlyingCarpetRules()
        : base(TowSpecialRuleType.FlyingCarpetRules,
            ShortDescription,
            LongDescription)
    {

    }
}
