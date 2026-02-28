using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;

public class DeflectShots : TowSpecialRule
{
    private static string ShortDescription = "Ward save (5+) vs ranged attacks.";
    private static string LongDescription = "Models with this special rule have a Ward save (5+) against wounds caused by ranged attacks (including Stomp Attacks and all missile weapons).";

    public DeflectShots()
        : base(TowSpecialRuleType.DeflectShots, ShortDescription, LongDescription)
    {
    }
}
