using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicArmours;

public class EnchantedShieldTowMagicArmour : TowMagicArmour
{
    private const int points = 10;

    public EnchantedShieldTowMagicArmour(TowObject owner) : base(owner, TowMagicItemArmorType.EnchantedShield, points, 999)
    {
        //AssignSpecialRule(new ArmourBane1());
        //AssignSpecialRule(new MagicalAttacks());
        //AssignSpecialRule(new MultipleWoundsD3());
    }
}
