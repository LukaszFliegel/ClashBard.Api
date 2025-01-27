using ClashBard.Tow.Models.SpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class LanceTowWeapon : TowWeapon
{
    public LanceTowWeapon(TowObject owner) : base(owner, TowTypes.TowWeaponType.Lance, 0, TowWeaponStrength.Splus2, 2)
    {
        AssignSpecialRule(new ArmourBane1());
        AssignSpecialRule(new TurnUserCharged());
    }
}
