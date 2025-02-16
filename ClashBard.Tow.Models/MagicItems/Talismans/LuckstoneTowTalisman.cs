using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.Talismans;

public class LuckstoneTowTalisman : TowTalisman
{
    private const int points = 15;

    public LuckstoneTowTalisman(TowObject owner) : base(owner, TowMagicItemTalismanType.Luckstone, points)
    {
        AssignSpecialRule(new LuckstoneRules());
    }
}


public class LuckstoneRules : TowSpecialRule
{
    private static string ShortDescription = "xxx";
    private static string LongDescription = "xxx";

    public LuckstoneRules()
        : base(TowSpecialRuleType.LuckstoneRules,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}
