using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class SwordOfSwiftnessTowMagicWeapon : TowMagicWeapon
{
    private const int points = 25;

    public SwordOfSwiftnessTowMagicWeapon() : base(TowMagicItemWeaponType.SwordOfSwiftness, points, 0, TowWeaponStrength.S, 7077)
    {
        SpecialRules.Add(new MagicalAttacks());
        SpecialRules.Add(new StrikeFirst());
    }
}
