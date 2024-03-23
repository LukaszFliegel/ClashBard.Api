using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class DraggedAlong : TowSpecialRule
{
    private static new string ShortDescription = "Great war engines may be dragged to battle by hordes of infantry.";
    private static new string LongDescription = "A model with this special rule that begins its movement within 1\" of a friendly unit whose troop type is infantry, that is not fleeing and that contains ten or more models, may replace its Movement characteristic with that of the unit.";

    public DraggedAlong()
        : base(TowSpecialRuleType.DraggedAlong,
            ShortDescription,
            LongDescription)
    {

    }
}
