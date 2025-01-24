using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicArmours;

public class GlitteringScalesTowMagicArmour : TowMagicArmour
{
    private const int points = 35;

    public GlitteringScalesTowMagicArmour(TowObject owner) : base(owner, TowMagicItemArmorType.GlitteringScales, points, 999)
    {
        //SpecialRules.Add(new ArmourBane1());
        //SpecialRules.Add(new MagicalAttacks());
        //SpecialRules.Add(new MultipleWoundsD3());
    }
}
