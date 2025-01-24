using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class BerserkerBladeTowMagicWeapon : TowMagicWeapon
{
    private const int points = 20;

    public BerserkerBladeTowMagicWeapon(TowObject owner) : base(owner, TowMagicItemWeaponType.BerserkerBlade, points, 0, TowWeaponStrength.Splus1, 0)
    {
        SpecialRules.Add(new ExtraAttacksPlus1());
        SpecialRules.Add(new Impetuous());
        SpecialRules.Add(new MagicalAttacks());
    }
}
