using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class SpelleaterAxeTowMagicWeapon : TowMagicWeapon
{
    private const int points = 35;

    public SpelleaterAxeTowMagicWeapon(TowObject owner) : base(owner, TowMagicItemWeaponType.SpelleaterAxe, points, 0, TowWeaponStrength.S, 1)
    {
        AssignSpecialRule(new MagicalAttacks());
        AssignSpecialRule(new MagicResistance2());
    }
}
