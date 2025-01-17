using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.MagicWeapons;

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
    private static new string ShortDescription = "Re-roll 1 on Sv roll";
    private static new string LongDescription = "The bearer of the Dawnstone may re-roll any Armour Save roll of a natural 1.";

    public DawnstoneRules()
        : base(TowSpecialRuleType.DawnstoneRules,
            ShortDescription,
            LongDescription)
    {

    }
}