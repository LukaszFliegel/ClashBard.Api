using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules;

public class Regeneration5Plus : TowSpecialRule
{
    private static string ShortDescription = "5+ Reg save";
    private static string LongDescription = "A model with this special rule can make a 'Regeneration' save. The armour value of a Regeneration save is shown in brackets after the name of this special rule (shown here as 'X+'). A Regeneration save can never be modified by the AP characteristic of a weapon and can be made in addition to an armour save and a Ward save. However, any wounds saved by a Regeneration save are still counted for the purposes of calculating the combat result. Note that models with this special rule are often vulnerable to the Flaming Attacks or Magical Attacks special rules.";

    public Regeneration5Plus()
        : base(TowSpecialRuleType.Regeneration5Plus,
            ShortDescription,
            LongDescription,
            printShortDescription: false)
    {

    }
}
