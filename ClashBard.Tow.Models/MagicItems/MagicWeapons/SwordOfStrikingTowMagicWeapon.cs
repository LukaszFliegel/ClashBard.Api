using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.Interfaces;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class SwordOfStrikingTowMagicWeapon : TowMagicWeapon, IExtremelyCommon
{
    private const int points = 15;

    public SwordOfStrikingTowMagicWeapon(TowObject owner, int numberOfOccurences = 1) : base(owner, TowMagicItemWeaponType.SwordOfStriking, points, 0, TowWeaponStrength.S, 0)
    {
        AssignSpecialRule(new MagicalAttacks());
        //AssignSpecialRule(new ExtremelyCommon(numberOfOccurences));
        AssignSpecialRule(new SwordOfStrikingRules());

        NumberOfOccurences = numberOfOccurences;
    }

    public int NumberOfOccurences { get; }
}

public class SwordOfStrikingRules : TowSpecialRule
{
    private static string ShortDescription = "+1 to hit in combat";
    private static string LongDescription = "During the Combat phase, the wielder of the Sword of Striking has a +1 modifier to their rolls To Hit.";

    public SwordOfStrikingRules()
        : base(TowSpecialRuleType.SwordOfStrikingRules,
            ShortDescription,
            LongDescription)
    {

    }
}
