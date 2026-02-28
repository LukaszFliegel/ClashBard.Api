using ClashBard.Tow.Models.SpecialRules;

namespace ClashBard.Tow.Models.Weapons.FactionWeapons;

public class LashingTalonsTowWeapon : TowWeapon
{
    // Combat, S, -1 AP, Armour Bane (1)
    public LashingTalonsTowWeapon(TowObject owner) 
        : base(owner, TowTypes.TowWeaponType.LashingTalons, 0, TowWeaponStrength.S, -1)
    {
        AssignSpecialRule(new ArmourBane1());
    }
}
