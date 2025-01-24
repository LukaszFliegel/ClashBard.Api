using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Stubborn : TowSpecialRule
{
    private static string ShortDescription = "FBIGO instead of first break test";
    private static string LongDescription = "The first time this unit is required to make a Break test it may choose not to and will automatically Falling Back in Good Order instead, even if the Unit Strength of the winning side is more than twice that of the losing side. A unit that is not Stubborn does not become Stubborn when joined by a character that is. A Stubborn character cannot use this special rule whilst part of a unit that is not Stubborn.";

    public Stubborn()
        : base(TowSpecialRuleType.Stubborn,
            ShortDescription,
            LongDescription)
    {

    }
}
