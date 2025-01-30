using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Frenzy : TowSpecialRule
{
    private static string ShortDescription = "+1 At, pass Fear & Terror, must declare charge, cannot Flee from charge nor Restraint, Frenzy is gone after lost fight";
    private static string LongDescription = "A Frenzied model has a +1 modifier to its Attacks characteristic. This modifier does not apply to the model's mount (in the case of a cavalry model), to the beasts that draw it (in the case of a chariot), or to its rider (in the case of a monster). In addition: If the majority of the models in a unit are Frenzied, the unit automatically passes any Fear, Panic or Terror tests it is required to make. If a unit that includes one or more Frenzied models is able to declare a charge during the Declare Charges & Charge Reactions sub-phase of its turn, it must do so. If the majority of the models in a unit are Frenzied, it cannot choose to Flee as a charge reaction, nor can it ever choose to make a Restraint test. Losing Frenzy: Unlike other special rules, Frenzy can be lost during a game. Any model that loses a round of combat will immediately lose this special rule.";

    public Frenzy()
        : base(TowSpecialRuleType.Frenzy,
            ShortDescription,
            LongDescription)
    {

    }
}
