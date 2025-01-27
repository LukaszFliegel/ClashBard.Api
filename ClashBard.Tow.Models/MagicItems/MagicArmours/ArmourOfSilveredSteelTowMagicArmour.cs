using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicArmours;

public class ArmourOfSilveredSteelTowMagicArmour : TowMagicArmour
{
    private const int points = 40;

    public ArmourOfSilveredSteelTowMagicArmour(TowObject owner) : base(owner, TowMagicItemArmorType.ArmourOfSilveredSteel, points, 999)
    {
        //AssignSpecialRule(new ArmourBane1());
        //AssignSpecialRule(new MagicalAttacks());
        //AssignSpecialRule(new MultipleWoundsD3());
    }
}
