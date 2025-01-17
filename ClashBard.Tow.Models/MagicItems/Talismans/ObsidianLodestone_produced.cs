using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.Talismans;

public class ObsidianLodestone : TowTalisman
{
    private const int points = 20;

    public ObsidianLodestone() : base(TowMagicItemTalismanType.ObsidianLodestone, points)
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
