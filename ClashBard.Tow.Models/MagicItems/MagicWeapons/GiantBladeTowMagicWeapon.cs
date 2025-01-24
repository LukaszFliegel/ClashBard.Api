using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class GiantBladeTowMagicWeapon : TowMagicWeapon
{
    private const int points = 30;

    public GiantBladeTowMagicWeapon(TowObject owner) : base(owner, TowMagicItemWeaponType.GiantBlade, points, 0, TowWeaponStrength.Splus1, 0)
    {
        SpecialRules.Add(new ArmourBane2());
        SpecialRules.Add(new MagicalAttacks());
        SpecialRules.Add(new MultipleWounds2());
    }
}
