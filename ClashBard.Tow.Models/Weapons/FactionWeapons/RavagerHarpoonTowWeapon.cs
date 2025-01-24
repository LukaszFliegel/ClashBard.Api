using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class RavagerHarpoonTowWeapon : TowWeapon
{
    public RavagerHarpoonTowWeapon(TowObject owner) : base(owner, TowTypes.TowWeaponType.DreadHalberd, 24, TowWeaponStrength.Six, 3)
    {
        SpecialRules.Add(new Cumbersome());
        SpecialRules.Add(new MultipleWoundsD3());
        SpecialRules.Add(new Ponderous());
        SpecialRules.Add(new RavagerHarpoonNotes());
    }
}
