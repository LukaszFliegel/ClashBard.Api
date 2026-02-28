using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Weapons;

public class LongbowTowWeapon : TowWeapon
{
    public LongbowTowWeapon(TowObject owner) 
        : base(owner, TowWeaponType.Longbow, 30, TowWeaponStrength.Three, 0)
    {
        // Longbow - Range 30", Strength 3, no armor save modifier
        // Standard missile weapon used by Shadow Warriors and other elven units
    }
}
