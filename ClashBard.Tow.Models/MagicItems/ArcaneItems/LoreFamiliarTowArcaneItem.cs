using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.ArcaneItems;

public class LoreFamiliarTowArcaneItem : TowArcaneItem
{
    private const int points = 30;

    public LoreFamiliarTowArcaneItem(TowObject owner) : base(owner, TowMagicItemArcaneType.LoreFamiliar, points)
    {
        AssignSpecialRule(new LoreFamiliarRules());
    }
}


public class LoreFamiliarRules : TowSpecialRule
{
    private static string ShortDescription = "Pick your spells from the chosen lore";
    private static string LongDescription = "The owner of a Lore Familiar does not randomly generate their spells. Instead, they may choose which spells they know from their chosen lore (including that lore's signature spell).";

    public LoreFamiliarRules()
        : base(TowSpecialRuleType.LoreFamiliarRules,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}
