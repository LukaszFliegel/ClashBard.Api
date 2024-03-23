using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Impetuous : TowSpecialRule
{
    private static new string ShortDescription = "The eagerness of brash and brave warriors can lead them into foolish charges.";
    private static new string LongDescription = "If during the Declare Charges & Charge Reactions sub-phase of its turn, a unit that includes one or more Impetuous models is able to declare a charge, roll a D6. On a roll of 1-3, the unit must declare a charge. On a roll of 4+, the unit may act as normal.";

    public Impetuous()
        : base(TowSpecialRuleType.Impetuous,
            ShortDescription,
            LongDescription)
    {

    }
}
