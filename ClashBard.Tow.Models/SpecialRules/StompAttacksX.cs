using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class StompAttacksX : TowSpecialRule
{
    private static new string ShortDescription = "Some creatures are so massive that their sheer bulk is a threat all of its own.";
    private static new string LongDescription = "The number of Stomp Attacks caused varies from model to model, and will be shown in brackets after the name of this special rule (shown here as 'X'). Often, this is determined by the roll of a dice. Resolving Stomp Attacks: Stomp Attacks can only be made by a model that is in base contact with the enemy. Stomp Attacks are attacks made in combat that always strike at Initiative 1 (regardless of modifiers), and that hit automatically using the unmodified Strength characteristic of the model.";

    public StompAttacksX()
        : base(TowSpecialRuleType.StompAttacksX,
            ShortDescription,
            LongDescription)
    {

    }
}
