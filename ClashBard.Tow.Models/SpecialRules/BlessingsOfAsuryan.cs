using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class BlessingsOfAsuryan : TowSpecialRule
{
    private static string ShortDescription = "Blessings of Asuryan";
    private static string LongDescription = "A model with this special rule gains the divine protection of Asuryan, the Phoenix King, granting enhanced magical resistance and protective abilities.";

    public BlessingsOfAsuryan()
        : base(TowSpecialRuleType.BlessingsOfAsuryan,
              ShortDescription,
              LongDescription)
    {
    }
}
