using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class IthilmarArmour : TowSpecialRule
{
    private static string ShortDescription = "Ithilmar Armour";
    private static string LongDescription = "A suit of magical armour wrought from the legendary metal of Ithilmar, providing exceptional protection without hindering movement.";

    public IthilmarArmour()
        : base(TowSpecialRuleType.IthilmarArmour,
              ShortDescription,
              LongDescription)
    {
    }
}
