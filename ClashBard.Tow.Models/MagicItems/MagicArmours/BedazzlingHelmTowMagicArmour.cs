using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicArmours;

public class BedazzlingHelmTowMagicArmour : TowMagicArmour
{
    private const int points = 60;

    public BedazzlingHelmTowMagicArmour(TowObject owner) : base(owner, TowMagicItemArmorType.BedazzlingHelm, points, 999)
    {
        //SpecialRules.Add(new ArmourBane1());
        //SpecialRules.Add(new MagicalAttacks());
        //SpecialRules.Add(new MultipleWoundsD3());
    }
}
