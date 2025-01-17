using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class FieryBreathTowWeapon : TowWeapon
{
    public FieryBreathTowWeapon() : base(TowTypes.TowWeaponType.FieryBreath, null, TowWeaponStrength.Special, 1)
    {
        SpecialRules.Add(new BreathWeapon());
        SpecialRules.Add(new FlamingAttacks());
        SpecialRules.Add(new FieryBreathNotes());
    }
}