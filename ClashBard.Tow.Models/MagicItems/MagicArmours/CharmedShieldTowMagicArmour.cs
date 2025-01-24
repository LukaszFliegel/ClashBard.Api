using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicArmours;

public class CharmedShieldTowMagicArmour : TowMagicArmour
{
    private const int points = 5;

    public CharmedShieldTowMagicArmour(TowObject owner) : base(owner, TowMagicItemArmorType.CharmedShield, points, 999)
    {
        //SpecialRules.Add(new ArmourBane1());
        //SpecialRules.Add(new MagicalAttacks());
        //SpecialRules.Add(new MultipleWoundsD3());
    }
}
