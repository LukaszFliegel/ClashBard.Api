using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class IthilmarWeapons : TowSpecialRule
{
    private static string ShortDescription = "Ithilmar Weapons";
    private static string LongDescription = "All weapons carried by models with this special rule are made from Ithilmar, an incredibly light magical metal that allows warriors to fight with enhanced speed and precision.";

    public IthilmarWeapons()
        : base(TowSpecialRuleType.IthilmarWeapons,
              ShortDescription,
              LongDescription)
    {
    }
}
