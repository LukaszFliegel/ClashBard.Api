using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

public class SwordOfStriking : TowMagicWeapon
{
    private const int points = 15;

    public SwordOfStriking() : base(TowMagicItemWeaponType.SwordOfStriking, points, 0, TowWeaponStrength.S, 0)
    {
        SpecialRules.Add(new MagicalAttacks());
        SpecialRules.Add(new ExtremelyCommon());
        SpecialRules.Add(new SwordOfStrikingRules());
    }
}

public class SwordOfStrikingRules : TowSpecialRule
{
    private static new string ShortDescription = "+1 to hit in combat";
    private static new string LongDescription = "During the Combat phase, the wielder of the Sword of Striking has a +1 modifier to their rolls To Hit.";

    public SwordOfStrikingRules()
        : base(TowSpecialRuleType.SwordOfStrikingRules,
            ShortDescription,
            LongDescription)
    {

    }
}
