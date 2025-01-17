using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.ArcaneItems;

public class DispelScroll : TowArcaneItem
{
    private const int points = 20;

    public DispelScroll() : base(TowMagicItemArcaneType.DispelScroll, points)
    {
        SpecialRules.Add(new DispelScrollRules());
    }
}


public class DispelScrollRules : TowSpecialRule
{
    private static new string ShortDescription = "xxx";
    private static new string LongDescription = "xxx";

    public DispelScrollRules()
        : base(TowSpecialRuleType.DispelScrollRules,
            ShortDescription,
            LongDescription)
    {

    }
}
