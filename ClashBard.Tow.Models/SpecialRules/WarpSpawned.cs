using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class WarpSpawned : TowSpecialRule
{
    private static string ShortDescription = "Creatures of the supernatural feed upon magic to manifest as physical beings and, as such, are vulnerable to magical attacks.";
    private static string LongDescription = "A model with this special rule cannot make a Regeneration save against a wound caused by a Magical attack. In addition, characters that are not Warp-spawned cannot join units that are, and vice versa.";

    public WarpSpawned()
        : base(TowSpecialRuleType.WarpSpawned,
            ShortDescription,
            LongDescription)
    {

    }
}
