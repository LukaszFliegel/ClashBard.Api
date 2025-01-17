using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.Talismans;

public class Dawnstone : TowTalisman
{
    private const int points = 35;

    public Dawnstone() : base(TowMagicItemTalismanType.Dawnstone, points)
    {
        SpecialRules.Add(new DawnstoneRules());
    }
}


public class DawnstoneRules : TowSpecialRule
{
    private static new string ShortDescription = "xxx";
    private static new string LongDescription = "xxx";

    public DawnstoneRules()
        : base(TowSpecialRuleType.DawnstoneRules,
            ShortDescription,
            LongDescription)
    {

    }
}
