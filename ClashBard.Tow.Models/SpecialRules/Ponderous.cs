using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Ponderous : TowSpecialRule
{
    private static new string ShortDescription = "Many weapons are too unwieldy to be used with any accuracy by a warrior on the move.";
    private static new string LongDescription = "A weapon with this special rule suffers a To Hit modifier of -2 for Moving and Shooting, rather than the usual -1.";

    public Ponderous()
        : base(TowSpecialRuleType.Ponderous,
            ShortDescription,
            LongDescription)
    {

    }
}
