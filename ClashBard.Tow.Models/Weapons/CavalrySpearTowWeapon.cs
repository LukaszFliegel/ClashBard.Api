using ClashBard.Tow.Models.SpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class CavalrySpearTowWeapon : TowWeapon
{
    public CavalrySpearTowWeapon() : base(TowTypes.TowWeaponType.CavalrySpear, 0, TowWeaponStrength.Splus1, 1)
    {
        SpecialRules.Add(new TurnUserCharged());
        SpecialRules.Add(new FightinExtraRankAnyTurnTheyDidNotCharge());
    }
}
