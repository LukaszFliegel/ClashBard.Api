using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Loner : TowSpecialRule
{
    private static string ShortDescription = "Some warriors do not mix well with others, preferring to keep their distance.";
    private static string LongDescription = "A character with this special rule cannot be your General and cannot join a unit without this special rule. A unit with this special rule cannot be joined by a character without this special rule.";

    public Loner()
        : base(TowSpecialRuleType.Loner,
            ShortDescription,
            LongDescription)
    {

    }
}
