using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class SerratedMawsTowWeapon : TowWeapon
{
    public SerratedMawsTowWeapon(TowObject owner) : base(owner, TowTypes.TowWeaponType.SerratedMaw, 0, TowWeaponStrength.S, 0)
    {
        AssignSpecialRule(new ArmourBane1());
        AssignSpecialRule(new MultipleWounds2());
        AssignSpecialRule(new SerratedMawsNotes());
    }
}
