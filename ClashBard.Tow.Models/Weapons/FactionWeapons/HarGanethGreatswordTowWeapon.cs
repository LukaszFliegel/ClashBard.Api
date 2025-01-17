using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

namespace ClashBard.Tow.Models.Weapons;

public class HarGanethGreatswordTowWeapon : TowWeapon
{
    public HarGanethGreatswordTowWeapon() : base(TowTypes.TowWeaponType.HarGanethGreatsword, 0, TowWeaponStrength.Splus2, 1)
    {
        SpecialRules.Add(new CleavingBlow());
        SpecialRules.Add(new RequiresTwoHands());
    }
}
