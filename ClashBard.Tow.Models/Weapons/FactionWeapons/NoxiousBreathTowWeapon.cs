using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class NoxiousBreathTowWeapon : TowWeapon
{
    public NoxiousBreathTowWeapon() : base(TowTypes.TowWeaponType.NoxiousBreath, null, TowWeaponStrength.Four, 0)
    {
        SpecialRules.Add(new BreathWeapon());
        SpecialRules.Add(new NoxiousBreathNotes());
    }
}