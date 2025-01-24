using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicArmours;

public class ArmourOfDestinyTowMagicArmour : TowMagicArmour
{
    private const int points = 70;

    public ArmourOfDestinyTowMagicArmour(TowObject owner) : base(owner, TowMagicItemArmorType.ArmourOfDestiny, points, 999)
    {
        //SpecialRules.Add(new ArmourBane1());
        //SpecialRules.Add(new MagicalAttacks());
        //SpecialRules.Add(new MultipleWoundsD3());
    }
}
