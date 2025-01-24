using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class MoveOrShoot : TowSpecialRule
{
    private static string ShortDescription = "Artillery weapons sacrifice a speedy reload and manoeuvrability for range and power, making them impossible to fire on the move.";
    private static string LongDescription = "A weapon with this special rule cannot be used in the Shooting phase if the model equipped with it moved for any reason during this turn (including rallying and reforming).";

    public MoveOrShoot()
        : base(TowSpecialRuleType.MoveOrShoot,
            ShortDescription,
            LongDescription)
    {

    }
}
