using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class SpelleaterAxe : TowMagicWeapon
{
    private const int points = 35;

    public SpelleaterAxe() : base(TowMagicItemWeaponType.SpelleaterAxe, points, 0, TowWeaponStrength.S, 1)
    {
        SpecialRules.Add(new MagicalAttacks());
        SpecialRules.Add(new MagicResistance2());
    }
}
