using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class BurningBladeTowMagicWeapon : TowMagicWeapon
{
    private const int points = 5;

    public BurningBladeTowMagicWeapon(TowObject owner) : base(owner, TowMagicItemWeaponType.BurningBlade, points, 0, TowWeaponStrength.S, 0)
    {
        AssignSpecialRule(new FlamingAttacks());
        AssignSpecialRule(new MagicalAttacks());
        AssignSpecialRule(new ExtremelyCommon());
    }
}
