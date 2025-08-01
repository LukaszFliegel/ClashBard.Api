using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;

public class ValourOfAges : TowSpecialRule
{
    private static string ShortDescription = "Immunity to Fear and Terror";
    private static string LongDescription = "Models with this special rule are immune to Fear and Terror.";

    public ValourOfAges()
        : base(TowSpecialRuleType.ValourOfAges,
            ShortDescription,
            LongDescription)
    {

    }
}
