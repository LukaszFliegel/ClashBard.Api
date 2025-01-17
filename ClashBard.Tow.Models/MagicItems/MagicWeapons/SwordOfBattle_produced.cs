using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class SwordOfBattle : TowMagicWeapon
{
    private const int points = 60;

    public SwordOfBattle() : base(TowMagicItemWeaponType.SwordOfBattle, points, 0, TowWeaponStrength.Splus1, 1)
    {
        SpecialRules.Add(new ArmourBane1());
        SpecialRules.Add(new ExtraAttacksPlus1());
        SpecialRules.Add(new MagicalAttacks());
    }
}
