using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class CavernousMawTowWeapon : TowWeapon
{
    public CavernousMawTowWeapon() : base(TowTypes.TowWeaponType.CavernousMaw, 0, TowWeaponStrength.S, 2)
    {
        SpecialRules.Add(new ArmourBane1());
        SpecialRules.Add(new KillingBlow());
        SpecialRules.Add(new CavernousMawNotes());
    }
}
