using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class WrithingTentaclesTowWeapon : TowWeapon
{
    public WrithingTentaclesTowWeapon(TowObject owner) : base(owner, TowTypes.TowWeaponType.CavernousMaw, 0, TowWeaponStrength.S, 2)
    {
        SpecialRules.Add(new PoisonedAttacks());
    }
}
