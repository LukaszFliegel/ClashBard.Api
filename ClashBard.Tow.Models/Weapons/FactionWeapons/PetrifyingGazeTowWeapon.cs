using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class PetrifyingGazeTowWeapon : TowWeapon
{
    public PetrifyingGazeTowWeapon(TowObject owner) : base(owner, TowTypes.TowWeaponType.PetrifyingGaze, 0, TowWeaponStrength.Two, 0)
    {
        SpecialRules.Add(new MagicalAttacks());
        SpecialRules.Add(new MultipleWoundsD3());
        SpecialRules.Add(new PetrifyingGazeNotes());
    }
}
