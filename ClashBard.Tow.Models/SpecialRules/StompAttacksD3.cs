using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class StompAttacksD3 : TowSpecialRule
{
    private static new string ShortDescription = "D3 attacks with umod. St and In=1";
    private static new string LongDescription = "The number of Stomp Attacks caused varies from model to model, and will be shown in brackets after the name of this special rule (shown here as 'X'). Often, this is determined by the roll of a dice. Resolving Stomp Attacks: Stomp Attacks can only be made by a model that is in base contact with the enemy. Stomp Attacks are attacks made in combat that always strike at Initiative 1 (regardless of modifiers), and that hit automatically using the unmodified Strength characteristic of the model.";

    public StompAttacksD3()
        : base(TowSpecialRuleType.StompAttacksD3,
            ShortDescription,
            LongDescription)
    {

    }
}