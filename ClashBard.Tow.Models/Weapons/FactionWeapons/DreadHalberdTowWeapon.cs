using ClashBard.Tow.Models.SpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class DreadHalberdTowWeapon : TowWeapon
{
    public DreadHalberdTowWeapon(TowObject owner) : base(owner, TowTypes.TowWeaponType.DreadHalberd, 0, TowWeaponStrength.Splus1, 1)
    {
        SpecialRules.Add(new ArmourBane1());
        SpecialRules.Add(new FightinExtraRankAnyTurnTheyDidNotCharge());
        SpecialRules.Add(new RequiresTwoHands());
    }
}
