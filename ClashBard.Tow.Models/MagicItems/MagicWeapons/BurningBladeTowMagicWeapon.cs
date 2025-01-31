using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.Interfaces;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class BurningBladeTowMagicWeapon : TowMagicWeapon, IExtremelyCommon
{
    private const int points = 5;

    public BurningBladeTowMagicWeapon(TowObject owner, int numberOfOccurences = 1) : base(owner, TowMagicItemWeaponType.BurningBlade, points, 0, TowWeaponStrength.S, 0)
    {
        AssignSpecialRule(new FlamingAttacks());
        AssignSpecialRule(new MagicalAttacks());
        //AssignSpecialRule(new ExtremelyCommon(numberOfOccurences));

        NumberOfOccurences = numberOfOccurences;
    }

    public int NumberOfOccurences { get; }
}
