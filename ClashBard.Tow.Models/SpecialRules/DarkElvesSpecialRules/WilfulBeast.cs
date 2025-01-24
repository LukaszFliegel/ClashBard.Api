using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class WilfulBeast : TowSpecialRule
{
    private static string ShortDescription = "Frenzy (for mount only) until next turn if rider's own unmod. Ld test failed";
    private static string LongDescription = "During the Start of Turn sub-phase of each of their turns, this model must make a Leadership test (using its own unmodified Leadership). If this test is passed, the rider is able to keep control of their mount. If, however, this test is failed, the rider has lost control and their mount becomes subject to the Frenzy special rule until their next Start of Turn sub-phase.";

    public WilfulBeast()
        : base(TowSpecialRuleType.WilfulBeast,
            ShortDescription,
            LongDescription)
    {

    }
}
