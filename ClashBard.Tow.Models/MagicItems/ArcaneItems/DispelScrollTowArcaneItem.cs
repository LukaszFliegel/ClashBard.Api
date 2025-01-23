using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.ArcaneItems;

public class DispelScrollTowArcaneItem : TowArcaneItem
{
    private const int points = 20;

    public DispelScrollTowArcaneItem() : base(TowMagicItemArcaneType.DispelScroll, points)
    {
        SpecialRules.Add(new DispelScrollRules());
    }
}


public class DispelScrollRules : TowSpecialRule
{
    private static string ShortDescription = "xxx";
    private static string LongDescription = "xxx";

    public DispelScrollRules()
        : base(TowSpecialRuleType.DispelScrollRules,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}
