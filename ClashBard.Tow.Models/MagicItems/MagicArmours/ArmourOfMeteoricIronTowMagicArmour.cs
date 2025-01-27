using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicArmours;

public class ArmourOfMeteoricIronTowMagicArmour : TowMagicArmour
{
    private const int points = 20;

    public ArmourOfMeteoricIronTowMagicArmour(TowObject owner) : base(owner, TowMagicItemArmorType.ArmourOfMeteoricIron, points, 999)
    {
        //AssignSpecialRule(new ArmourBane1());
        //AssignSpecialRule(new MagicalAttacks());
        //AssignSpecialRule(new MultipleWoundsD3());
    }
}
