using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class MagicalAttacks : TowSpecialRule
{
    private static new string ShortDescription = "The Warhammer world is a deeply magical place. Consequently, magical weapons are quite commonplace.";
    private static new string LongDescription = "Any attack made or hit caused by a model with this special rule, or made using a weapon with this special rule, is a 'Magical' attack. Note that all spells are considered to have this special rule, as are any hits caused by magic items.";

    public MagicalAttacks()
        : base(TowSpecialRuleType.MagicalAttacks,
            ShortDescription,
            LongDescription)
    {

    }
}
