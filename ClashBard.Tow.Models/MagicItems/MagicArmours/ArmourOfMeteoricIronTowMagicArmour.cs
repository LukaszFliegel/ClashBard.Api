using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicArmours;

public class ArmourOfMeteoricIronTowMagicArmour : TowMagicArmour
{
    private const int points = 20;

    public ArmourOfMeteoricIronTowMagicArmour() : base(TowMagicItemArmorType.ArmourOfMeteoricIron, points, 999)
    {
        //SpecialRules.Add(new ArmourBane1());
        //SpecialRules.Add(new MagicalAttacks());
        //SpecialRules.Add(new MultipleWoundsD3());
    }
}
