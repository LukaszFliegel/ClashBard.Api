using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class PetrifyingGazeTowWeapon : TowWeapon
{
    public PetrifyingGazeTowWeapon(TowObject owner) : base(owner, TowTypes.TowWeaponType.PetrifyingGaze, 0, TowWeaponStrength.Two, 0)
    {
        AssignSpecialRule(new MagicalAttacks());
        AssignSpecialRule(new MultipleWoundsD3());
        AssignSpecialRule(new PetrifyingGazeNotes());
    }
}
