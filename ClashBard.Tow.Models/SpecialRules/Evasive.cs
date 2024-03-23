using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Evasive : TowSpecialRule
{
    private static new string ShortDescription = "In the face of enemy fire, it is often wise to step back! Some warriors are particularly adept at this manoeuvre.";
    private static new string LongDescription = "Once per turn, when this unit is declared the target during the enemy Shooting phase, it may choose to Fall Back in Good Order and will flee directly away from the enemy unit shooting at it. Once this unit has completed its move, the enemy unit may continue with its shooting as declared.";

    public Evasive()
        : base(TowSpecialRuleType.Evasive,
            ShortDescription,
            LongDescription)
    {

    }
}
