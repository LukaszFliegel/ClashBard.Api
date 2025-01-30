using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class Witchbrew : TowSpecialRule
{
    private static string ShortDescription = "Cannot lose Frenzy";
    private static string LongDescription = "This character, their mount and any unit they have joined cannot lose the Frenzy special rule.";

    public Witchbrew()
        : base(TowSpecialRuleType.Witchbrew,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}
