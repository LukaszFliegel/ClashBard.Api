using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Unbreakable : TowSpecialRule
{
    private static new string ShortDescription = "Some warriors are so fearless that they will never run from the enemy.";
    private static new string LongDescription = "If a unit with this special rule loses a round of combat, it is not required to make a Break test. Instead, it will automatically Give Ground as it is pushed back by the enemy. Characters that are not Unbreakable cannot join units that are, and vice versa.";

    public Unbreakable()
        : base(TowSpecialRuleType.Unbreakable,
            ShortDescription,
            LongDescription)
    {

    }
}
