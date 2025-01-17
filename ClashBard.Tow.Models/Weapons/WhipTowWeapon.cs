using ClashBard.Tow.Models.SpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class WhipTowWeapon : TowWeapon
{
    public WhipTowWeapon() : base(TowTypes.TowWeaponType.Whip, 0, TowWeaponStrength.S, 0)
    {
        SpecialRules.Add(new FightInExtraRank());
        SpecialRules.Add(new StrikeFirst());
    }
}
