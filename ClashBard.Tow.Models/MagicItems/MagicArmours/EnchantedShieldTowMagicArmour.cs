using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicArmours;

public class EnchantedShieldTowMagicArmour : TowMagicArmour
{
    private const int points = 10;

    public EnchantedShieldTowMagicArmour(TowObject owner) : base(owner, TowMagicItemArmorType.EnchantedShield, points, 999)
    {
        //SpecialRules.Add(new ArmourBane1());
        //SpecialRules.Add(new MagicalAttacks());
        //SpecialRules.Add(new MultipleWoundsD3());
    }
}
