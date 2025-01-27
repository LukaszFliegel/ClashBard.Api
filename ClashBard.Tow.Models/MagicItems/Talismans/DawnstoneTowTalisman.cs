using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.Talismans;

public class DawnstoneTowTalisman : TowTalisman
{
    private const int points = 35;

    public DawnstoneTowTalisman(TowObject owner) : base(owner, TowMagicItemTalismanType.Dawnstone, points)
    {
        AssignSpecialRule(new DawnstoneRules());
    }
}


public class DawnstoneRules : TowSpecialRule
{
    private static string ShortDescription = "xxx";
    private static string LongDescription = "xxx";

    public DawnstoneRules()
        : base(TowSpecialRuleType.DawnstoneRules,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}
