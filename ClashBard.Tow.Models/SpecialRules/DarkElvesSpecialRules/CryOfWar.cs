using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class CryOfWar : TowSpecialRule
{
    private static string ShortDescription = "Enemy units -1Ld whilst within command range";
    private static string LongDescription = "Enemy units suffer a -1 modifier to their Leadership characteristic whilst within the Command range of one or more Death Hags that have this special rule and that are not fleeing.";

    public CryOfWar()
        : base(TowSpecialRuleType.CryOfWar,
            ShortDescription,
            LongDescription, 
            printName: false)
    {

    }
}
