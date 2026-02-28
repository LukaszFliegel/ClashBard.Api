using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;

public class ChracianWarriors : TowSpecialRule
{
    private static string ShortDescription = "Hate Chaos Warriors. Strike First vs Chaos.";
    private static string LongDescription = "Units with this special rule have Hatred against units with the Chaos or Beastmen keywords, and have the Strike First special rule when fighting such enemies.";

    public ChracianWarriors()
        : base(TowSpecialRuleType.ChracianWarriors, ShortDescription, LongDescription)
    {
    }
}
