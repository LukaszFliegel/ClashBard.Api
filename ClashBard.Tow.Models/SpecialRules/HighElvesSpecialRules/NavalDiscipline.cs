using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;

public class NavalDiscipline : TowSpecialRule
{
    private static string ShortDescription = "Naval Discipline";
    private static string LongDescription = "Special rule for naval units.";

    public NavalDiscipline() : base(TowSpecialRuleType.NavalDiscipline, ShortDescription, LongDescription)
    {
    }
}
