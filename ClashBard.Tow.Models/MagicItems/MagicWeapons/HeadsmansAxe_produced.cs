using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class HeadsmansAxe : TowMagicWeapon
{
    private const int points = 45;

    public HeadsmansAxe() : base(TowMagicItemWeaponType.HeadsmansAxe, points, 0, TowWeaponStrength.Splus1, 1)
    {
        SpecialRules.Add(new KillingBlow());
        SpecialRules.Add(new MagicalAttacks());
        SpecialRules.Add(new RequiresTwoHands());
    }
}
