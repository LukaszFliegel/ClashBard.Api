using ClashBard.Tow.Models.SpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class CavalrySpearTowWeapon : TowWeapon
{
    public CavalrySpearTowWeapon(TowObject owner) : base(owner, TowTypes.TowWeaponType.CavalrySpear, 1, TowWeaponStrength.Splus1, 1)
    {
        SpecialRules.Add(new TurnUserCharged());
        SpecialRules.Add(new FightinExtraRankAnyTurnTheyDidNotCharge());
    }
}
