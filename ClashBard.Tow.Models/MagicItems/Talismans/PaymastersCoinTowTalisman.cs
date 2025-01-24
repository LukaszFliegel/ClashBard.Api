using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.MagicItems.Talismans;

public class PaymastersCoinTowTalisman : TowTalisman
{
    private const int points = 25;

    public PaymastersCoinTowTalisman(TowObject owner) : base(owner, TowMagicItemTalismanType.PaymastersCoin, points)
    {
        SpecialRules.Add(new PaymastersCoinRules());
    }
}


public class PaymastersCoinRules : TowSpecialRule
{
    private static string ShortDescription = "xxx";
    private static string LongDescription = "xxx";

    public PaymastersCoinRules()
        : base(TowSpecialRuleType.PaymastersCoinRules,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}
