using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class MagicResistance3 : TowSpecialRule
{
    private static new string ShortDescription = "Some creatures are naturally resistant to magic, whilst others bear charms or fetishes intended to ward off its effects.";
    private static new string LongDescription = "The Casting roll of any enemy spell (including Bound spells) that targets a unit that includes one or more models with this special rule suffers a modifier, as shown in brackets after the name of this special rule (shown here as '-3'). Note that this special rule is not cumulative. If two or more models in a unit have this special rule, use the highest modifier.";

    public MagicResistance3()
        : base(TowSpecialRuleType.MagicResistance3,
            ShortDescription,
            LongDescription)
    {

    }
}
