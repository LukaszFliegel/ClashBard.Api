using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Ambushers : TowSpecialRule
{
    private static new string ShortDescription = "A unit with this special rule may be held in reserve rather than be deployed at the start of the game.";
    private static new string LongDescription = "From the beginning of round two onwards, roll a D6 during each of your Start of Turn sub-phases for each unit of Ambushers in your army that is held in reserve. On a roll of 1-3, the unit is delayed until your next turn at least. On a roll of 4+, the unit arrives, entering the battle as reinforcements during the Compulsory Moves sub-phase. The unit may be placed on any edge of the battlefield, chosen by its controlling player, but cannot be placed within 8\" of an enemy model. If any Ambushers are still held in reserve by the start of round five, they arrive automatically.";

    public Ambushers()
        : base(TowSpecialRuleType.Ambushers,
            ShortDescription,
            LongDescription)
    {

    }
}
