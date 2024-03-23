using ClashBard.Tow.Models.SpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class ThrustingSpearTowWeapon : TowWeapon
{
    public ThrustingSpearTowWeapon() : base(TowTypes.TowWeaponType.ThrustingSpear, 0, TowWeaponStrength.S, 0)
    {
        SpecialRules.Add(new FightinExtraRankAnyTurnTheyDidNotCharge());
    }
}
