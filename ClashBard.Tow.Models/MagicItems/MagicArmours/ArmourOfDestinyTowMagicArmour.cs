using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicArmours;

public class ArmourOfDestinyTowMagicArmour : TowMagicArmour
{
    private const int points = 70;

    public ArmourOfDestinyTowMagicArmour(TowObject owner) : base(owner, TowMagicItemArmorType.ArmourOfDestiny, points, 999)
    {
        //AssignSpecialRule(new ArmourBane1());
        //AssignSpecialRule(new MagicalAttacks());
        //AssignSpecialRule(new MultipleWoundsD3());
    }
}
