using ClashBard.Tow.Models;
using ClashBard.Tow.Models.SpecialRules.Interfaces;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Vanguard : TowSpecialRule, IVanguard
{
    private static string ShortDescription = "An army's vanguard advances to occupy and engage the foe ahead of their comrades.";
    private static string LongDescription = "After deployment, units with this special rule may make a Vanguard move. A unit making a Vanguard move moves as described in the Basic Movement rules. It may manoeuvre normally but cannot march. If both armies contain Vanguard units, a roll-off determines who moves first. The players then alternate moving their Vanguard units one at a time, starting with the player who won the roll-off.";

    public Vanguard()
        : base(TowSpecialRuleType.Vanguard,
            ShortDescription,
            LongDescription)
    {

    }
}
