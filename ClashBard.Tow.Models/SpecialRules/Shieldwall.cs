using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Shieldwall : TowSpecialRule
{
    private static string ShortDescription = "Presenting an impenetrable wall of shields to the foe, a regiment becomes almost unmovable.";
    private static string LongDescription = "Once per game, during a turn in which it was charged, a unit with this special rule that is arrayed in a Close Order formation, and that is equipped with and chooses to use shields, may Give Ground rather than Fall Back in Good Order.";

    public Shieldwall()
        : base(TowSpecialRuleType.Shieldwall,
            ShortDescription,
            LongDescription)
    {

    }
}
