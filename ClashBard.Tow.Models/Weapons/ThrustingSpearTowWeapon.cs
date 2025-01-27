using ClashBard.Tow.Models.SpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class ThrustingSpearTowWeapon : TowWeapon
{
    public ThrustingSpearTowWeapon(TowObject owner) : base(owner, TowTypes.TowWeaponType.ThrustingSpear, 0, TowWeaponStrength.S, 0)
    {
        AssignSpecialRule(new FightinExtraRankAnyTurnTheyDidNotCharge());
    }
}
