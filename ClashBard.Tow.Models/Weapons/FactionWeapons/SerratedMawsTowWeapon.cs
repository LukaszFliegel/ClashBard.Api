using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class SerratedMawsTowWeapon : TowWeapon
{
    public SerratedMawsTowWeapon() : base(TowTypes.TowWeaponType.SerratedMaw, 0, TowWeaponStrength.S, 0)
    {
        SpecialRules.Add(new ArmourBane1());
        SpecialRules.Add(new MultipleWounds2());
        SpecialRules.Add(new SerratedMawsNotes());
    }
}
