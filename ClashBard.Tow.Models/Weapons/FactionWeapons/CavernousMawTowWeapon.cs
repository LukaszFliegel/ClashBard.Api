using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class CavernousMawTowWeapon : TowWeapon
{
    public CavernousMawTowWeapon(TowObject owner) : base(owner, TowTypes.TowWeaponType.CavernousMaw, null, TowWeaponStrength.S, 2)
    {
        AssignSpecialRule(new ArmourBane1());
        AssignSpecialRule(new KillingBlow());
        AssignSpecialRule(new CavernousMawNotes());
    }
}
