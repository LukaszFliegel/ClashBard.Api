using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicArmours;

public class GlitteringScalesTowMagicArmour : TowMagicArmour
{
    private const int points = 35;

    public GlitteringScalesTowMagicArmour(TowObject owner) : base(owner, TowMagicItemArmorType.GlitteringScales, points, 999)
    {
        //AssignSpecialRule(new ArmourBane1());
        //AssignSpecialRule(new MagicalAttacks());
        //AssignSpecialRule(new MultipleWoundsD3());
    }
}
