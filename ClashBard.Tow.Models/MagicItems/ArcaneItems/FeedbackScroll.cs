//using ClashBard.Tow.Models.TowTypes;

//namespace ClashBard.Tow.Models.MagicItems.ArcaneItems;

//public class FeedbackScroll : TowArcaneItem
//{
//    private const int points = 35;

//    public FeedbackScroll() : base(TowMagicItemArcaneType.FeedbackScroll, points)
//    {
//        SpecialRules.Add(new FeedbackScrollRules());
//    }
//}


//public class FeedbackScrollRules : TowSpecialRule
//{
//    private static new string ShortDescription = "Instead of wizardly dispel roll 2D6. On each 4+ casting wizard loses a wound.";
//    private static new string LongDescription = "Single use. The bearer may use this scroll instead of making a Wizardly dispel attempt. The spell is cast as normal. Once the spell has been resolved, roll two D6. For each roll of a 4+, the casting Wizard loses a single Wound.";

//    public FeedbackScrollRules()
//        : base(TowSpecialRuleType.FeedbackScrollRules,
//            ShortDescription,
//            LongDescription)
//    {

//    }
//}