using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class RequiresTwoHands : TowSpecialRule
{
    private static new string ShortDescription = "Requires two hands";
    private static new string LongDescription = "A model cannot use a shield alongside a weapon with this special rule during the Combat phase (a shield can still be used against wounds caused by shooting or magic during other phases of the game).";

    public RequiresTwoHands()
        : base(TowSpecialRuleType.RequiresTwoHands,
            ShortDescription,
            LongDescription,
            false)
    {

    }
}
