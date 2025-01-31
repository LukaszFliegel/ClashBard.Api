using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class PlusOneSpell : TowSpecialRule
{
    private static string ShortDescription = "+1 known spell";
    private static string LongDescription = "The bearer of this item knows one more spell (chosen in the usual way) than is normal for their Level of Wizardry.";

    public PlusOneSpell()
        : base(TowSpecialRuleType.Stupidity,
            ShortDescription,
            LongDescription,
            printName: false)
    {

    }
}
