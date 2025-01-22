using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.EnchantedItems;

public class RubyRingOfRuinTowEnchantedItem : TowEnchantedItem
{
    private const int points = 30;
    

    public RubyRingOfRuinTowEnchantedItem() : base(TowMagicItemEnchantedType.RubyRingOfRuin, points)
    {
        SpecialRules.Add(new RubyRingOfRuinRules());
        
    }
}


public class RubyRingOfRuinRules : TowSpecialRule
{
    private static new string ShortDescription = "xxx";
    private static new string LongDescription = "xxx";

    public RubyRingOfRuinRules()
        : base(TowSpecialRuleType.RubyRingOfRuinRules,
            ShortDescription,
            LongDescription)
    {

    }
}
