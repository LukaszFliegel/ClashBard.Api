using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class AbyssalHowl : TowSpecialRule
{
    private static string ShortDescription = "-1 to enemy Ld in 6\"";
    private static string LongDescription = "Whilst within 6\" of this model, enemy units suffer a -1 modifier to their Leadership characteristic (to a minimum of 2).";

    public AbyssalHowl()
        : base(TowSpecialRuleType.BlessingsOfKhaine,
            ShortDescription,
            LongDescription)
    {

    }
}
