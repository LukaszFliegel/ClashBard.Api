using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;

public class LoreOfSaphery : TowSpecialRule
{
    private static string ShortDescription = "High Magic expertise of Sapherian mages";
    private static string LongDescription = "This character may use spells from the Lore of Dark Magic, Elementalism, or Illusion. This represents the mastery of High Magic taught in the Tower of Hoeth.";

    public LoreOfSaphery()
        : base(TowSpecialRuleType.LoreOfSaphery,
            ShortDescription,
            LongDescription)
    {

    }
}
