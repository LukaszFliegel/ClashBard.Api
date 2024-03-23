using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class HatredHighElves : TowSpecialRule
{
    private static new string ShortDescription = "Enmity is rife in the Warhammer world, but hatred is nurtured over thousands of years.";
    private static new string LongDescription = "A model with this special rule may re-roll any failed rolls To Hit made against a High Elves enemy models during the first round of combat.";

    public HatredHighElves()
        : base(TowSpecialRuleType.HatredHighElves,
            ShortDescription,
            LongDescription)
    {

    }
}
