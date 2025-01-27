using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Ponderous : TowSpecialRule
{
    private static string ShortDescription = "-2 for Moving and Shooting";
    private static string LongDescription = "A weapon with this special rule suffers a To Hit modifier of -2 for Moving and Shooting, rather than the usual -1.";

    public Ponderous()
        : base(TowSpecialRuleType.Ponderous,
            ShortDescription,
            LongDescription)
    {

    }
}
