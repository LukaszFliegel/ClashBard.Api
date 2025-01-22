using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class FlyX : TowSpecialRule
{
    private static new string ShortDescription = "Many creatures of the Warhammer world can fly, held aloft either by mighty pinions or by means of magic, soaring from one side of the battlefield to the other.";
    private static new string LongDescription = "A model with this special rule can Fly. Models that can Fly can choose either to move normally on the ground (using their Movement characteristic), or to move by flying. How many inches a model can Fly varies from model to model, and will be shown in brackets after the name of this special rule (shown here as 'X'). Models that choose to move by flying may move as normal (i.e., they may charge, march and manoeuvre as if moving on the ground), except that they are able to pass freely above other models, units and terrain features without any penalty, and they can march whilst within 8\" of an enemy unit without first having to make a Leadership test. They may end their movement in terrain, but will suffer its effects if they do. They cannot end their movement 'on top' of impassable terrain or another unit, or within 1\" of an enemy unit. Models that can Fly must begin and end all of their movement on the ground. A character with this special rule cannot join a unit without this special rule, and vice versa.";

    public FlyX()
        : base(TowSpecialRuleType.FlyX,
            ShortDescription,
            LongDescription,
            printShortDescription: false)
    {

    }
}
