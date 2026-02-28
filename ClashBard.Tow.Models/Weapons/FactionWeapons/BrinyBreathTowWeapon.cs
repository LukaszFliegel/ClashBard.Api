using ClashBard.Tow.Models.SpecialRules;

namespace ClashBard.Tow.Models.Weapons.FactionWeapons;

public class BrinyBreathTowWeapon : TowWeapon
{
    // N/A range, S2, -2 AP, Breath Weapon.
    // Any enemy unit suffering unsaved Wounds suffers -1 Initiative until next Start of Turn.
    public BrinyBreathTowWeapon(TowObject owner) 
        : base(owner, TowTypes.TowWeaponType.BrinyBreath, null, TowWeaponStrength.Two, -2)
    {
        AssignSpecialRule(new BreathWeapon());
    }
}
