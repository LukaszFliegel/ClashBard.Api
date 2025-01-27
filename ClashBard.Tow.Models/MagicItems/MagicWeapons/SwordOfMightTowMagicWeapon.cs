using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class SwordOfMightTowMagicWeapon : TowMagicWeapon
{
    private const int points = 20;

    public SwordOfMightTowMagicWeapon(TowObject owner) : base(owner, TowMagicItemWeaponType.SwordOfMight, points, 0, TowWeaponStrength.Splus1, 1)
    {
        AssignSpecialRule(new MagicalAttacks());
        AssignSpecialRule(new ExtremelyCommon());
    }
}
