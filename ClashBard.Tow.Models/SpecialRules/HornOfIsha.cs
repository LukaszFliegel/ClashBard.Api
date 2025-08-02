using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class HornOfIsha : TowSpecialRule
{
    private static string ShortDescription = "Horn of Isha";
    private static string LongDescription = "A sacred horn blessed by Isha, goddess of healing, that can be blown to invoke her divine protection and healing powers upon nearby allies.";

    public HornOfIsha()
        : base(TowSpecialRuleType.HornOfIsha,
              ShortDescription,
              LongDescription)
    {
    }
}
