using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class SwordOfMight : TowMagicWeapon
{
    private const int points = 20;

    public SwordOfMight() : base(TowMagicItemWeaponType.SwordOfMight, points, 0, TowWeaponStrength.Splus1, 1)
    {
        SpecialRules.Add(new MagicalAttacks());
        SpecialRules.Add(new ExtremelyCommon());
    }
}
