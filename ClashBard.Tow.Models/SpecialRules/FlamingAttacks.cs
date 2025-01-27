using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class FlamingAttacks : TowSpecialRule
{
    private static string ShortDescription = "Flaming attacks";
    private static string LongDescription = "Any attack made or hits caused by a model with this special rule, or made using a weapon or spell with this special rule, is a 'Flaming' attack. In addition, a model with this special rule causes Fear in models whose troop type is war beasts or swarms. Unless otherwise stated, a model with this special rule makes Flaming attacks both when shooting and in combat (though any spells cast by the model are unaffected, as are any attacks made with magic weapons they might be wielding).";

    public FlamingAttacks()
        : base(TowSpecialRuleType.FlamingAttacks,
            ShortDescription,
            LongDescription,
            printShortDescription: false)
    {

    }
}
