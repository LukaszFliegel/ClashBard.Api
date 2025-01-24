using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class DanceOfDeath : TowSpecialRule
{
    private static string ShortDescription = "-1 rank bonus for charged enemy unit";
    private static string LongDescription = "If this unit makes a successful charge move (i.e., if the unit makes contact with the charge target), the charge target suffers a -1 modifier to its Maximum Rank Bonus until the end of the Combat phase of that turn.";

    public DanceOfDeath()
        : base(TowSpecialRuleType.DanceOfDeath,
            ShortDescription,
            LongDescription)
    {

    }
}
