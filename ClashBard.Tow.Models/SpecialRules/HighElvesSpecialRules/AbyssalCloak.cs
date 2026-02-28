using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;

public class AbyssalCloak : TowSpecialRule
{
    public AbyssalCloak()
        : base(TowSpecialRuleType.AbyssalCloak,
            "Abyssal Cloak",
            "Any enemy model that targets this model during the Shooting phase suffers a -2 To Hit modifier for firing at long range, rather than the usual -1.")
    {
    }
}
