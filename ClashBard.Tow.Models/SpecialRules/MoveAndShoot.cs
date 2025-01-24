using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class MoveAndShoot : TowSpecialRule
{
    private static string ShortDescription = "Weapons that are easy to use when moving at speed may lack power or range, but make up for it with their versatility.";
    private static string LongDescription = "A weapon with this special rule can be used in the Shooting phase even if the model equipped with it marched this turn.";

    public MoveAndShoot()
        : base(TowSpecialRuleType.MoveAndShoot,
            ShortDescription,
            LongDescription)
    {

    }
}
