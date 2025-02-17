using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class HatredAllEnemies : TowSpecialRule
{
    private static string ShortDescription = "Reroll to hit in 1st round of combat";
    private static string LongDescription = "A model with this special rule may re-roll any failed rolls To Hit made against enemy models during the first round of combat.";

    public HatredAllEnemies()
        : base(TowSpecialRuleType.HatredAllEnemies,
            ShortDescription,
            LongDescription,
            printShortDescription: false)
    {

    }
}
