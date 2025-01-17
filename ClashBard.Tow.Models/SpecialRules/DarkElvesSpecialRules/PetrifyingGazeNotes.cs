using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;

public class PetrifyingGazeNotes : TowSpecialRule
{
    private static new string ShortDescription = "I instead of T. No ASv (WSv and Reg allowed)";
    private static new string LongDescription = "When making a roll To Wound for an attack made with this weapon, substitute the target’s Toughness with its Initiative. No armour save is permitted against wounds caused by this weapon (Ward and Regeneration saves can be attempted as normal).";

    public PetrifyingGazeNotes()
        : base(TowSpecialRuleType.PetrifyingGazeNotes,
            ShortDescription,
            LongDescription)
    {

    }
}
