using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Mercenaries : TowSpecialRule
{
    private static string ShortDescription = "Mercenary bands roam the Warhammer world, looking for employment in the armies of foreign lands.";
    private static string LongDescription = "Often, an army can include certain units drawn from another army list as mercenaries. Any such units included in your army gain this special rule. Mercenaries cannot use the Inspiring Presence rule of the army's General nor the \"Hold your Ground\" rule of a Battle Standard. Mercenaries cannot be joined by characters drawn from another army list.";

    public Mercenaries()
        : base(TowSpecialRuleType.Mercenaries,
            ShortDescription,
            LongDescription)
    {

    }
}
