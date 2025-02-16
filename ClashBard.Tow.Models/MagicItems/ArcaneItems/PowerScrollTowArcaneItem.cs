using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.ArcaneItems;

public class PowerScrollTowArcaneItem : TowArcaneItem
{
    private const int points = 20;

    public PowerScrollTowArcaneItem(TowObject owner) : base(owner, TowMagicItemArcaneType.PowerScroll, points)
    {
        AssignSpecialRule(new PowerScrollRules());
    }
}


public class PowerScrollRules : TowSpecialRule
{
    private static string ShortDescription = "xxx";
    private static string LongDescription = "xxx";

    public PowerScrollRules()
        : base(TowSpecialRuleType.PowerScrollRules,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}
