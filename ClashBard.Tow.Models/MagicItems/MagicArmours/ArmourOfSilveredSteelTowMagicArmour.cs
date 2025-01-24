using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicArmours;

public class ArmourOfSilveredSteelTowMagicArmour : TowMagicArmour
{
    private const int points = 40;

    public ArmourOfSilveredSteelTowMagicArmour(TowObject owner) : base(owner, TowMagicItemArmorType.ArmourOfSilveredSteel, points, 999)
    {
        //SpecialRules.Add(new ArmourBane1());
        //SpecialRules.Add(new MagicalAttacks());
        //SpecialRules.Add(new MultipleWoundsD3());
    }
}
