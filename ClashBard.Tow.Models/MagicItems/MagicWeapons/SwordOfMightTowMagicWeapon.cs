using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.Interfaces;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class SwordOfMightTowMagicWeapon : TowMagicWeapon, IExtremelyCommon
{
    private const int points = 20;

    public SwordOfMightTowMagicWeapon(TowObject owner, int numberOfOccurences = 1) : base(owner, TowMagicItemWeaponType.SwordOfMight, points, 0, TowWeaponStrength.Splus1, 1)
    {
        AssignSpecialRule(new MagicalAttacks());
        //AssignSpecialRule(new ExtremelyCommon(numberOfOccurences));

        NumberOfOccurences = numberOfOccurences;
    }

    public int NumberOfOccurences { get; }
}
