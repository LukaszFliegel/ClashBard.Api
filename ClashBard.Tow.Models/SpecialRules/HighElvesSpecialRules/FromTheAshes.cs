using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;

public class FromTheAshes : TowSpecialRule
{
    private static string ShortDescription = "Reborn at end of turn if slain.";
    private static string LongDescription = "If a model with this special rule is removed as a casualty, it is not removed from the table. Instead, place a counter where the model was. At the end of the following player turn, the model is reborn with D3 Wounds remaining and may act normally from that point on.";

    public FromTheAshes()
        : base(TowSpecialRuleType.FromTheAshes, ShortDescription, LongDescription)
    {
    }
}
