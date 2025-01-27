using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class SwordOfStrikingTowMagicWeapon : TowMagicWeapon
{
    private const int points = 15;

    public SwordOfStrikingTowMagicWeapon(TowObject owner) : base(owner, TowMagicItemWeaponType.SwordOfStriking, points, 0, TowWeaponStrength.S, 0)
    {
        AssignSpecialRule(new MagicalAttacks());
        AssignSpecialRule(new ExtremelyCommon());
        AssignSpecialRule(new SwordOfStrikingRules());
    }
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
