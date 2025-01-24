using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class RallyingCry : TowSpecialRule
{
    private static string ShortDescription = "Striking a heroic pose, a bold leader treats their loyal followers to a short but inspiring speech.";
    private static string LongDescription = "During the Command sub-phase of their turn, if they are not engaged in combat, this character may nominate a single fleeing friendly unit that is within their Command range. The nominated unit immediately makes a Rally test. If this test is failed, the unit may attempt to rally again as normal during the Rally sub-phase.";

    public RallyingCry()
        : base(TowSpecialRuleType.RallyingCry,
            ShortDescription,
            LongDescription)
    {

    }
}
