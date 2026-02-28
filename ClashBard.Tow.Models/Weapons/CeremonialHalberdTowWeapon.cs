using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Weapons;

public class CeremonialHalberdTowWeapon : TowWeapon
{
    public CeremonialHalberdTowWeapon(TowObject owner) 
        : base(owner, TowWeaponType.CeremonialHalberd, 0, TowWeaponStrength.Splus1, -1)
    {
        // Ceremonial halberds used by Phoenix Guard - similar to regular halberds
        // Provides +1 Strength and -1 Armor save modifier
    }
}
