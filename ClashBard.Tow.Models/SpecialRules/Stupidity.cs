using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Stupidity : TowSpecialRule
{
    private static string ShortDescription = "Ld test needed at Start Of Turn sub-phase, if failed can only move ahead";
    private static string LongDescription = "Unless it is engaged in combat, a unit with this special rule must make a 'Stupidity' test during the Start Of Turn sub-phase of its turn. To make a Stupidity test, test against the unit’s Leadership characteristic. If this test is failed, the unit becomes Stupid. A Stupid unit: Moves during the Compulsory Moves sub-phase. Must move straight ahead, without performing any manoeuvres. Cannot march or declare a charge. A unit or mount that does not have this special rule becomes subject to it when joined or ridden by a character that does (Stupidity is contagious).";

    public Stupidity()
        : base(TowSpecialRuleType.Stupidity,
            ShortDescription,
            LongDescription)
    {

    }
}
