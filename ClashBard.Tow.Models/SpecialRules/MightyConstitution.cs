using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class MightyConstitution : TowSpecialRule
{
    private static string ShortDescription = "Mighty Constitution";
    private static string LongDescription = "A character with this special rule has a higher toughness characteristic than normal, representing their exceptional physical resilience and constitution.";

    public MightyConstitution()
        : base(TowSpecialRuleType.MightyConstitution,
              ShortDescription,
              LongDescription)
    {
    }
}
