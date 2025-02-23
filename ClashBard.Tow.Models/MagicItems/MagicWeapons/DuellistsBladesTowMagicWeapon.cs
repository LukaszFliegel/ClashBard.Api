using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class DuellistsBladesTowMagicWeapon : TowMagicWeapon
{
    private const int points = 55;

    public DuellistsBladesTowMagicWeapon(TowObject owner) : base(owner, TowMagicItemWeaponType.DuellistsBlades, points, 0, TowWeaponStrength.S, 1)
    {
        AssignSpecialRule(new ExtraAttacksPlus2());
        AssignSpecialRule(new MagicalAttacks());
        AssignSpecialRule(new RequiresTwoHands());
    }
}
