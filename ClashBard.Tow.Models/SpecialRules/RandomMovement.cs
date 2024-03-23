using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class RandomMovement : TowSpecialRule
{
    private static new string ShortDescription = "Some creatures rush forward at one moment, only to falter clumsily in the next.";
    private static new string LongDescription = "Models with this special rule do not have a normal Movement characteristic. Instead, a dice roll is given (2D6, for example). Whenever a model with this special rule moves (for any reason), roll the dice to determine how far it must move. Models with this special rule move during the Compulsory Moves sub-phase. They cannot march or declare a charge. They can wheel to change direction, but cannot perform any other manoeuvres. If the model is able to make contact with an enemy unit during the Compulsory Moves sub-phase or whilst pursuing, it may do so and counts as having charged. The model aligns against the enemy unit and stops moving. A unit charged in this way must Hold. If every model in a unit has this special rule, roll once for the entire unit. If two or more models in a unit have different Random Movement characteristics, roll for each and use the lowest result for the entire unit.";

    public RandomMovement()
        : base(TowSpecialRuleType.RandomMovement,
            ShortDescription,
            LongDescription)
    {

    }
}
