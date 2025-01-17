using ClashBard.Tow.Models.SpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class LanceTowWeapon : TowWeapon
{
    public LanceTowWeapon() : base(TowTypes.TowWeaponType.Lance, 0, TowWeaponStrength.Splus2, 2)
    {
        SpecialRules.Add(new ArmourBane1());
        SpecialRules.Add(new TurnUserCharged());
    }
}
