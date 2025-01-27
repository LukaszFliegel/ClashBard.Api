using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class SerratedMawTowWeapon : TowWeapon
{
    public SerratedMawTowWeapon(TowObject owner) : base(owner, TowTypes.TowWeaponType.SerratedMaw, 0, TowWeaponStrength.S, 0)
    {
        AssignSpecialRule(new ArmourBane2());
        AssignSpecialRule(new MultipleWounds2());
        AssignSpecialRule(new SerratedMawNotes());
    }
}
