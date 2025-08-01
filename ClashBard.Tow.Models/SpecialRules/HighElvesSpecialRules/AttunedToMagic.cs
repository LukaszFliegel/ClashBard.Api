using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;

public class AttunedToMagic : TowSpecialRule
{
    private static string ShortDescription = "+1 to cast, dispel and channel";
    private static string LongDescription = "Models with this special rule add +1 to all casting, dispelling and channelling attempts.";

    public AttunedToMagic()
        : base(TowSpecialRuleType.AttunedToMagic,
            ShortDescription,
            LongDescription)
    {

    }
}
