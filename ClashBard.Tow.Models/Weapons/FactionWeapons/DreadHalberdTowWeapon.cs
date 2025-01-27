using ClashBard.Tow.Models.SpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class DreadHalberdTowWeapon : TowWeapon
{
    public DreadHalberdTowWeapon(TowObject owner) : base(owner, TowTypes.TowWeaponType.DreadHalberd, 0, TowWeaponStrength.Splus1, 1)
    {
        AssignSpecialRule(new ArmourBane1());
        AssignSpecialRule(new FightinExtraRankAnyTurnTheyDidNotCharge());
        AssignSpecialRule(new RequiresTwoHands());
    }
}
