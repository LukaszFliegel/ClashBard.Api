using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class GiantBlade : TowMagicWeapon
{
    private const int points = 30;

    public GiantBlade() : base(TowMagicItemWeaponType.GiantBlade, points, 0, TowWeaponStrength.Splus1, 0)
    {
        SpecialRules.Add(new ArmourBane2());
        SpecialRules.Add(new MagicalAttacks());
        SpecialRules.Add(new MultipleWounds2());
    }
}
