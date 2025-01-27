using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicArmours;

public class ShieldOfTheWarriorTrueTowMagicArmour : TowMagicArmour
{
    private const int points = 30;

    public ShieldOfTheWarriorTrueTowMagicArmour(TowObject owner) : base(owner, TowMagicItemArmorType.ShieldOfTheWarriorTrue, points, 999)
    {
        //AssignSpecialRule(new ArmourBane1());
        //AssignSpecialRule(new MagicalAttacks());
        //AssignSpecialRule(new MultipleWoundsD3());
    }
}
