using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Skirmishers : TowSpecialRule
{
    private static new string ShortDescription = "Units of skirmishers move quickly and freely, harassing the enemy's flanks.";
    private static new string LongDescription = "A unit consisting of models with this special rule may adopt a Skirmish formation.";

    public Skirmishers()
        : base(TowSpecialRuleType.Skirmishers,
            ShortDescription,
            LongDescription)
    {

    }
}
