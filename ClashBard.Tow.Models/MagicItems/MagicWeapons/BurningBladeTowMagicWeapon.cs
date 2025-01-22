using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class BurningBladeTowMagicWeapon : TowMagicWeapon
{
    private const int points = 5;

    public BurningBladeTowMagicWeapon() : base(TowMagicItemWeaponType.BurningBlade, points, 0, TowWeaponStrength.S, 0)
    {
        SpecialRules.Add(new FlamingAttacks());
        SpecialRules.Add(new MagicalAttacks());
        SpecialRules.Add(new ExtremelyCommon());
    }
}
