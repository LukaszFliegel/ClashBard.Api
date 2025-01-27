using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class LashAndBucklerTowWeapon : TowWeapon
{
    public LashAndBucklerTowWeapon(TowObject owner) : base(owner, TowTypes.TowWeaponType.LashAndBuckler, 1, TowWeaponStrength.S, 1)
    {
        AssignSpecialRule(new ArmourBane1());
        AssignSpecialRule(new FightInExtraRank());
        AssignSpecialRule(new RequiresTwoHands());
        AssignSpecialRule(new LashAndBucklerArmor());
    }
}
