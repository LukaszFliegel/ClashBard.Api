using ClashBard.Tow.Models;
using ClashBard.Tow.Models.SpecialRules.Interfaces;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Scouts : TowSpecialRule, IScouts
{
    private static string ShortDescription = "May be deploy after all non-scouts are deployed anywhere 12\" from enemy";
    private static string LongDescription = "Units with this special rule may be deployed after all other units from both armies. They can be deployed anywhere on the battlefield that is more than 12\" away from an enemy model. If deployed in this way, Scouts cannot declare a charge during their first turn. If both armies contain Scouts, a roll-off should determine which player deploys Scouts first. The players then alternate deploying their scouting units one at a time, starting with the player who won the roll-off.";

    public Scouts()
        : base(TowSpecialRuleType.Scouts,
            ShortDescription,
            LongDescription,
            printShortDescription: false)
    {

    }
}
