using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Weapons;

public class HandmaidensSpearTowWeapon : TowWeapon
{
    public HandmaidensSpearTowWeapon(TowObject owner) 
        : base(owner, TowWeaponType.HandmaidensSpear, 0, TowWeaponStrength.S, 0)
    {
    }
}
