using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.EnchantedItems;

public class RubyRingOfRuinTowEnchantedItem : TowEnchantedItem
{
    private const int points = 30;
    

    public RubyRingOfRuinTowEnchantedItem(TowObject owner) : base(owner, TowMagicItemEnchantedType.RubyRingOfRuin, points)
    {
        SpecialRules.Add(new RubyRingOfRuinRules());
        
    }
}


public class RubyRingOfRuinRules : TowSpecialRule
{
    private static string ShortDescription = "xxx";
    private static string LongDescription = "xxx";

    public RubyRingOfRuinRules()
        : base(TowSpecialRuleType.RubyRingOfRuinRules,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}
