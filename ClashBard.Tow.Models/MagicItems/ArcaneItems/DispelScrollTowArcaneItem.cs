using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.ArcaneItems;

public class DispelScrollTowArcaneItem : TowArcaneItem
{
    private const int points = 20;

    public DispelScrollTowArcaneItem(TowObject owner) : base(owner, TowMagicItemArcaneType.DispelScroll, points)
    {
        AssignSpecialRule(new DispelScrollRules());
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
