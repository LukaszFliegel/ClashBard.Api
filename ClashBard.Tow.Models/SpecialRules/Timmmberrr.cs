using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Timmmberrr : TowSpecialRule
{
    private static string ShortDescription = "When a behemoth falls in battle, it can cause utter devastation.";
    private static string LongDescription = "When this model is reduced to zero Wounds, the winner of a roll-off chooses one of its arcs (front, flank or rear) for it to fall into. Any units that are within the chosen arc and in base contact with this model suffer D6 hits, each using the Strength characteristic of this model, with an AP of -1. Once these hits are resolved, this model is removed from play.";

    public Timmmberrr()
        : base(TowSpecialRuleType.Timmmberrr,
            ShortDescription,
            LongDescription)
    {

    }
}
