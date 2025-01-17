using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class OgreBlade : TowMagicWeapon
{
    private const int points = 65;

    public OgreBlade() : base(TowMagicItemWeaponType.OgreBlade, points, 0, TowWeaponStrength.Splus2, 2)
    {
        SpecialRules.Add(new ArmourBane1());
        SpecialRules.Add(new MagicalAttacks());
        SpecialRules.Add(new MultipleWoundsD3());
    }
}
