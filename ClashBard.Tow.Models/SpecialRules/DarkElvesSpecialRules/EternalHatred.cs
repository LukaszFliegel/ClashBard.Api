using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class EternalHatred : TowSpecialRule
{
    private static new string ShortDescription = "vs HE hatred every round of combat";
    private static new string LongDescription = "Against High Elves, this model’s Hatred applies in every round of close combat, not just the first. Note that this special rule does not apply to this model’s mount (should it have one).";

    public EternalHatred()
        : base(TowSpecialRuleType.EternalHatred,
            ShortDescription,
            LongDescription)
    {

    }
}
