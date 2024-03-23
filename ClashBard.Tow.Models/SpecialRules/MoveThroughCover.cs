using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class MoveThroughCover : TowSpecialRule
{
    private static new string ShortDescription = "A well-trained or naturally skilled warrior can traverse unhindered through the densest terrain.";
    private static new string LongDescription = "Models with this special rule do not suffer any modifiers to their Movement characteristic for moving through difficult or dangerous terrain. In addition, a model with this special rule may re-roll any rolls of 1 when making Dangerous Terrain tests.";

    public MoveThroughCover()
        : base(TowSpecialRuleType.MoveThroughCover,
            ShortDescription,
            LongDescription)
    {

    }
}
