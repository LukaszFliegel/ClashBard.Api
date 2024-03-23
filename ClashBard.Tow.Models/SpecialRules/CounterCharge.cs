using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class CounterCharge : TowSpecialRule
{
    private static new string ShortDescription = "Particularly bold and brash warriors view offence as the best form of defence.";
    private static new string LongDescription = "This special rule can only be used by units that consist entirely of models with this special rule. When a unit with this special rule is charged in its front arc by an enemy unit whose troop type is cavalry, chariot or monster, it may declare a 'Counter Charge' charge reaction: Counter Charge. The unit surges forward to meet the enemy charge. Measure the distance between the two units. If the distance is less than the Movement characteristic of the charging unit, the charged unit has not enough time to meet the enemy charge and must either Hold or Flee instead. Otherwise, pivot the unit about its centre so that it is facing directly towards the centre of the charging enemy unit. After pivoting, the unit moves D3+1\" directly towards the enemy unit. Both units are considered to have charged during this turn. Fleeing units and units already engaged in combat when charged cannot Counter Charge. A unit can only Counter Charge in response to one charge per turn, even if charged by multiple units. Once all charges have been declared, the inactive player can choose which charging unit to Counter Charge. The unit will then Hold against the other charging units.";

    public CounterCharge()
        : base(TowSpecialRuleType.CounterCharge,
            ShortDescription,
            LongDescription)
    {

    }
}
