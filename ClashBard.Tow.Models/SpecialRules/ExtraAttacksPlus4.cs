using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class ExtraAttacksPlus4 : TowSpecialRule
{
    private static string ShortDescription = "No limit to duplicates";
    private static string LongDescription = "Items are seen in great number and, as such, can be purchased alongside other magic items from the same category. In addition, there is no limit to how many duplicates of such items can be included in an army, or even how many duplicates a character can carry (beyond the limit of how many points that character can spend on magic items).";

    public ExtraAttacksPlus4()
        : base(TowSpecialRuleType.ExtraAttacksPlus4,
            ShortDescription,
            LongDescription)
    {

    }
}
