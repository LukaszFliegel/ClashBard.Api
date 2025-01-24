using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class CavernousMawTowWeapon : TowWeapon
{
    public CavernousMawTowWeapon(TowObject owner) : base(owner, TowTypes.TowWeaponType.CavernousMaw, 2, TowWeaponStrength.S, 2)
    {
        SpecialRules.Add(new ArmourBane1());
        SpecialRules.Add(new KillingBlow());
        SpecialRules.Add(new CavernousMawNotes());
    }
}
