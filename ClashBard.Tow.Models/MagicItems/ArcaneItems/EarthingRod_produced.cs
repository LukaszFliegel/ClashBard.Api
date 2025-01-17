using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.ArcaneItems;

public class EarthingRod : TowArcaneItem
{
    private const int points = 5;

    public EarthingRod() : base(TowMagicItemArcaneType.EarthingRod, points)
    {
        SpecialRules.Add(new EarthingRodRules());
    }
}


public class EarthingRodRules : TowSpecialRule
{
    private static new string ShortDescription = "xxx";
    private static new string LongDescription = "xxx";

    public EarthingRodRules()
        : base(TowSpecialRuleType.EarthingRodRules,
            ShortDescription,
            LongDescription)
    {

    }
}
