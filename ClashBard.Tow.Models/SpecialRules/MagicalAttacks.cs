using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class MagicalAttacks : TowSpecialRule
{
    private static string ShortDescription = "Magical attacks";
    private static string LongDescription = "Any attack made or hit caused by a model with this special rule, or made using a weapon with this special rule, is a 'Magical' attack. Note that all spells are considered to have this special rule, as are any hits caused by magic items.";

    public MagicalAttacks()
        : base(TowSpecialRuleType.MagicalAttacks,
            ShortDescription,
            LongDescription,
            printShortDescription: false)
    {

    }
}
