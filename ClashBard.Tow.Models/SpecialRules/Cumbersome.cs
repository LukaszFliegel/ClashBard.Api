using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Cumbersome : TowSpecialRule
{
    private static string ShortDescription = "Some missile weapons are too cumbersome to be raised and aimed at a charging foe.";
    private static string LongDescription = "Weapons with this special rule cannot be used when making a Stand & Shoot charge reaction.";

    public Cumbersome()
        : base(TowSpecialRuleType.Cumbersome,
            ShortDescription,
            LongDescription)
    {

    }
}
