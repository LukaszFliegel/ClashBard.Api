using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class BitingBlade : TowMagicWeapon
{
    private const int points = 15;

    public BitingBlade() : base(TowMagicItemWeaponType.BitingBlade, points, 0, TowWeaponStrength.S, 2)
    {
        SpecialRules.Add(new ArmourBane1());
        SpecialRules.Add(new MagicalAttacks());
    }
}
