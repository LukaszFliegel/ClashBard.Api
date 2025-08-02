using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class ArrowsOfIsha : TowSpecialRule
{
    private static string ShortDescription = "Arrows of Isha";
    private static string LongDescription = "A model with this special rule uses blessed arrows infused with the power of Isha, goddess of healing and nature, granting special properties to their ranged attacks.";

    public ArrowsOfIsha()
        : base(TowSpecialRuleType.ArrowsOfIsha,
              ShortDescription,
              LongDescription)
    {
    }
}
