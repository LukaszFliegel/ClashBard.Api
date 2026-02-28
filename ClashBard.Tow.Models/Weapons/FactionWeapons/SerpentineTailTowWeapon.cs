using ClashBard.Tow.Models.SpecialRules;

namespace ClashBard.Tow.Models.Weapons.FactionWeapons;

public class SerpentineTailTowWeapon : TowWeapon
{
    // Combat, S+2, -2 AP, Strike Last. One attack per turn must use this weapon.
    public SerpentineTailTowWeapon(TowObject owner) 
        : base(owner, TowTypes.TowWeaponType.SerpentineTail, 0, TowWeaponStrength.Splus2, -2)
    {
        AssignSpecialRule(new StrikeLast());
    }
}
