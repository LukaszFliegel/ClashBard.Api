using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicArmours;

public class ShieldOfTheWarriorTrue : TowMagicArmour
{
    private const int points = 30;

    public ShieldOfTheWarriorTrue() : base(TowMagicItemArmorType.ShieldOfTheWarriorTrue, points, 999)
    {
        //SpecialRules.Add(new ArmourBane1());
        //SpecialRules.Add(new MagicalAttacks());
        //SpecialRules.Add(new MultipleWoundsD3());
    }
}