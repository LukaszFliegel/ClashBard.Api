using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;

public class EnfeeblingCold : TowSpecialRule
{
    public EnfeeblingCold()
        : base(TowSpecialRuleType.EnfeeblingCold,
            "Enfeebling Cold",
            "Whilst in base contact with this model, enemy models suffer a -1 modifier to their Strength characteristic (to a minimum of 1).")
    {
    }
}
