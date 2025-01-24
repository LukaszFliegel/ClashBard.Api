using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Levies : TowSpecialRule
{
    private static string ShortDescription = "Many regiments are made up of unwilling fighters, pressed into service.";
    private static string LongDescription = "Models with this special rule cannot use the Inspiring Presence rule of the army's General nor the \"Hold your Ground\" rule of a Battle Standard. However, little is expected from Levies in battle. Therefore, units that do not have this special rule are not required to make a Panic test when a friendly unit of Levies Breaks and flees from combat.";

    public Levies()
        : base(TowSpecialRuleType.Levies,
            ShortDescription,
            LongDescription)
    {

    }
}
