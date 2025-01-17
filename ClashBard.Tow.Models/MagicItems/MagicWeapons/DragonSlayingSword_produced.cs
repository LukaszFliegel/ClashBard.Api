using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class DragonSlayingSword : TowMagicWeapon
{
    private const int points = 50;

    public DragonSlayingSword() : base(TowMagicItemWeaponType.DragonSlayingSword, points, 0, TowWeaponStrength.S, 0)
    {
        SpecialRules.Add(new MagicalAttacks());
        SpecialRules.Add(new MonsterSlayer());
    }
}
