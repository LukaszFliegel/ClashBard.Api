using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class HatredX : TowSpecialRule
{
    private static new string ShortDescription = "Enmity is rife in the Warhammer world, but hatred is nurtured over thousands of years.";
    private static new string LongDescription = "A model with this special rule may re-roll any failed rolls To Hit made against a hated enemy during the first round of combat. Which enemies are hated varies from model to model and will be shown in brackets after the name of this special rule (shown here as 'X'). Some models hate 'all enemies', meaning they hate all enemy models equally.";

    public HatredX()
        : base(TowSpecialRuleType.HatredX,
            ShortDescription,
            LongDescription)
    {

    }
}