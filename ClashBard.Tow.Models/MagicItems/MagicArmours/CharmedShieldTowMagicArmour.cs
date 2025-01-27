using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicArmours;

public class CharmedShieldTowMagicArmour : TowMagicArmour
{
    private const int points = 5;

    public CharmedShieldTowMagicArmour(TowObject owner) : base(owner, TowMagicItemArmorType.CharmedShield, points, 999)
    {
        //AssignSpecialRule(new ArmourBane1());
        //AssignSpecialRule(new MagicalAttacks());
        //AssignSpecialRule(new MultipleWoundsD3());
    }
}
