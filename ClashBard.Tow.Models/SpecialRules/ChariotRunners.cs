using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class ChariotRunners : TowSpecialRule
{
    private static string ShortDescription = "Chariots are often accompanied by light troops that fight at their side, protecting their vulnerable flanks from the enemy.";
    private static string LongDescription = "Friendly models whose troop type is chariot can draw a line of sight over or through models with this special rule and can move through friendly units of Chariot Runners that are in Skirmish formation. If the chariot's move would result in it ending up 'on top' of a Chariot Runner, simply nudge the Chariot Runner aside, by the smallest amount possible, to make space for the chariot. Whilst in Skirmish formation units of Chariot Runners can treat friendly chariots that are within 1\" of one or more of the unit's models as a part of the unit for the purposes of unit coherency.";

    public ChariotRunners()
        : base(TowSpecialRuleType.ChariotRunners,
            ShortDescription,
            LongDescription)
    {

    }
}
