using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class SwordOfSwiftnessTowMagicWeapon : TowMagicWeapon
{
    private const int points = 25;

    public SwordOfSwiftnessTowMagicWeapon(TowObject owner) : base(owner, TowMagicItemWeaponType.SwordOfSwiftness, points, 0, TowWeaponStrength.S, 7077)
    {
        AssignSpecialRule(new MagicalAttacks());
        AssignSpecialRule(new StrikeFirst());
    }
}
