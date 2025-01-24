using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.EnchantedItems;

public class WizardingHatTowEnchantedItem : TowEnchantedItem
{
    private const int points = 45;
    

    public WizardingHatTowEnchantedItem(TowObject owner) : base(owner, TowMagicItemEnchantedType.WizardingHat, points)
    {
        SpecialRules.Add(new WizardingHatRules());
        
    }
}


public class WizardingHatRules : TowSpecialRule
{
    private static string ShortDescription = "xxx";
    private static string LongDescription = "xxx";

    public WizardingHatRules()
        : base(TowSpecialRuleType.WizardingHatRules,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}
