using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.ArcaneItems;

public class FeedbackScrollTowArcaneItem : TowArcaneItem
{
    private const int points = 60;

    public FeedbackScrollTowArcaneItem(TowObject owner) : base(owner, TowMagicItemArcaneType.FeedbackScroll, points)
    {
        SpecialRules.Add(new FeedbackScrollRules());
    }
}


public class FeedbackScrollRules : TowSpecialRule
{
    private static string ShortDescription = "xxx";
    private static string LongDescription = "xxx";

    public FeedbackScrollRules()
        : base(TowSpecialRuleType.FeedbackScrollRules,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}
