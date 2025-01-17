using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.ArcaneItems;

public class PowerScroll : TowArcaneItem
{
    private const int points = 20;

    public PowerScroll() : base(TowMagicItemArcaneType.PowerScroll, points)
    {
        SpecialRules.Add(new PowerScrollRules());
    }
}


public class PowerScrollRules : TowSpecialRule
{
    private static new string ShortDescription = "xxx";
    private static new string LongDescription = "xxx";

    public PowerScrollRules()
        : base(TowSpecialRuleType.PowerScrollRules,
            ShortDescription,
            LongDescription)
    {

    }
}
