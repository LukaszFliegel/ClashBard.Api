using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class PoisonedAttacks : TowSpecialRule
{
    private static string ShortDescription = "Auto wound when roll 6 on To Hit";
    private static string LongDescription = "If a model with Poisoned Attacks rolls a natural 6 when making a roll To Hit, that hit will wound automatically. Unless otherwise stated, a model with this special rule may use it when making both shooting and combat attacks. Any spells cast by the model are unaffected, as are any attacks made with magic weapons. Note that if an attack needs a To Hit roll of 7+, or hits automatically, this special rule cannot be used.";

    public PoisonedAttacks(string? shortDescriptionAppendix = null)
        : base(TowSpecialRuleType.PoisonedAttacks,
            ShortDescription,
            LongDescription,
            shortDescriptionAppendix: shortDescriptionAppendix)
    {

    }
}
