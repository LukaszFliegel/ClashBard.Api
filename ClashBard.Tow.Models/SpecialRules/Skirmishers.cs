using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Skirmishers : TowSpecialRule
{
    private static string ShortDescription = "May adopt a Skirmish formation";
    private static string LongDescription = "A unit consisting of models with this special rule may adopt a Skirmish formation.";

    public Skirmishers()
        : base(TowSpecialRuleType.Skirmishers,
            ShortDescription,
            LongDescription,
            printShortDescription: false)
    {

    }
}
