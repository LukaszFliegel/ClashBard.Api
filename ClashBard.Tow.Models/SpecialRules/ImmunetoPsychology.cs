using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class ImmuneToPsychology : TowSpecialRule
{
    private static string ShortDescription = "Auto pass panic, fear, terror, no flee as charge reaction";
    private static string LongDescription = "If the majority of the models in a unit are Immune to Psychology, the unit automatically passes any Fear, Panic or Terror tests it is required to make. However, if the majority of the models in a unit have this special rule, the unit cannot choose to Flee as a charge reaction. Note that this special rule does not make a unit immune to any test made against Leadership not stated here.";

    public ImmuneToPsychology()
        : base(TowSpecialRuleType.ImmunetoPsychology,
            ShortDescription,
            LongDescription,
            printShortDescription: false)
    {

    }
}
