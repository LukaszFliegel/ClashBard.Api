using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class MagicResistance2 : TowSpecialRule
{
    private static string ShortDescription = "Some creatures are naturally resistant to magic, whilst others bear charms or fetishes intended to ward off its effects.";
    private static string LongDescription = "The Casting roll of any enemy spell (including Bound spells) that targets a unit that includes one or more models with this special rule suffers a modifier, as shown in brackets after the name of this special rule (shown here as '-2'). Note that this special rule is not cumulative. If two or more models in a unit have this special rule, use the highest modifier.";

    public MagicResistance2()
        : base(TowSpecialRuleType.MagicResistance2,
            ShortDescription,
            LongDescription)
    {

    }
}
