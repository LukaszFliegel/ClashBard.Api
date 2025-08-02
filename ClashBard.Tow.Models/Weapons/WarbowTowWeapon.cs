using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Weapons;

public class WarbowTowWeapon : TowWeapon
{
    public WarbowTowWeapon(TowObject owner) 
        : base(owner, TowWeaponType.Warbow, 30, TowWeaponStrength.Four, -1)
    {
    }
}
