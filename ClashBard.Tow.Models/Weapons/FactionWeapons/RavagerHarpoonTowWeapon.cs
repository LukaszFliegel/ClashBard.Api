using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class RavagerHarpoonTowWeapon : TowWeapon
{
    public RavagerHarpoonTowWeapon(TowObject owner) : base(owner, TowTypes.TowWeaponType.RavagerHarpoon, 24, TowWeaponStrength.Six, 3)
    {
        AssignSpecialRule(new Cumbersome());
        AssignSpecialRule(new MultipleWoundsD3());
        AssignSpecialRule(new Ponderous());
        AssignSpecialRule(new RavagerHarpoonNotes());
    }
}
