using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class QuickShot : TowSpecialRule
{
    private static string ShortDescription = "No -1 To Hit after move, can always Stand & Shoot";
    private static string LongDescription = "A weapon with this special rule does not suffer the usual -1 To Hit modifier for Moving and Shooting. In addition, a unit equipped with weapons with this special rule can use them to make a Stand & Shoot charge reaction regardless of how close the charging unit is.";

    public QuickShot()
        : base(TowSpecialRuleType.QuickShot,
            ShortDescription,
            LongDescription)
    {

    }
}
