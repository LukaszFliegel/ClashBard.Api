using ClashBard.Tow.Models.SpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class CavalrySpearTowWeapon : TowWeapon
{
    public CavalrySpearTowWeapon(TowObject owner) : base(owner, TowTypes.TowWeaponType.CavalrySpear, null, TowWeaponStrength.Splus1, 1)
    {
        AssignSpecialRule(new TurnUserCharged());
        AssignSpecialRule(new FightinExtraRankAnyTurnTheyDidNotCharge());
    }
}
