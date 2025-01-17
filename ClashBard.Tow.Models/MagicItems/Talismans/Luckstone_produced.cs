using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.Talismans;

public class Luckstone : TowTalisman
{
    private const int points = 15;

    public Luckstone() : base(TowMagicItemTalismanType.Luckstone, points)
    {
        SpecialRules.Add(new LuckstoneRules());
    }
}


public class LuckstoneRules : TowSpecialRule
{
    private static new string ShortDescription = "xxx";
    private static new string LongDescription = "xxx";

    public LuckstoneRules()
        : base(TowSpecialRuleType.LuckstoneRules,
            ShortDescription,
            LongDescription)
    {

    }
}
