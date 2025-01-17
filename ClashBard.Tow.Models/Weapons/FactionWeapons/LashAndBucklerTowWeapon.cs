using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class LashAndBucklerTowWeapon : TowWeapon
{
    public LashAndBucklerTowWeapon() : base(TowTypes.TowWeaponType.LashAndBuckler, 0, TowWeaponStrength.S, 1)
    {
        SpecialRules.Add(new ArmourBane1());
        SpecialRules.Add(new FightInExtraRank());
        SpecialRules.Add(new RequiresTwoHands());
        SpecialRules.Add(new LashAndBucklerArmor());
    }
}
