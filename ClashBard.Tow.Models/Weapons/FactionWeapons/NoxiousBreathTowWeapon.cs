using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class NoxiousBreathTowWeapon : TowWeapon
{
    public NoxiousBreathTowWeapon(TowObject owner) : base(owner, TowTypes.TowWeaponType.NoxiousBreath, null, TowWeaponStrength.Four, 0)
    {
        SpecialRules.Add(new BreathWeapon());
        SpecialRules.Add(new NoxiousBreathNotes());
    }
}