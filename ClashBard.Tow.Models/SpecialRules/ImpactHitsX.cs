using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class ImpactHitsX : TowSpecialRule
{
    private static string ShortDescription = "The impact of a charge can itself cause severe casualties amongst the foe.";
    private static string LongDescription = "The number of Impact Hits caused varies from model to model, and will be shown in brackets after the name of this special rule (shown here as 'X'). Often, this is determined by the roll of a dice. Resolving Impact Hits: Impact Hits can only be made by a charging model that moved 3\" or more and that is in base contact with the enemy. Impact hits are attacks made in combat that always strike at Initiative 10 (regardless of modifiers), and that hit automatically using the unmodified Strength characteristic of the model.";

    public ImpactHitsX()
        : base(TowSpecialRuleType.ImpactHitsX,
            ShortDescription,
            LongDescription,
            printShortDescription: false)
    {

    }
}
