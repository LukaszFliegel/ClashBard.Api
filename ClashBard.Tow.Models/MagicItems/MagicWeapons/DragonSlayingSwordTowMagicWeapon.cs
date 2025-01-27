using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class DragonSlayingSwordTowMagicWeapon : TowMagicWeapon
{
    private const int points = 50;

    public DragonSlayingSwordTowMagicWeapon(TowObject owner) : base(owner, TowMagicItemWeaponType.DragonSlayingSword, points, 0, TowWeaponStrength.S, 0)
    {
        AssignSpecialRule(new MagicalAttacks());
        AssignSpecialRule(new MonsterSlayer());
    }
}
