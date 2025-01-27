using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.ArcaneItems;

public class EarthingRodTowArcaneItem : TowArcaneItem
{
    private const int points = 5;

    public EarthingRodTowArcaneItem(TowObject owner) : base(owner, TowMagicItemArcaneType.EarthingRod, points)
    {
        AssignSpecialRule(new EarthingRodRules());
    }
}


public class EarthingRodRules : TowSpecialRule
{
    private static string ShortDescription = "xxx";
    private static string LongDescription = "xxx";

    public EarthingRodRules()
        : base(TowSpecialRuleType.EarthingRodRules,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}
