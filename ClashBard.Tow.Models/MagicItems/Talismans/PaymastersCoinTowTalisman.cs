using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.Talismans;

public class PaymastersCoinTowTalisman : TowTalisman
{
    private const int points = 25;

    public PaymastersCoinTowTalisman() : base(TowMagicItemTalismanType.PaymastersCoin, points)
    {
        SpecialRules.Add(new PaymastersCoinRules());
    }
}


public class PaymastersCoinRules : TowSpecialRule
{
    private static new string ShortDescription = "xxx";
    private static new string LongDescription = "xxx";

    public PaymastersCoinRules()
        : base(TowSpecialRuleType.PaymastersCoinRules,
            ShortDescription,
            LongDescription)
    {

    }
}
