using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class SerratedMawTowWeapon : TowWeapon
{
    public SerratedMawTowWeapon(TowObject owner) : base(owner, TowTypes.TowWeaponType.SerratedMaw, 0, TowWeaponStrength.S, 0)
    {
        SpecialRules.Add(new ArmourBane2());
        SpecialRules.Add(new MultipleWounds2());
        SpecialRules.Add(new SerratedMawNotes());
    }
}
