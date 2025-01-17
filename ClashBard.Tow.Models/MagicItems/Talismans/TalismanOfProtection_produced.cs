using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.Talismans;

public class TalismanOfProtection : TowTalisman
{
    private const int points = 30;

    public TalismanOfProtection() : base(TowMagicItemTalismanType.TalismanOfProtection, points)
    {
        SpecialRules.Add(new TalismanOfProtectionRules());
    }
}


public class TalismanOfProtectionRules : TowSpecialRule
{
    private static new string ShortDescription = "xxx";
    private static new string LongDescription = "xxx";

    public TalismanOfProtectionRules()
        : base(TowSpecialRuleType.TalismanOfProtectionRules,
            ShortDescription,
            LongDescription)
    {

    }
}
