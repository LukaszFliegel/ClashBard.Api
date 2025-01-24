using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.ArcaneItems;

public class ScrollOfTransmogrificationTowArcaneItem : TowArcaneItem
{
    private const int points = 50;

    public ScrollOfTransmogrificationTowArcaneItem(TowObject owner) : base(owner, TowMagicItemArcaneType.ScrollOfTransmogrification, points)
    {
        SpecialRules.Add(new ScrollOfTransmogrificationRules());
    }
}


public class ScrollOfTransmogrificationRules : TowSpecialRule
{
    private static string ShortDescription = "xxx";
    private static string LongDescription = "xxx";

    public ScrollOfTransmogrificationRules()
        : base(TowSpecialRuleType.ScrollOfTransmogrificationRules,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}
