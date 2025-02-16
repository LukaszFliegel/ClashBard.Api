using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.ArcaneItems;

public class WandOfJetTowArcaneItem : TowArcaneItem
{
    private const int points = 45;

    public WandOfJetTowArcaneItem(TowObject owner) : base(owner, TowMagicItemArcaneType.WandOfJet, points)
    {
        AssignSpecialRule(new WandOfJetRules());
    }
}


public class WandOfJetRules : TowSpecialRule
{
    private static string ShortDescription = "xxx";
    private static string LongDescription = "xxx";

    public WandOfJetRules()
        : base(TowSpecialRuleType.WandOfJetRules,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}
