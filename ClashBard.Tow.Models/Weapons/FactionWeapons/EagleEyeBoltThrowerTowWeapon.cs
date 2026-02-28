using ClashBard.Tow.Models.SpecialRules;

namespace ClashBard.Tow.Models.Weapons.FactionWeapons;

public class EagleEyeBoltThrowerTowWeapon : TowWeapon
{
    // 24", S5, -3 AP, Cumbersome, Multiple Wounds (D3)
    public EagleEyeBoltThrowerTowWeapon(TowObject owner) 
        : base(owner, TowTypes.TowWeaponType.EagleEyeBoltThrower, 24, TowWeaponStrength.Five, -3)
    {
        AssignSpecialRule(new Cumbersome());
        AssignSpecialRule(new MultipleWoundsD3());
    }
}
