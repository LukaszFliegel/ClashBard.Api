using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Fear : TowSpecialRule
{
    private static string ShortDescription = "Ld test needed when charge target (if > US). In combat Ld test pass needed or -1 to hit (if > US)";
    private static string LongDescription = "Models with this special rule cause Fear: If a unit wishes to declare a charge against an enemy unit that both causes Fear and has a higher Unit Strength, it must first make a Leadership test. If this test is failed, the unit cannot charge. It does not move and is considered to have made a failed charge. If this test is passed, the unit can charge as normal. If a unit is engaged with an enemy unit that both causes Fear and has a higher Unit Strength when its combat is chosen during any Choose & Fight Combat sub-phase, it must make a Leadership test. If this test is failed, any models in the unit that direct their attacks against the Fear-causing enemy suffer a -1 modifier to their rolls To Hit. A unit only needs to make one Fear test per turn. Models that cause Fear are immune to Fear. A unit that does not cause Fear does not become immune to Fear when joined by a character that does.";

    public Fear()
        : base(TowSpecialRuleType.Fear,
            ShortDescription,
            LongDescription,
            printShortDescription: false)
    {

    }
}
