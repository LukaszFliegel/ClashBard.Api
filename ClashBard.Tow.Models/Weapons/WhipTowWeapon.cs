using ClashBard.Tow.Models.SpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class WhipTowWeapon : TowWeapon
{
    public WhipTowWeapon(TowObject owner) : base(owner, TowTypes.TowWeaponType.Whip, 0, TowWeaponStrength.S, 0)
    {
        AssignSpecialRule(new FightInExtraRank());
        AssignSpecialRule(new StrikeFirst());
    }
}
