using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class ArmourOfDestiny : TowMagicArmour
{
    private const int points = 65;

    public ArmourOfDestiny() : base(TowMagicItemArmorType.AmourOfDestiny, points, 5, 4)
    {
        SpecialRules.Add(new ArmourBane1());
        SpecialRules.Add(new MagicalAttacks());
        SpecialRules.Add(new MultipleWoundsD3());
    }
}
