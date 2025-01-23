using ClashBard.Tow.Models.Armors.Interfaces;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.Talismans;

public class TalismanOfProtectionTowTalisman : TowTalisman
{
    private const int points = 30;

    public TalismanOfProtectionTowTalisman() : base(TowMagicItemTalismanType.TalismanOfProtection, points)
    {
        SpecialRules.Add(new TalismanOfProtectionRules());
        //AssignSpecialRule(new TalismanOfProtectionRules());
    }
}


public class TalismanOfProtectionRules : TowSpecialRule, IWardSaveImprover
{
    private static string ShortDescription = "5+ WSv";
    private static string LongDescription = "The Talisman of Protection gives its bearer a 5+ Ward save against any wounds suffered.";

    public TalismanOfProtectionRules()
        : base(TowSpecialRuleType.TalismanOfProtectionRules,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }

    public int? MeleeWardSaveBaseline => 5;

    public int MeleeWardSaveImprovement => 0;

    public int? RangedWardSaveBaseline => 5;

    public int RangedWardSaveImprovement => 0;

    public bool AsteriskOnWardSave => false;
}
