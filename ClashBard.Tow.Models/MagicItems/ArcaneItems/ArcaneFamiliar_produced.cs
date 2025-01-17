using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.ArcaneItems;

public class ArcaneFamiliar : TowArcaneItem
{
    private const int points = 15;

    public ArcaneFamiliar() : base(TowMagicItemArcaneType.ArcaneFamiliar, points)
    {
        SpecialRules.Add(new ArcaneFamiliarRules());
    }
}


public class ArcaneFamiliarRules : TowSpecialRule
{
    private static new string ShortDescription = "xxx";
    private static new string LongDescription = "xxx";

    public ArcaneFamiliarRules()
        : base(TowSpecialRuleType.ArcaneFamiliarRules,
            ShortDescription,
            LongDescription)
    {

    }
}
