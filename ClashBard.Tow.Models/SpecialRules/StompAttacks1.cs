using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class StompAttacks1 : TowSpecialRule
{
    private static string ShortDescription = "1 attack with unmod. St and In=1";
    private static string LongDescription = "Stomp Attacks can only be made by a model that is in base contact with the enemy. Stomp Attacks are attacks made in combat that always strike at Initiative 1 (regardless of modifiers), and that hit automatically using the unmodified Strength characteristic of the model.";

    public StompAttacks1()
        : base(TowSpecialRuleType.StompAttacks1,
            ShortDescription,
            LongDescription,
            printShortDescription: false)
    {
    }
}
