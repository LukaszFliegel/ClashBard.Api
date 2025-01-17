using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class DuellistsBlades : TowMagicWeapon
{
    private const int points = 55;

    public DuellistsBlades() : base(TowMagicItemWeaponType.DuellistsBlades, points, 0, TowWeaponStrength.S, 1)
    {
        SpecialRules.Add(new ExtraAttacksPlus2());
        SpecialRules.Add(new MagicalAttacks());
        SpecialRules.Add(new RequiresTwoHands());
    }
}
