using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class LionCloak : TowSpecialRule
{
    private static string ShortDescription = "Lion Cloak";
    private static string LongDescription = "A model with a Lion Cloak has special protection and abilities derived from wearing the pelt of a White Lion of Chrace, providing enhanced defense and ferocity in combat.";

    public LionCloak()
        : base(TowSpecialRuleType.LionCloak,
              ShortDescription,
              LongDescription)
    {
    }
}
