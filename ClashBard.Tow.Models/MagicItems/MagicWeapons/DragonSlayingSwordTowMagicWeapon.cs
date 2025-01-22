using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class DragonSlayingSwordTowMagicWeapon : TowMagicWeapon
{
    private const int points = 50;

    public DragonSlayingSwordTowMagicWeapon() : base(TowMagicItemWeaponType.DragonSlayingSword, points, 0, TowWeaponStrength.S, 0)
    {
        SpecialRules.Add(new MagicalAttacks());
        SpecialRules.Add(new MonsterSlayer());
    }
}
