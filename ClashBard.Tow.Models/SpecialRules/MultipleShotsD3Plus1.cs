using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class MultipleShotsD3Plus1 : TowSpecialRule
{
    private static string ShortDescription = "Multiple Shots (D3+1)";
    private static string LongDescription = "A weapon with this special rule can either fire a single shot as normal, or it can be fired a number of times equal to D3+1. If multiple shots are fired, each roll To Hit suffers an additional -1 To Hit modifier.";

    public MultipleShotsD3Plus1()
        : base(TowSpecialRuleType.MultipleShotsD3Plus1,
            ShortDescription,
            LongDescription,
            printShortDescription: false)
    {

    }
}
