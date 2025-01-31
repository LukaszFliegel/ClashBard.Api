using ClashBard.Tow.Models.SpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class ThrowingWeaponsTowWeapon : TowWeapon
{
    public ThrowingWeaponsTowWeapon(TowObject owner) : base(owner, TowTypes.TowWeaponType.ThrowingWeapons, 9, TowWeaponStrength.S, 0)
    {
        AssignSpecialRule(new MoveAndShoot());
        AssignSpecialRule(new MultipleShots2());
        AssignSpecialRule(new QuickShot());
    }
}
