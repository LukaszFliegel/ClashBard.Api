using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.ArcaneItems;

public class LoreFamiliar : TowArcaneItem
{
    private const int points = 30;

    public LoreFamiliar() : base(TowMagicItemArcaneType.LoreFamiliar, points)
    {
        SpecialRules.Add(new LoreFamiliarRules());
    }
}


public class LoreFamiliarRules : TowSpecialRule
{
    private static new string ShortDescription = "xxx";
    private static new string LongDescription = "xxx";

    public LoreFamiliarRules()
        : base(TowSpecialRuleType.LoreFamiliarRules,
            ShortDescription,
            LongDescription)
    {

    }
}
