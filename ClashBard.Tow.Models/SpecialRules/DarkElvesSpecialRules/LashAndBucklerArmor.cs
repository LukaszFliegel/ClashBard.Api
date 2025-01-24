using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class LashAndBucklerArmor : TowSpecialRule
{
    private static string ShortDescription = "A model equipped with a lash & buckler improves its armour value by 1";
    private static string LongDescription = "A model equipped with a lash & buckler improves its armour value by 1.";

    public LashAndBucklerArmor()
        : base(TowSpecialRuleType.LashAndBucklerArmor,
            ShortDescription,
            LongDescription)
    {

    }
}
