using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Howdah : TowSpecialRule
{
    private static string ShortDescription = "A howdah is an armoured platform built atop a mighty behemoth. From here, a crew of warriors rain missiles upon the enemy.";
    private static string LongDescription = "To represent its howdah and crew, a behemoth with this special rule has a split profile and follows both the Split Profile (Chariots) and Firing Platform. In all other respects, this model is a behemoth.";

    public Howdah()
        : base(TowSpecialRuleType.Howdah,
            ShortDescription,
            LongDescription)
    {

    }
}
