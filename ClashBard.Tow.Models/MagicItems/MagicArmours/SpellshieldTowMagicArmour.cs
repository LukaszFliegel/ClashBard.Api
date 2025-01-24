using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicArmours;

public class SpellshieldTowMagicArmour : TowMagicArmour
{
    private const int points = 25;

    public SpellshieldTowMagicArmour(TowObject owner) : base(owner, TowMagicItemArmorType.Spellshield, points, 999)
    {
        //SpecialRules.Add(new ArmourBane1());
        //SpecialRules.Add(new MagicalAttacks());
        //SpecialRules.Add(new MultipleWoundsD3());
    }
}
