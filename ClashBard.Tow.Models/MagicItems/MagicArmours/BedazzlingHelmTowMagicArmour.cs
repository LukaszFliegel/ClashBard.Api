using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicArmours;

public class BedazzlingHelmTowMagicArmour : TowMagicArmour
{
    private const int points = 60;

    public BedazzlingHelmTowMagicArmour(TowObject owner) : base(owner, TowMagicItemArmorType.BedazzlingHelm, points, 999)
    {
        //AssignSpecialRule(new ArmourBane1());
        //AssignSpecialRule(new MagicalAttacks());
        //AssignSpecialRule(new MultipleWoundsD3());
    }
}
