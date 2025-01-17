using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicArmours;

public class ArmourOfSilveredSteel : TowMagicArmour
{
    private const int points = 40;

    public ArmourOfSilveredSteel() : base(TowMagicItemArmorType.ArmourOfSilveredSteel, points, 999)
    {
        //SpecialRules.Add(new ArmourBane1());
        //SpecialRules.Add(new MagicalAttacks());
        //SpecialRules.Add(new MultipleWoundsD3());
    }
}
