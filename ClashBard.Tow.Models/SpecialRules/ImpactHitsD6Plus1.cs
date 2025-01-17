using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class ImpactHitsD6Plus1 : TowSpecialRule
{
    private static new string ShortDescription = "D6+1 impact hits";
    private static new string LongDescription = "The number of Impact Hits caused varies from model to model, and will be shown in brackets after the name of this special rule (shown here as 'X'). Often, this is determined by the roll of a dice. Resolving Impact Hits: Impact Hits can only be made by a charging model that moved 3\" or more and that is in base contact with the enemy. Impact hits are attacks made in combat that always strike at Initiative 10 (regardless of modifiers), and that hit automatically using the unmodified Strength characteristic of the model.";

    public ImpactHitsD6Plus1()
        : base(TowSpecialRuleType.ImpactHitsD6Plus1,
            ShortDescription,
            LongDescription)
    {

    }
}
