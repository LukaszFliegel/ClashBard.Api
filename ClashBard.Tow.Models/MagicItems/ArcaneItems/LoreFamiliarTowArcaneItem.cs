using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.ArcaneItems;

public class LoreFamiliarTowArcaneItem : TowArcaneItem
{
    private const int points = 30;

    public LoreFamiliarTowArcaneItem() : base(TowMagicItemArcaneType.LoreFamiliar, points)
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
