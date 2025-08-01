using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;

public class IthilmarBarding : TowSpecialRule
{
    public IthilmarBarding()
        : base(TowSpecialRuleType.IthilmarBarding,
            "Ithilmar Barding",
            "Ithilmar is incredibly light, so barding made from it does not slow a mount down. A model with Ithilmar Barding has a 6+ Armour Save that can be combined with other armour as normal. In addition, the model retains its normal Movement value.")
    {
    }
}
