using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class HeadsmansAxeTowMagicWeapon : TowMagicWeapon
{
    private const int points = 45;

    public HeadsmansAxeTowMagicWeapon(TowObject owner) : base(owner, TowMagicItemWeaponType.HeadsmansAxe, points, 0, TowWeaponStrength.Splus1, 1)
    {
        AssignSpecialRule(new KillingBlow());
        AssignSpecialRule(new MagicalAttacks());
        AssignSpecialRule(new RequiresTwoHands());
    }
}
