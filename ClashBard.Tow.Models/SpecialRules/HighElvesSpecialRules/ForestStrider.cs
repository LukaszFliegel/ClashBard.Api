using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;

public class ForestStrider : TowSpecialRule
{
    private static string ShortDescription = "No movement penalty in forests";
    private static string LongDescription = "Models with this special rule suffer no movement penalties for moving through forest terrain.";

    public ForestStrider()
        : base(TowSpecialRuleType.ForestStrider,
            ShortDescription,
            LongDescription)
    {

    }
}
