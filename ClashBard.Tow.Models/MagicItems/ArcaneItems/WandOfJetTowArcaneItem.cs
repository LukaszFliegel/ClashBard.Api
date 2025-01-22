using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.ArcaneItems;

public class WandOfJetTowArcaneItem : TowArcaneItem
{
    private const int points = 45;

    public WandOfJetTowArcaneItem() : base(TowMagicItemArcaneType.WandOfJet, points)
    {
        SpecialRules.Add(new WandOfJetRules());
    }
}


public class WandOfJetRules : TowSpecialRule
{
    private static new string ShortDescription = "xxx";
    private static new string LongDescription = "xxx";

    public WandOfJetRules()
        : base(TowSpecialRuleType.WandOfJetRules,
            ShortDescription,
            LongDescription)
    {

    }
}
