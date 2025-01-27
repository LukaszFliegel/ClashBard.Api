using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class OgreBladeTowMagicWeapon : TowMagicWeapon
{
    private const int points = 65;

    public OgreBladeTowMagicWeapon(TowObject owner) : base(owner, TowMagicItemWeaponType.OgreBlade, points, 0, TowWeaponStrength.Splus2, 2)
    {
        AssignSpecialRule(new ArmourBane1());
        AssignSpecialRule(new MagicalAttacks());
        AssignSpecialRule(new MultipleWoundsD3());
    }
}
