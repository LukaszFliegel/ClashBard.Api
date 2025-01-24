using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.ArcaneItems;

public class ArcaneFamiliarTowArcaneItem : TowArcaneItem
{
    private const int points = 15;

    public ArcaneFamiliarTowArcaneItem(TowObject owner) : base(owner, TowMagicItemArcaneType.ArcaneFamiliar, points)
    {
        SpecialRules.Add(new ArcaneFamiliarRules());
    }
}


public class ArcaneFamiliarRules : TowSpecialRule
{
    private static string ShortDescription = "xxx";
    private static string LongDescription = "xxx";

    public ArcaneFamiliarRules()
        : base(TowSpecialRuleType.ArcaneFamiliarRules,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}
