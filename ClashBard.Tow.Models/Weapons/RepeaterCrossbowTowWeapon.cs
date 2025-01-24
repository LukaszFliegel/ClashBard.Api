using ClashBard.Tow.Models.SpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class RepeaterCrossbowTowWeapon : TowWeapon
{   
    public RepeaterCrossbowTowWeapon(TowObject owner) : base(owner, TowTypes.TowWeaponType.RepeaterCrossbow, 24, TowWeaponStrength.Three, 0)
    {
        SpecialRules.Add(new ArmourBane1());
        SpecialRules.Add(new MultipleShots2());
    }
}
