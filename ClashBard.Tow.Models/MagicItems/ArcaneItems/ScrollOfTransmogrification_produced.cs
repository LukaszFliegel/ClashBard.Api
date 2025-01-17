using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.ArcaneItems;

public class ScrollOfTransmogrification : TowArcaneItem
{
    private const int points = 50;

    public ScrollOfTransmogrification() : base(TowMagicItemArcaneType.ScrollOfTransmogrification, points)
    {
        SpecialRules.Add(new ScrollOfTransmogrificationRules());
    }
}


public class ScrollOfTransmogrificationRules : TowSpecialRule
{
    private static new string ShortDescription = "xxx";
    private static new string LongDescription = "xxx";

    public ScrollOfTransmogrificationRules()
        : base(TowSpecialRuleType.ScrollOfTransmogrificationRules,
            ShortDescription,
            LongDescription)
    {

    }
}
