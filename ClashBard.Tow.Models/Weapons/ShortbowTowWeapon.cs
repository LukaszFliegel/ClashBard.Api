using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Weapons;

public class ShortbowTowWeapon : TowWeapon
{
    public ShortbowTowWeapon(TowObject owner) 
        : base(owner, TowWeaponType.Shortbow, 16, TowWeaponStrength.Three, 0)
    {
    }
}
