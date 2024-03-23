using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class MartialProwess : TowSpecialRule
{
    private static new string ShortDescription = "Supporting attacks to flank/rear";
    private static new string LongDescription = "A unit with this special rule can make supporting attacks to its flank or rear, as well as to its front.";

    public MartialProwess()
        : base(TowSpecialRuleType.MartialProwess,
            ShortDescription,
            LongDescription)
    {

    }
}
