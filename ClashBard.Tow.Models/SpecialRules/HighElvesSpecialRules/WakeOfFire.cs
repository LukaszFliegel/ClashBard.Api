using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;

public class WakeOfFire : TowSpecialRule
{
    private static string ShortDescription = "Wake of Fire";
    private static string LongDescription = "When this model moves, it leaves a 'Wake of Fire' behind it. Place a marker directly behind this model after it has moved. Until the Start of your next turn, this marker is dangerous terrain that causes D6 Strength 4 hits with the Flaming Attacks special rule to any unit that moves through it.";

    public WakeOfFire()
        : base(TowSpecialRuleType.WakeOfFire,
            ShortDescription,
            LongDescription,
            printShortDescription: false)
    {

    }
}
