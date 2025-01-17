using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.EnchantedItems;

public class WizardingHat : TowEnchantedItem
{
    private const int points = 45;
    

    public WizardingHat() : base(TowMagicItemEnchantedType.WizardingHat, points)
    {
        SpecialRules.Add(new WizardingHatRules());
        
    }
}


public class WizardingHatRules : TowSpecialRule
{
    private static new string ShortDescription = "xxx";
    private static new string LongDescription = "xxx";

    public WizardingHatRules()
        : base(TowSpecialRuleType.WizardingHatRules,
            ShortDescription,
            LongDescription)
    {

    }
}
