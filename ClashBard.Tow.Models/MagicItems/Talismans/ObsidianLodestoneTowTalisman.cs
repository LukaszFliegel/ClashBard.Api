using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.Talismans;

public class ObsidianLodestoneTowTalisman : TowTalisman
{
    private const int points = 20;

    public ObsidianLodestoneTowTalisman() : base(TowMagicItemTalismanType.ObsidianLodestone, points)
    {
        SpecialRules.Add(new ObsidianLodestoneRules());
    }
}


public class ObsidianLodestoneRules : TowSpecialRule
{
    private static new string ShortDescription = "xxx";
    private static new string LongDescription = "xxx";

    public ObsidianLodestoneRules()
        : base(TowSpecialRuleType.ObsidianLodestoneRules,
            ShortDescription,
            LongDescription)
    {

    }
}
