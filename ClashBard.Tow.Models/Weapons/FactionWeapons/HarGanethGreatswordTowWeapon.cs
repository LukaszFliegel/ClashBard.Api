using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class HarGanethGreatswordTowWeapon : TowWeapon
{
    public HarGanethGreatswordTowWeapon(TowObject owner) : base(owner, TowTypes.TowWeaponType.HarGanethGreatsword, 1, TowWeaponStrength.Splus2, 1)
    {
        AssignSpecialRule(new CleavingBlow());
        AssignSpecialRule(new RequiresTwoHands());
    }
}
