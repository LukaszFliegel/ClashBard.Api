using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class FieryBreathTowWeapon : TowWeapon
{
    public FieryBreathTowWeapon(TowObject owner) : base(owner, TowTypes.TowWeaponType.FieryBreath, null, TowWeaponStrength.Special, 1)
    {
        AssignSpecialRule(new BreathWeapon());
        AssignSpecialRule(new FlamingAttacks());
        AssignSpecialRule(new FieryBreathNotes());
    }
}