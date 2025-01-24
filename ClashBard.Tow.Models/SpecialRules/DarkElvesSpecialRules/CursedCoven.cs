using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class CursedCoven : TowSpecialRule
{
    private static string ShortDescription = "Knows single spell from Dark Magic or Demonology";
    private static string LongDescription = "A unit of Doomfire Warlocks knows a single spell (chosen by their controlling player before armies are deployed) from either the Dark Magic or Daemonology Lore of Magic. The unit may cast this spell as a Bound spell: If the unit has a Unit Strength of 10 or more and includes a Master, it may cast this Bound spell with a Power Level of 2. If the unit includes a Master, but has a Unit Strength of 9 or less, it may cast this Bound spell with a Power Level of 1. Otherwise, the unit may cast this Bound spell with a Power Level of 0.";

    public CursedCoven()
        : base(TowSpecialRuleType.CursedCoven,
            ShortDescription,
            LongDescription)
    {

    }
}
