using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.ArcaneItems;

public class FeedbackScroll : TowArcaneItem
{
    private const int points = 60;

    public FeedbackScroll() : base(TowMagicItemArcaneType.FeedbackScroll, points)
    {
        SpecialRules.Add(new FeedbackScrollRules());
    }
}


public class FeedbackScrollRules : TowSpecialRule
{
    private static new string ShortDescription = "xxx";
    private static new string LongDescription = "xxx";

    public FeedbackScrollRules()
        : base(TowSpecialRuleType.FeedbackScrollRules,
            ShortDescription,
            LongDescription)
    {

    }
}
